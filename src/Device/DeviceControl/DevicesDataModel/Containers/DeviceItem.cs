using PDSystem.Device.DeviceControl.DevicesDataModel.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PDSystem.Device.DeviceControl
{
    public class DeviceItem : DeviceTreeListItem
    {
        #region DeviceTreeListItem
        public override (string FirstColumn, string SecondColumn) DisplayText
            => ($"{device.DeviceType.Name}{device.DeviceNumber} {device.Description}", string.Empty);

        public override List<IDeviceTreeListItem> Items => items;
        #endregion

        public DeviceItem(Device device, DeviceObjectItem parent)
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
            var infoContainer = new DeviceOptionsItem("Описание", IconIndex.Description, this);

            infoContainer.AddOptionItem(new DeviceItemInfo("Подтип", device.DeviceSubType.Name, infoContainer));
            infoContainer.AddOptionItem(new DeviceItemInfo("Описание", device.Description, infoContainer));
            infoContainer.AddOptionItem(new DeviceItemInfo("Изделие", device.ArticleName, infoContainer));

            items.Add(infoContainer);
        }

        private void InitDeviceItemChannels()
        {
            if (device.Channels.AllChannels.Any() is false) return;

            var channelsContainer = new DeviceOptionsItem("Каналы", IconIndex.NONE, this);

            foreach (var channel in device.Channels.AllChannels)
            {
                channelsContainer.AddOptionItem(new DeviceChannelItem(channel, channelsContainer));
            }

            items.Add(channelsContainer);
        }

        private void InitDeviceItemParameters()
        {
            if (device.Parameters.Empty) return;

            var patametersContainer = new DeviceOptionsItem("Параметры", IconIndex.Parameters, this);

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

            var propertiesContainer = new DeviceOptionsItem("Свойства", IconIndex.Properties, this);

            foreach (var property in device.Properties.ToList())
            {
                propertiesContainer.AddOptionItem(
                    new DevicePropertyItem(property, device.Properties[property], propertiesContainer));
            }

            items.Add(propertiesContainer);
        }

        public Device Device => device;



        private List<IDeviceTreeListItem> items = new();
        private Device device;
        private DeviceObjectItem parent;
    }
}
