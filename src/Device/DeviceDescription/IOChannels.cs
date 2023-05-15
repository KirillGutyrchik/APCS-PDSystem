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

    public class IOChannel : IIOChannel, ISaveAsLuaTable
    {

        /// <param name="channelType">Тип канала</param>
        /// <param name="comment">Комментарий к каналу</param>
        public IOChannel(ChannelType channelType, string comment)
        {
            this.channelType = channelType;
            this.comment = comment;
        }



        public string Name => channelType.Name;

        public string Comment => comment;



        public int FullModule => fullModule;


        public int Node => node;
        public int Offset => offset;

        public int PhysicalClamp => physicalClamp;

        public int LogicalClamp => logicalClamp;

        public int ModuleOffset => moduleOffset;

        public void SetChannel(
            int node, int offset, int physical_port,
            int logical_port, int module_offset)
        {
            this.node = node;
            this.offset = offset;
            this.physicalClamp = physical_port;
            this.logicalClamp = logical_port;
            this.moduleOffset = module_offset;
        }

        public StringBuilder SaveAsLuaTable(string prefix = "")
        {
            return new StringBuilder()
                .Append($"{prefix}{{\n")
                .Append($"{prefix}-- {comment}\n")
                .Append($"{prefix}node          = {Node},\n")
                .Append($"{prefix}offset        = {Offset},\n")
                .Append($"{prefix}physical_port = {PhysicalClamp},\n")
                .Append($"{prefix}logical_port  = {LogicalClamp},\n")
                .Append($"{prefix}module_offset = {ModuleOffset},\n")
                .Append($"{prefix}}},\n");
        }

        public ChannelType ChannelType
        {
            get
            {
                return channelType;
            }
        }

        private int offset;

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

    public class DeviceChannels : ISaveAsLuaTable
    {

        public DeviceChannels()
        {

        }

        public DeviceChannels(List<string> DO, List<string> DI, List<string> AO, List<string> AI) 
        {
            channels.DO = DO.Select(comment => new IOChannel(ChannelType.DO, comment)).ToList();
            channels.DI = DI.Select(comment => new IOChannel(ChannelType.DI, comment)).ToList();
            channels.AO = AO.Select(comment => new IOChannel(ChannelType.AO, comment)).ToList();
            channels.AI = AI.Select(comment => new IOChannel(ChannelType.AI, comment)).ToList();
        }

        public StringBuilder SaveAsLuaTable(string prefix = "")
        {
            return new StringBuilder()
                .Append(SaveChannels(prefix, "DO", DO))
                .Append(SaveChannels(prefix, "DI", DI))
                .Append(SaveChannels(prefix, "AO", AO))
                .Append(SaveChannels(prefix, "AI", AI));
        }

        private StringBuilder SaveChannels(string prefix, string name, List<IOChannel> channels)
        {
            var result = new StringBuilder();
            if (channels.Any() is false) return result;

            result .Append($"{prefix}{name} =\n")
                .Append($"{prefix}\t{{\n");

            foreach (var channel in channels)
            {
                result.Append(channel.SaveAsLuaTable(prefix + "\t\t"));
            }

            return result.Append($"{prefix}\t}},\n");
        }

        public List<IOChannel> DO => channels.DO;

        public List<IOChannel> DI => channels.DI;

        public List<IOChannel> AO => channels.AO;

        public List<IOChannel> AI => channels.AI;

        public List<IOChannel> AllChannels 
            => channels.DO.Concat(channels.DI).Concat(channels.AO).Concat(channels.AI).ToList();

        private (List<IOChannel> DO, List<IOChannel> DI, List<IOChannel> AO, List<IOChannel> AI) channels;
    }
}
