using System.Collections.Immutable;
using System.Data;
using System.Xml.Linq;

namespace PDSystem.Device
{
    public partial record class DeviceSubType
    {
        /// <summary> Сигнальная колонна (красный, желтый, зеленый и сирена) </summary>
        public static readonly DeviceSubType HLA = new(SubTypeIdentifier(DeviceType.HLA) + 1, nameof(HLA))
        {
            Channels =
            {
                DO = { "Красный цвет", "Желтый цвет", "Зеленый цвет", "Звуковая сигнализация" },
            },
            RuntimeParameters =
            {
                RuntimeParameter.R_CONST_RED,
            },
        };

        /// <summary> Виртуальная сигнальная колонна (без привязки к модулям) </summary>
        public static readonly DeviceSubType HLA_VIRT = new(SubTypeIdentifier(DeviceType.HLA) + 2, nameof(HLA_VIRT))
        {
            Properties =
            {
                Property.SIGNALS_SEQUENCE,
            },
        };

        /// <summary> Сигнальная колонна IO-Link (настраиваемая) </summary>
        public static readonly DeviceSubType HLA_IOLINK = new(SubTypeIdentifier(DeviceType.HLA) + 3, nameof(HLA_IOLINK))
        {
            Properties =
            {
                Property.SIGNALS_SEQUENCE,
            },
            Channels =
            {
                AI = { string.Empty },
                AO = { string.Empty },
            }
        };
    }


    public class HLA : Device
    {
        public HLA(DeviceSubType subType, DeviceInfo deviceInfo) 
            : base(subType, deviceInfo)
        {
            if (Properties.ToList().Contains(Property.SIGNALS_SEQUENCE))
                Properties.OnPropertyChanged += ReadSingnalSequence;

            if (subType == DeviceSubType.HLA)
            {
                hasAlarm = true;
                hasGreen = true;
                hasYellow = true;
                hasRed = true;
            }
        }

        //Check signal sequnce

        public override ImmutableDictionary<string, int> DeviceTags 
        {
            get
            {
                var defaultTags = new Dictionary<string, int>()
                {
                    { Tag.ST, 1 },
                    { Tag.M, 1 },
                };
                
                if (hasAlarm) defaultTags.Add(Tag.L_SIREN, 1);
                if (hasBlue) defaultTags.Add(Tag.L_BLUE, 1);
                if (hasGreen) defaultTags.Add(Tag.L_GREEN, 1);
                if (hasYellow) defaultTags.Add(Tag.L_YELLOW, 1);
                if (hasRed) defaultTags.Add(Tag.L_RED, 1);

                return defaultTags.ToImmutableDictionary();
            }
        }

        private void ReadSingnalSequence()
        {
            string? sequenceValue = Properties[Property.SIGNALS_SEQUENCE] as string;
            if (!string.IsNullOrEmpty(sequenceValue))
            {
                hasAlarm = sequenceValue.Count(x => x == soundAlarm) == 1;
                hasBlue = sequenceValue.Count(x => x == blueLight) == 1;
                hasGreen = sequenceValue.Count(x => x == greenLight) == 1;
                hasYellow = sequenceValue.Count(x => x == yellowLight) == 1;
                hasRed = sequenceValue.Count(x => x == redLight) == 1;
            }
        }

        private static readonly char soundAlarm = 'A';
        private static readonly char blueLight = 'B';
        private static readonly char greenLight = 'G';
        private static readonly char yellowLight = 'Y';
        private static readonly char redLight = 'R';

        private bool hasAlarm = false;
        private bool hasBlue = false;
        private bool hasGreen = false;
        private bool hasYellow = false;
        private bool hasRed = false;
    }
}
