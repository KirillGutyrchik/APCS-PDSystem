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
           
            lua[BaseTechObjectManagerLuaName] = BaseTechObjectManager.Instance;
            //lua[ProjectDescriptionSaver] = LuaProjectdescriptionSaver.Instance;
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
}


 