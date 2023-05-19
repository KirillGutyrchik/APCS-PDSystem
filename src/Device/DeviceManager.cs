using PDSystem.Device.DeviceControl;
using PDSystem.Ext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device
{
    public interface ILuaDeviceManager
    {
        /// <summary>
        /// Добавить устройство
        /// </summary>
        /// <param name="name"> Название </param>
        /// <param name="typeID"> Номер типа </param>
        /// <param name="subtypeID"> Номер подтипа </param>
        /// <param name="description"> Описание </param>
        /// <param name="article"> Изделие </param>
        /// <returns></returns>
        ILuaDevice? AddDevice(string name, int typeID, int subtypeID,
            string description, string article);
    }


    public class DeviceManager : ISaveAsLuaTable, ILuaDeviceManager
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

        #region ILuaDeviceManager
        public ILuaDevice? AddDevice(string name, int typeID, int subtypeID, string description, string article)
        {
            var deviceInfo = DeviceInfo.ParseLUA(name, typeID) ?? new();

            if (deviceInfo is null)
                return null;


            deviceInfo.ArticleName = article;
            deviceInfo.Description = description;

            var type = DeviceType.FromID(typeID);
            var subType = DeviceSubType.FromTypeAndID(type, subtypeID);

            return AddDevice(type, subType, deviceInfo);
        }
        #endregion

        public StringBuilder SaveAsLuaTable(string prefix)
        {
            var result = new StringBuilder();
            result.Append("------------------------------------------------------------------------------\n")
                .Append($"{prefix}--Устройства\n")
                .Append($"{prefix}devices =\n")
                .Append($"{prefix}\t{{\n");

            devices.ForEach( device => { result.Append(device.ToString()); });

            result.Append($"{prefix}\t}}\n");

            return result;
        }

        

        public List<Device> Devices => devices;

        private static DeviceManager? instance = null;
        private List<Device> devices = new();
    }
}
