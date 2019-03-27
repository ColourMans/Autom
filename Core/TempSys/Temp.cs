using System;
using StagWare.FanControl;
using StagWare.FanControl.Plugins;
//using RGiesecke.DllExport;

namespace TempSys
{
    public class Temp
    {
        [DllExport]
        public static int GetTemp()
        {
            byte register = 0xB0;
            byte b = 0;
            AccessEcSynchronized(ec =>
            {
                b = ec.ReadByte(register);
            });
            string text = b.ToString();
            return Convert.ToInt32(text);
        }

        static IEmbeddedController ec;
        private static IEmbeddedController LoadEC()
        {
            var ecLoader = new FanControlPluginLoader<IEmbeddedController>(FanControl.PluginsDirectory);

            if (ecLoader.FanControlPlugin == null)
            {

                return null;
            }

            ecLoader.FanControlPlugin.Initialize();

            if (ecLoader.FanControlPlugin.IsInitialized)
            {
                return ecLoader.FanControlPlugin;
            }
            else
            {

                ecLoader.FanControlPlugin.Dispose();
            }

            return null;
        }

        private static void AccessEcSynchronized(Action<IEmbeddedController> callback)
        {
            using (ec = LoadEC())
            {
                if (ec != null)
                {
                    AccessEcSynchronized(callback, ec);
                }
            }
        }

        private static void AccessEcSynchronized(Action<IEmbeddedController> callback, IEmbeddedController ec)
        {
            if (ec.AcquireLock(200))
            {
                try
                {
                    callback(ec);
                }
                finally
                {
                    ec.ReleaseLock();
                }
            }
        }
    }
}
