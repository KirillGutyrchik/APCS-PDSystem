using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PDSystem.Device
{
    /// <summary>
    /// Класс DeviceInfo содержит основную информацию об устройстве:
    /// Название, описание, изделие
    /// </summary>
    public class DeviceInfo
    {
        /// <summary>
        /// Шаблон для разбора имени или CAD-имени устройства
        /// </summary>
        public static readonly string DEVICE_NAME_PATTERN = "^((?<equ>[=])?(?=[A-Z]+\\+))?(?(equ)(?<plant>[A-Z]+)?)(?<plus>[+])?(?<objName>[A-Z_]+)?(?(objName)(?<objNumber>[0-9]+))(?(plus)[-])(?<type>[A-Z]+)(?<devNumber>[0-9]+)$";

        /// <summary>
        /// Полное Lua-имя устройства
        /// </summary>
        /// <remarks> OBJ2V1 </remarks>
        public string Name { get; private set; } = string.Empty;

        /// <summary>
        /// Название устройства для CAD
        /// </summary>
        /// <remarks> =PAGE+OBJ2-V1 </remarks>
        public string CADName { get; private set; } = string.Empty;

        /// <summary>
        /// Название объкта
        /// </summary>
        /// <remarks> OBJ : OBJ2V1 </remarks> 
        public string ObjectName { get; private set; } = string.Empty;

        /// <summary>
        /// Номер объекта
        /// </summary>
        /// <remarks> 2 : OBJ2V1 </remarks>
        public int ObjectNumber { get; private set; } = -1;

        /// <summary>
        /// Название типа
        /// </summary>
        /// <remarks> V : OBJ2V1 </remarks>
        public string TypeStr { get; private set; } = string.Empty;

        /// <summary>
        /// Номер устройства
        /// </summary>
        /// <remarks> 1 : OBJ2V1 </remarks>
        public int DeviceNumber { get; private set; } = -1;

        /// <summary>
        /// Описание устройства
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ArticleName { get; set; } = string.Empty;


        /// <summary>
        /// Разобрать имя устройства:
        /// Возможные варианты =PLANT+OBJ1-V2 / =PLANT+OBJ1-V2 / =+-V2 / +-V2 / V2 / +OBJ1-V2 / OBJ1V2
        /// </summary>
        /// <param name="devName">Имя устройства</param>
        public static DeviceInfo? Parse(string devName)
        {
            var deviceInfo = new DeviceInfo();
            var match = Regex.Match(devName, DEVICE_NAME_PATTERN);
            if (match.Success)
            {
                deviceInfo.ObjectName = match.Groups["objName"].Value;
                int.TryParse(match.Groups["objNumber"].Value, out int objNUmber);
                deviceInfo.ObjectNumber = objNUmber;
                deviceInfo.TypeStr = match.Groups["type"].Value;
                deviceInfo.DeviceNumber = int.Parse(match.Groups["devNumber"].Value);

                deviceInfo.CADName = $"+{deviceInfo.ObjectName}{deviceInfo.ObjectNumber}-{deviceInfo.TypeStr}{deviceInfo.DeviceNumber}";
                deviceInfo.Name = $"{deviceInfo.ObjectName}{deviceInfo.ObjectNumber}{deviceInfo.TypeStr}{deviceInfo.DeviceNumber}";

                return deviceInfo;
            }

            return null;
        }

        public string ParseName
        {
            set
            {
                //Parse(value);
            }
        }
    }
}
