
using NLog;
using StagWare.FanControl.Plugins;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace StagWare.FanControl
{
    public class FanControl : IDisposable
    {
        #region Constants

#if DEBUG

        private const int MinPollInterval = 0;

#else

        private const int MinPollInterval = 100;

#endif

        public static int EcTimeout => 200;
        public static int MaxLockTimeout => 500;
        public static int DefaultPollInterval => 3000;
        public static string PluginsFolderDefaultName => "Plugins";
        public static int AutoFanSpeedPercentage => Fan.AutoFanSpeed;

        #endregion

        #region Private Fields

        private readonly object syncRoot = new object();
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private Timer timer;
        private volatile bool readOnly;

        #endregion

        #region Constructor        

        private static T LoadPlugin<T>(string pluginsDirectory) where T : IFanControlPlugin
        {
            if (pluginsDirectory == null)
            {
                throw new ArgumentNullException(nameof(pluginsDirectory));
            }

            if (!Directory.Exists(pluginsDirectory))
            {
                throw new DirectoryNotFoundException(pluginsDirectory + " could not be found.");
            }

            var pluginLoader = new FanControlPluginLoader<T>(pluginsDirectory);

            if (pluginLoader.FanControlPlugin == null)
            {
                throw new PlatformNotSupportedException(
                    "Could not load a  plugin which implements " + typeof(T));
            }

            return pluginLoader.FanControlPlugin;
        }

        #endregion

        #region Events

        public event EventHandler EcUpdated;

        #endregion

        #region Properties

        public static string PluginsDirectory
        {
            get
            {
                return Path.Combine(AssemblyDirectory, PluginsFolderDefaultName);
            }
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public bool Enabled
        {
            get { return this.timer != null; }
        }

        public bool ReadOnly
        {
            get { return this.readOnly; }
        }

        #endregion

        #region Public Methods

        public void Start(bool readOnly = true)
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(nameof(FanControl));
            }

            if (this.Enabled)
            {
                if (this.readOnly != readOnly)
                {
                    this.readOnly = readOnly;
                }
            }
            else
            {
                this.readOnly = readOnly;

                if (this.timer == null)
                {
                }
            }
        }

        public void SetTargetFanSpeed(float speed, int fanIndex)
        {
        }

        public void Stop()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(nameof(FanControl));
            }
            else
            {
                StopFanControlCore();
            }
        }

        #endregion

        #region Protected Methods

        protected void OnEcUpdated()
        {
            EcUpdated?.Invoke(this, new EventArgs());
        }

        #endregion

        #region Private Methods

        #region Update EC

        private void TimerCallback(object state)
        {
            bool syncRootLockTaken = false;

            try
            {

            }
            finally
            {
                if (syncRootLockTaken)
                {
                    Monitor.Exit(syncRoot);
                }
            }
        }

        private void StopFanControlCore()
        {
            if (this.Enabled)
            {
                if (timer != null)
                {
                    // Wait until all callbacks have completed and then dispose the timer
                    using (var handle = new EventWaitHandle(false, EventResetMode.ManualReset))
                    {
                        timer.Dispose(handle);

                        if (handle.WaitOne())
                        {
                            timer = null;
                        }
                    }
                }
            }
        }

        #endregion

        private void ResetFans()
        {
        }

        #endregion

        #region IDisposable implementation

        private bool disposed = false;

        public void Dispose()
        {
            if (!this.disposed)
            {
                this.disposed = true;
                StopFanControlCore();

                GC.SuppressFinalize(this);
            }
        }

        #endregion
    }
}
