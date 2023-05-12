using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PDSystem.Device.DeviceControl
{
    public class DeviceItem : IDeviceTreeListItem
    {
        #region Реализация IDeviceTreeListItem
        public (string FirstColumn, string SecondColumn) DisplayText 
            => ($"{device.DeviceType.Name}{device.DeviceNumber} {device.Description}", string.Empty);

        public string EditText => string.Empty;

        public IconIndex IconIndex => IconIndex.NONE;

        public bool IsEditable => false;

        List<IDeviceTreeListItem> IDeviceTreeListItem.Items => items;

        IDeviceTreeListItem? IDeviceTreeListItem.Parent => parent;
        #endregion

        public DeviceItem(Device device, DeviceObjectContainer parent)
        {
            this.device = device;
            this.parent = parent;

            InitDeviceItemInfo();
            InitDeviceItemChannels();
            InitDeviceItemParameters();
            InitDeviceItemProperties();
        }

        private void InitDeviceItemInfo()
        {
            var infoContainer = new DeviceOptionsContainer("Описание", IconIndex.Description, this);

            infoContainer.AddOptionItem(new DeviceItemInfo("Подтип", device.DeviceSubType.Name, infoContainer));
            infoContainer.AddOptionItem(new DeviceItemInfo("Изделие", device.ArticleName, infoContainer));
            infoContainer.AddOptionItem(new DeviceItemInfo("Описание", device.Description, infoContainer));

            items.Add(infoContainer);
        }

        private void InitDeviceItemChannels()
        {
            if (device.Channels.Any() is false) return;

            var channelsContainer = new DeviceOptionsContainer("Каналы", IconIndex.NONE, this);

            foreach (var channel in device.Channels)
            {
                channelsContainer.AddOptionItem(new DeviceChannelItem(channel, channelsContainer));
            }

            items.Add(channelsContainer);
        }

        private void InitDeviceItemParameters()
        {
            if (device.Parameters.Empty) return;

            var patametersContainer = new DeviceOptionsContainer("Параметры", IconIndex.Parameters, this);

            foreach (var parameter in device.Parameters.ToList())
            {
                patametersContainer.AddOptionItem(
                    new DeviceParameterItem(parameter, device.Parameters[parameter], patametersContainer));
            }

            items.Add(patametersContainer);
        }

        private void InitDeviceItemProperties()
        {
            if (device.Properties.Empty) return;

            var propertiesContainer = new DeviceOptionsContainer("Свойства", IconIndex.Properties, this);

            foreach(var property in device.Properties.ToList())
            {
                propertiesContainer.AddOptionItem(
                    new DevicePropertyItem(property, device.Properties[property], propertiesContainer));
            }

            items.Add(propertiesContainer);
        }

        public Device Device => device;



        private List<IDeviceTreeListItem> items = new();
        private Device device;
        private DeviceObjectContainer parent;
    }
}
