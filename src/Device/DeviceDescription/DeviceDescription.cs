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
    public class DeviceDescription
    {
        /// <summary>
        /// Клонирование описания
        /// </summary>
        /// <returns>Клон описания устройства с пустыми значениями</returns>
        public DeviceDescription CloneTemplate()
        {
            return new DeviceDescription()
            {
                Parameters = parameters?.CloneTemplate() ?? new(),
                Properties = properties?.CloneTemplate() ?? new(),
                Channels = channels?.Select(ch => new IOChannel(ch.ChannelType, ch.Comment)).ToList() ?? new(),
            };
        }

        public List<IOChannel> Channels
        {
            get => channels ?? new();
            set => channels ??= value;
        }

        public DeviceParameters Parameters
        {
            get => parameters ?? new();
            set => parameters ??= value;
        }

        public Dictionary<string, object?> RuntimeParameters
        {
            get => runtimeParameters ?? throw new ArgumentNullException(nameof(runtimeParameters));
            init => runtimeParameters = value ?? throw new ArgumentNullException(nameof(runtimeParameters));
        }

        public DeviceProperties Properties
        {
            get => properties ?? new();
            set => properties ??= value;
        }

        public Dictionary<string, double> IolConfProperties
        {
            get => iolConfProperties ?? throw new ArgumentNullException(nameof(iolConfProperties));
            init => iolConfProperties = value ?? throw new ArgumentNullException(nameof(iolConfProperties));
        }

        public ImmutableDictionary<string, int> DeviceTags
        {
            get => deviceTags ??= new Dictionary<string, int>().ToImmutableDictionary();
            set => deviceTags ??= value;
        }

        private List<IOChannel>? channels;
        private DeviceParameters? parameters;
        private Dictionary<string, object?>? runtimeParameters;
        private DeviceProperties? properties;
        private Dictionary<string, double>? iolConfProperties;
        private ImmutableDictionary<string, int>? deviceTags;
    }
}
