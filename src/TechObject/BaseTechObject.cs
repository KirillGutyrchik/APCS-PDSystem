using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.TechObject
{
    public interface IBaseTechObject
    {
        /// <summary>
        /// Добавить группу объектов (AttachedObjects: группа танков, источники ...)
        /// </summary>
        /// <param name="luaName"> Lua-назавние группы </param>
        /// <param name="name"> Название группы </param>
        /// <param name="allowedObjects"> Разрешенные типы объектов для добавления в группу </param>
        void AddObjectGroup(string luaName, string name, string allowedObjects);

        IBaseOperation AddBaseOperation(string luaName, string name, int defaultPosiotion);
    }

    public class BaseTechObject
    {

    }
}
