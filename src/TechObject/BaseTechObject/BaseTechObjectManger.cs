using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.TechObject
{
    public interface IBaseTechObjectManager
    {
        IBaseTechObject GetTechObjectCopy(string name);

        string GetS88Name(int s88Level);

        int GetS88Level(string type);

        List<IBaseTechObject> Objects { get; }
    }

    /// <summary>
    /// Методы вызываемые в LUA
    /// </summary>
    public interface ILuaBaseTechObjectManager
    {
        /// <summary>
        /// Добавить базовый объект в менеджер объектов, делегирует.
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="eplanName">Имя в eplan</param>
        /// <param name="s88Level">Уровень по ISA88</param>
        /// <param name="basicName">Базовое имя для функциональности</param>
        /// <param name="bindingName">Имя для привязки к объекту</param>
        /// <param name="isPID">Является ли объект ПИД-регулятором</param>
        /// <param name="luaModuleName">Имя модуля Lua для объекта</param>
        /// <param name="monitorName">Имя объекта Monitor (SCADA)</param>
        /// <param name="deprecated">Устарел объект, или нет</param>
        /// <returns> Базовый объект в экземпляр LUA </returns>
        ILuaBaseTechObject AddBaseObject(string name, string eplanName, int s88Level,
            string basicName, string bindingName, bool isPID, string luaModuleName,
            string monitorName, bool deprecated);
    }

    public class BaseTechObjectManager : IBaseTechObjectManager, ILuaBaseTechObjectManager
    {
        private BaseTechObjectManager() { }

        private static BaseTechObjectManager? instance = null;

        public static BaseTechObjectManager Instance => instance ??= new();


        public List<IBaseTechObject> Objects => throw new NotImplementedException();

        public int GetS88Level(string type)
        {
            throw new NotImplementedException();
        }

        public string GetS88Name(int s88Level)
        {
            throw new NotImplementedException();
        }

        public IBaseTechObject GetTechObjectCopy(string name)
        {
            throw new NotImplementedException();
        }

        ILuaBaseTechObject ILuaBaseTechObjectManager.AddBaseObject(string name,
            string eplanName, int s88Level, string basicName, string bindingName,
            bool isPID, string luaModuleName, string monitorName, bool deprecated)
        {
            var baseObject = new BaseTechObject()
            {

            };

            return baseObject;
        }
    }
}
