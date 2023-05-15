using PDSystem.Ext;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PDSystem.Device
{
    public class DeviceDescription : ISaveAsLuaTable
    {
        public StringBuilder SaveAsLuaTable(string prefix = "")
        {
            return new StringBuilder()
                .Append(Properties.SaveAsLuaTable(prefix))
                .Append(Channels.SaveAsLuaTable(prefix))
                // RT PARAMETERS
                .Append(Parameters.SaveAsLuaTable(prefix));
        }

        public DeviceChannels Channels
        {
            get => channels ??= new();
            init => channels = value;
        }

        public DeviceParameters Parameters
        {
            get => parameters ??= new();
            init => parameters = value;
        }

        public DeviceRuntimeParameters RuntimeParameters
        {
            get => runtimeParameters ??= new();
            init => runtimeParameters = value;
        }

        public DeviceProperties Properties
        {
            get => properties ??= new();
            init => properties = value;
        }

        public Dictionary<string, double> IolConfProperties
        {
            get => iolConfProperties ?? throw new ArgumentNullException(nameof(iolConfProperties));
            init => iolConfProperties = value ?? throw new ArgumentNullException(nameof(iolConfProperties));
        }

        public ImmutableDictionary<string, int> DeviceTags
        {
            get => deviceTags ??= new Dictionary<string, int>().ToImmutableDictionary();
            init => deviceTags = value;
        }

        private DeviceChannels? channels;
        private DeviceParameters? parameters;
        private DeviceRuntimeParameters? runtimeParameters;
        private DeviceProperties? properties;
        private Dictionary<string, double>? iolConfProperties;
        private ImmutableDictionary<string, int>? deviceTags;
    }
}
