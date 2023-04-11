using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device
{
    /// <summary>
    /// Описание устройства:
    /// Каналы, параметры, свойства
    /// </summary>
    public class DeviceDescription : ICloneable
    {
        public object Clone()
        {
            return new DeviceDescription()
            {
                Parameters = (DeviceParameters)Parameters.Clone(),
            };
        }

        public DeviceParameters Parameters 
        { 
            get => parameters ?? new List<Parameter>();
            set => parameters = value; 
        }


        private DeviceParameters? parameters;
    }
}
