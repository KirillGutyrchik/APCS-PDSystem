using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.TechObject
{
    public interface IBaseOperation
    {

    }

    /// <summary>
    /// Методы вызываемые из LUA
    /// </summary>
    public interface ILuaBaseOperation
    {
        /// <summary>
        /// Добавить активный параметр
        /// </summary>
        /// <param name="luaName">Lua-имя</param>
        /// <param name="name">Имя</param>
        /// <param name="defaultValue">Значение по-умолчанию</param>
        /// <returns>Добавленный параметр</returns>
        void AddActiveParameter(string luaName, string name, string defaultValue);

        /// <summary>
        /// Добавить активный булевый параметр
        /// </summary>
        /// <param name="luaName">Lua-имя</param>
        /// <param name="name">Имя</param>
        /// <param name="defaultValue">Значение по-умолчанию</param>
        void AddActiveBoolParameter(string luaName, string name, string defailtValue);

        /// <summary>
        /// Добавить базовый шаг для операции
        /// </summary>
        /// <param name="stateTypeStr"></param>
        /// <param name="luaName"></param>
        /// <param name="name"></param>
        /// <param name="defaultPosition"></param>
        public void AddStep(string stateTypeStr, string luaName, string name,
            int defaultPosition);
    }

    public class BaseOperation : IBaseOperation, ILuaBaseOperation
    {
        #region ILuaBaseOperation
        public void AddActiveBoolParameter(string luaName, string name, string defailtValue)
        {
            throw new NotImplementedException();
        }

        public void AddActiveParameter(string luaName, string name, string defaultValue)
        {
            throw new NotImplementedException();
        }

        public void AddStep(string stateTypeStr, string luaName, string name, int defaultPosition)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
