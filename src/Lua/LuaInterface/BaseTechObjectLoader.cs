using LuaInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using PDSystem.TechObject;
using System.Reflection;

namespace PDSystem.LUA
{
    public interface IBaseTechObjectsLoader
    {
        
    }

    /// <summary>
    /// Загрузчик описания базовых объектов
    /// </summary>
    public class BaseTechObjectLoader : IBaseTechObjectsLoader
    {
        /// <summary>
        /// 
        /// </summary>
        private static string DefaultFileName = "DescriptionTemplate.lua";
        
        private static string DefaultDirName = "BaseObjectsDescriptionFiles";
        
        /// <summary>
        /// Название файла с Lua для инициализации базовых объектов;
        /// </summary>
        private static string BaseObjectsInitializerFileName = "sys_base_objects_initializer.lua";

        /// <summary>
        /// Название объекта LuaBasetechObjectManager в Lua
        /// </summary>
        private static string BaseTechObjectManagerLuaName = "BaseTechObjectManager";

        /// <summary>
        /// Название объекта ProjectDescriptionSaver
        /// </summary>
        private static string ProjectDescriptionSaver = "ProjectDescriptionSaver";

        public BaseTechObjectLoader()
        {
            lua = new Lua();
            string pathToFile = Path.Combine(LuaManager.LuaDirectory, BaseObjectsInitializerFileName);
            lua.DoFile(pathToFile);
           
            lua[BaseTechObjectManagerLuaName] = LuaBaseTechObjectManger.Instance;
            lua[ProjectDescriptionSaver] = LuaProjectdescriptionSaver.Instance;
        }

        /// <summary>
        /// Загрузка базовых объектов из их файлов описания
        /// </summary>
        private void LoadBaseTechObjectsFromDescription()
        {
            InitBaseTechObjectsInitializer();

            string pathToDir = Path.Combine(LuaManager.LuaDirectory, DefaultDirName);
            IList<string> fileNames = GetDescriptionFilesNames(pathToDir);
            if (fileNames.Count > 0)
            {
                foreach(var fileName in fileNames)
                {
                    string descriptionFilePath = Path.Combine(pathToDir,
                        fileName);
                    string description = LoadBaseTechObjectsDescription(
                        descriptionFilePath);
                    InitBaseObjectsFromLuaScript(description);
                }
            }
            else
            {
                WriteDefaultObjectsDescriptionTemplate(pathToDir);
                MessageBox.Show("Файлы с описанием базовых объектов не " +
                    "найдены. Будет создан пустой файл с шаблоном описания. " +
                    $"Путь к каталогу: {pathToDir}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Инициализация читателя базовых объектов.
        /// </summary>
        private void InitBaseTechObjectsInitializer()
        {
           
        }

        /// <summary>
        /// Получить имена файлов с описанием объектов
        /// </summary>
        /// <param name="pathToCatalog">Путь к каталогу с файлами</param>
        /// <returns></returns>
        private string[] GetDescriptionFilesNames(string pathToCatalog)
        {
            if (Directory.Exists(pathToCatalog))
            {
                return Directory.GetFiles(pathToCatalog);
            }
            else
            {
                Directory.CreateDirectory(pathToCatalog);
                return new string[0];
            }
        }

        /// <summary>
        /// Загрузить описание базовых объектов из файла
        /// </summary>
        /// <param name="pathToFile">Путь к файлу с базовыми объектами</param>
        /// <returns>Описание</returns>
        private string LoadBaseTechObjectsDescription(string pathToFile)
        {
            using (var reader = new StreamReader(pathToFile,
                EncodingDetector.DetectFileEncoding(pathToFile)))
            {
                string readedDescription = reader.ReadToEnd();
                return readedDescription;
            }
        }

        /// <summary>
        /// Инициализация загруженных базовых объектов через Lua
        /// </summary>
        /// <param name="luaString">Скрипт с описанием</param>
        private void InitBaseObjectsFromLuaScript(string luaString)
        {
            lua.DoString("base_tech_objects = nil");
            bool scriptLoaded = LoadBaseObjectsDescriptionToLua(luaString);
            if (scriptLoaded)
            {
                InitBaseObjectsDescription();
            }
        }

        /// <summary>
        /// Загрузка скрипта с базовыми объектами с экземпляр Lua
        /// </summary>
        /// <param name="descriptionScript">Скрипт с описанием</param>
        /// <returns></returns>
        private bool LoadBaseObjectsDescriptionToLua(string descriptionScript)
        {
            try
            {
                lua.DoString(descriptionScript);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ". Исправьте скрипт вручную.",
                    "Ошибка обработки Lua-скрипта с описанием " +
                    "базовых объектов.");
                return false;
            }
        }

        /// <summary>
        /// Инициализация загруженных базовых объектов из Lua
        /// </summary>
        private void InitBaseObjectsDescription()
        {
            try
            {
                string script = "if init_base_objects ~= nil " +
                    "then init_base_objects() end";
                lua.DoString(script);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обработки Lua-скрипта с " +
                    " инициализацией базовых объектов: " + ex.Message + ".\n" +
                    "Source: " + ex.Source);
            }
        }

        /// <summary>
        /// Записать стандартный файл описания.
        /// </summary>
        /// <param name="pathToDir">Путь к каталогу, где хранятся
        /// файлы описания</param>
        private void WriteDefaultObjectsDescriptionTemplate(string pathToDir)
        {
            throw new NotImplementedException();
            //string templateDescriptionFilePath = Path.Combine(pathToDir,
            //    defaultFileName);
            //string template = EasyEPlanner.Properties.Resources
            //    .ResourceManager
            //    .GetString("SysBaseObjectsDescriptionPattern");
            //File.WriteAllText(templateDescriptionFilePath, template,
            //    EncodingDetector.UTF8);
        }
        
        private Lua lua;
    }

    public class LuaBaseTechObjectManger
    {
        private LuaBaseTechObjectManger() { }

        private static LuaBaseTechObjectManger? instance = null;

        public static LuaBaseTechObjectManger Instance => instance ??= new();

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
        /// <returns>Базовый объект в экземпляр LUA</returns>
        LuaBaseTechObject AddBaseObject(string name, string eplanName,
            int s88Level, string basicName, string bindingName, bool isPID,
            string luaModuleName, string monitorName, bool deprecated)
        {
            return new LuaBaseTechObject(baseTechObjectManager.AddBaseObject(
            name, eplanName, s88Level, basicName, bindingName,
                isPID, luaModuleName, monitorName, deprecated));
        }

        IBaseTechObjectManager baseTechObjectManager = BaseTechObjectManger.Instance;
    }

    public class LuaBaseTechObject
    {
        private IBaseTechObject baseTechObject;

        public LuaBaseTechObject(IBaseTechObject baseTechObject)
        {
            this.baseTechObject = baseTechObject;
        }
        
        /// <summary>
        /// Добавить группу объектов
        /// </summary>
        public void AddObjectGroup(string luaName, string name, string allowedObjects)
        {
            baseTechObject.AddObjectGroup(luaName, name, allowedObjects);
        }

        /// <summary>
        /// Добавить базовую операцию
        /// </summary>
        public LuaBaseOperation AddBaseOperation(string luaName, string name, int defaultPosition)
        {
            return new LuaBaseOperation(
                baseTechObject.AddBaseOperation(luaName, name, defaultPosition));
        }

        /// <summary>
        /// Добавить оборудование 
        /// </summary>
        public void AddEquipment(string luaName, string name, string defaultValue)
        {

        }
        
        /// <summary>
        /// Добавить активный параметр агрегата
        /// </summary>
        public void AddActiveParameter(string luaName, string name, string defaultValue)
        {

        }

        /// <summary>
        /// Добавить булевый параметр агрегата
        /// </summary>
        public void AddActiveBoolParameter(string luaName, string name, string defaultValue)
        {

        }

        /// <summary>
        /// Добавить основной параметр агрегата
        /// </summary>
        public void AddMainAggregateParameter(string luaName, string name, string defaultValue)
        {

        }

        /// <summary>
        /// Добавить системный параметр объекта
        /// </summary>
        public void AddSystemParameter(string luaName, string name, double defaultValue, string meter)
        {

        }

        /// <summary>
        /// Добавить float параметр объекта
        /// </summary>
        public void AddFloatParameter(string luaName, string name, double value, string meter)
        {

        }

        /// <summary>
        /// Добавить float runtime параметр
        /// </summary>
        public void AddFloatRuntimeParameter(string luaName, string name, double valuem, string meter)
        {

        }
    }

    public class LuaBaseOperation
    {
        private IBaseOperation baseOperation;

        public LuaBaseOperation(IBaseOperation baseOperation) 
        {
            this.baseOperation = baseOperation;
        }

        public void AddActiveParameter(string luaName, string name, string defaultValue)
        {

        }

        public void AddActiveBoolParameter()
        {

        }
    }

    public class LuaProjectdescriptionSaver
    {
        private LuaProjectdescriptionSaver() { }

        private static LuaProjectdescriptionSaver? instance = null;

        public static LuaProjectdescriptionSaver Instance => instance ??= new();

        public void AddPackage(string package)
        {
            //ProjectDescriptionSaver.AddPackage(package);
        }
    }
}


 