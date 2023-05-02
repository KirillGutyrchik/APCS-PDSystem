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
        public const string DEVICE_NAME_PATTERN = "^((?<equ>[=])?(?=[A-Z]+\\+))?(?(equ)(?<plant>[A-Z]+)?)(?<plus>[+])?(?<objName>[A-Z]+)?(?(objName)(?<objNumber>[0-9]+))(?(plus)[-])(?<type>[A-Z]+)(?<devNumber>[0-9]+)$";

        public string Name { get; private set; } = string.Empty;

        public string CADName { get; private set; } = string.Empty;

        public string ObjectName { get; private set; } = string.Empty;

        public int ObjectNumber { get; private set; } = -1;

        public int DeviceNumber { get; private set; } = -1;

        public string Description { get; set; } = string.Empty;

        public string ArticleName { get; set; } = string.Empty;

        public string TypeStr { get; private set; } = string.Empty;

        /// <summary>
        /// Разобрать имя устройства:
        /// Возможные варианты =PLANT+OBJ1-V2 / =PLANT+OBJ1-V2 / =+-V2 / +-V2 / V2 / +OBJ1-V2 / OBJ1V2
        /// </summary>
        /// <param name="name">Имя устройства</param>
        public bool Parse(string devName)
        {
            var match = Regex.Match(devName, DEVICE_NAME_PATTERN);
            if (match.Success)
            {
                ObjectName = match.Groups["objName"].Value;
                int.TryParse(match.Groups["objNumber"].Value, out int objNUmber);
                ObjectNumber = objNUmber;
                TypeStr = match.Groups["type"].Value;
                DeviceNumber = int.Parse(match.Groups["devNumber"].Value);

                CADName = $"+{ObjectName}{ObjectNumber}-{TypeStr}{DeviceNumber}";
                Name = $"{ObjectName}{ObjectNumber}{TypeStr}{DeviceNumber}";
            }

            return match.Success;
        }

        public string ParseName
        {
            set
            {
                Parse(value);
            }
        }
    }
}
