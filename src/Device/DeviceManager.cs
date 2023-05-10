using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device
{
    public class DeviceManager
    {
        private static readonly Dictionary<DeviceType, Func<DeviceSubType, DeviceInfo, Device>> DeviceCreator = new()
        {
            [DeviceType.V]   = (st, di) => new V(st, di),
            [DeviceType.VC]  = (st, di) => new VC(st, di),
            [DeviceType.M]   = (st, di) => new M(st, di),
            [DeviceType.LS]  = (st, di) => new LS(st, di),
            [DeviceType.TE]  = (st, di) => new TE(st, di),
            [DeviceType.FS]  = (st, di) => new FS(st, di),
            [DeviceType.GS]  = (st, di) => new GS(st, di),
            [DeviceType.FQT] = (st, di) => new FQT(st, di),
            [DeviceType.LT]  = (st, di) => new LT(st, di),
            [DeviceType.QT]  = (st, di) => new QT(st, di),
            [DeviceType.HA]  = (st, di) => new HA(st, di),
            [DeviceType.HL]  = (st, di) => new HL(st, di),
            [DeviceType.SB]  = (st, di) => new SB(st, di),
            [DeviceType.DI]  = (st, di) => new DI(st, di),
            [DeviceType.DO]  = (st, di) => new DO(st, di),
            [DeviceType.AI]  = (st, di) => new AI(st, di),
            [DeviceType.AO]  = (st, di) => new AO(st, di),
            [DeviceType.WT]  = (st, di) => new WT(st, di),
            [DeviceType.PT]  = (st, di) => new PT(st, di),
            [DeviceType.F]   = (st, di) => new F(st, di),
            [DeviceType.C]   = (st, di) => new C(st, di),
            [DeviceType.HLA] = (st, di) => new HLA(st, di),
            [DeviceType.CAM] = (st, di) => new CAM(st, di),
            [DeviceType.PDS] = (st, di) => new PDS(st, di),
            [DeviceType.TS]  = (st, di) => new TS(st, di),
        };

        private DeviceManager() 
        { }
        
        public static DeviceManager Instance
        {
            get => instance ??= new DeviceManager();
        }

        private Device? AddDevice(DeviceType type, DeviceSubType subType, DeviceInfo deviceInfo)
        {
            

            
            var device = DeviceCreator[type](subType, deviceInfo);

            devices.Add(device);

            return device;
        }

        /// <summary>
        /// Добавить устройство по назаванию, номеру типа и номеру подтипа.
        /// Применяется при 
        /// </summary>
        /// <param name="name"> имя устройства </param>
        /// <param name="typeID"> номер типа </param>
        /// <param name="subTypeID"> номер подтипа </param>
        /// <returns> Добавленное устройство </returns>
        public Device? AddDevice(string name, int typeID,  int subTypeID)
        {
            var deviceInfo = DeviceInfo.ParseLUA(name, typeID) ?? new();

            if (deviceInfo is null)
                return null;

            var type = DeviceType.FromID(typeID);
            var subType = DeviceSubType.FromTypeAndID(type, subTypeID);

            return AddDevice(type, subType, deviceInfo);
        }


        private static DeviceManager? instance = null;
        private List<Device> devices = new();
    }
}
