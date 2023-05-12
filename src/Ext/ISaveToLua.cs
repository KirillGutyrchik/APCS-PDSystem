using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.Ext
{
    public interface ISaveToLua
    {
        /// <summary>
        /// Сохранение в виде Lua-таблицы
        /// </summary>
        /// <param name="prefix">Выравнивание</param>
        /// <returns> string builder lua table </returns>
        StringBuilder SaveAsLuaTable(string prefix = "");
    }
}
