using PDSystem.LUA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDSystem.TechObject
{
    public interface IBaseTechObject
    {

    }

    /// <summary>
    /// Методы вызываемые из LUA
    /// </summary>
    public interface ILuaBaseTechObject
    {
        /// <summary>
        /// Добавить группу объектов
        /// </summary>
        void AddObjectGroup(string luaName, string name, string allowedObjects);

        /// <summary>
        /// Добавить базовую операцию
        /// </summary>
        ILuaBaseOperation AddBaseOperation(string luaName, string name, int defaultPosition);

        /// <summary>
        /// Добавить оборудование 
        /// </summary>
        void AddEquipment(string luaName, string name, string defaultValue);

        /// <summary>
        /// Добавить активный параметр агрегата
        /// </summary>
        void AddActiveParameter(string luaName, string name, string defaultValue);

        /// <summary>
        /// Добавить булевый параметр агрегата
        /// </summary>
        void AddActiveBoolParameter(string luaName, string name, string defaultValue);

        /// <summary>
        /// Добавить основной параметр агрегата
        /// </summary>
        void AddMainAggregateParameter(string luaName, string name, string defaultValue);

        /// <summary>
        /// Добавить системный параметр объекта
        /// </summary>
        void AddSystemParameter(string luaName, string name, double defaultValue, string meter);

        /// <summary>
        /// Добавить float параметр объекта
        /// </summary>
        void AddFloatParameter(string luaName, string name, double value, string meter);

        /// <summary>
        /// Добавить float runtime параметр
        /// </summary>
        void AddFloatRuntimeParameter(string luaName, string name, double valuem, string meter);
    }

    public class BaseTechObject : IBaseTechObject, ILuaBaseTechObject
    {
        #region ILuaBaseTechObject
        void ILuaBaseTechObject.AddActiveBoolParameter(string luaName, string name, string defaultValue)
        {
            throw new NotImplementedException();
        }

        void ILuaBaseTechObject.AddActiveParameter(string luaName, string name, string defaultValue)
        {
            throw new NotImplementedException();
        }

        ILuaBaseOperation ILuaBaseTechObject.AddBaseOperation(string luaName, string name, int defaultPosition)
        {
            throw new NotImplementedException();
        }

        void ILuaBaseTechObject.AddEquipment(string luaName, string name, string defaultValue)
        {
            throw new NotImplementedException();
        }

        void ILuaBaseTechObject.AddFloatParameter(string luaName, string name, double value, string meter)
        {
            throw new NotImplementedException();
        }

        void ILuaBaseTechObject.AddFloatRuntimeParameter(string luaName, string name, double valuem, string meter)
        {
            throw new NotImplementedException();
        }

        void ILuaBaseTechObject.AddMainAggregateParameter(string luaName, string name, string defaultValue)
        {
            throw new NotImplementedException();
        }

        void ILuaBaseTechObject.AddObjectGroup(string luaName, string name, string allowedObjects)
        {
            throw new NotImplementedException();
        }

        void ILuaBaseTechObject.AddSystemParameter(string luaName, string name, double defaultValue, string meter)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}