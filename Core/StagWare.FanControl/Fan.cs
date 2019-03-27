using StagWare.FanControl.Plugins;

namespace StagWare.FanControl
{
    internal class Fan
    {
        #region Constants

        public const int AutoFanSpeed = 101;
        private const int CriticalTemperatureOffset = 15;

        #endregion

        #region Private Fields

        //private readonly bool readWriteWords;
        //private readonly int criticalTemperature;
        //private readonly IEmbeddedController ec;

        //private readonly int minSpeedValueWrite;
        //private readonly int maxSpeedValueWrite;
        //private readonly int minSpeedValueRead;
        //private readonly int maxSpeedValueRead;
        //private readonly int minSpeedValueReadAbs;
        //private readonly int maxSpeedValueReadAbs;

        //private float targetFanSpeed;

        #endregion

        #region Properties

        //public float TargetSpeed
        //{
        //    get
        //    {
        //        return this.CriticalModeEnabled
        //            ? 100.0f
        //            : this.targetFanSpeed;
        //    }
        //}

        public float CurrentSpeed { get; private set; }
        public bool AutoControlEnabled { get; private set; }
        public bool CriticalModeEnabled { get; private set; }

        #endregion

        #region Public Methods

        //public virtual void SetTargetSpeed(float speed, float temperature, bool readOnly)
        //{
        //    HandleCriticalMode(temperature);
        //    this.AutoControlEnabled = (speed < 0) || (speed > 100);

        //    if (AutoControlEnabled)
        //    {
        //    }
        //    else
        //    {
        //        this.targetFanSpeed = speed;
        //    }

        //    speed = CriticalModeEnabled ? 100.0f : this.targetFanSpeed;
        //}

        #endregion

        #region Private Methods

        //private void HandleCriticalMode(double temperature)
        //{
        //    if (this.CriticalModeEnabled
        //        && (temperature < (this.criticalTemperature - CriticalTemperatureOffset)))
        //    {
        //        this.CriticalModeEnabled = false;
        //    }
        //    else if (temperature > this.criticalTemperature)
        //    {
        //        this.CriticalModeEnabled = true;
        //    }
        //}

        #endregion
    }
}
