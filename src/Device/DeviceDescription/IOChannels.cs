using PDSystem.Ext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Device
{
    public record ChannelType : Enumeration<ChannelType>
    {
        public static readonly ChannelType DO = new(0, nameof(DO));
        public static readonly ChannelType DI = new(1, nameof(DI));
        public static readonly ChannelType AI = new(2, nameof(AI));
        public static readonly ChannelType AO = new(3, nameof(AO));
        public static readonly ChannelType AIAO = new(4, nameof(AIAO));
        public static readonly ChannelType DODI = new(5, nameof(DODI));


        public ChannelType(int id, string name)
            : base(id, name)
        {
        }
    }

    public interface IIOChannel
    {
        /// <summary> Логический номер клеммы (порядковый) </summary>
        int LogicalClamp { get; }

        /// <summary> Имя канала (DI,DO, AI,AO) </summary>
        string Name { get; }

        /// <summary> Комментарий </summary>
        string Comment { get; }

        /// <summary> Сдвиг начала модуля </summary>
        int ModuleOffset { get; }

        /// <summary> Полный номер модуля </summary>
        int FullModule { get; }
    }

    public class IOChannel : IIOChannel
    {

        /// <param name="channelType">Тип канала</param>
        /// <param name="comment">Комментарий к каналу</param>
        public IOChannel(ChannelType channelType, string comment)
        {
            this.channelType = channelType;
            this.comment = comment;
        }

        public int LogicalClamp => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public string Comment => throw new NotImplementedException();

        public int ModuleOffset => throw new NotImplementedException();

        public int FullModule => throw new NotImplementedException();


        public ChannelType ChannelType
        {
            get
            {
                return channelType;
            }
        }

        /// <summary> Номер узла. </summary>
        private int node;
        /// <summary> Номер модуля. </summary>
        private int module;
        /// <summary> Полный номер модуля. </summary>
        private int fullModule;
        /// <summary> Физический номер клеммы. </summary>
        private int physicalClamp;
        /// <summary> Комментарий. </summary>
        private string comment;
        /// <summary> Тип канала (DO, DI, AO ,AI ...) </summary>
        private ChannelType channelType;
        /// <summary> Логический номер клеммы. </summary>
        private int logicalClamp;
        /// <summary> Сдвиг начала модуля. </summary>
        private int moduleOffset;
    }
}
