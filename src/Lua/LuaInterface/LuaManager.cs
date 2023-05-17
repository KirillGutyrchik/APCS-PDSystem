using LuaInterface;
using System.Reflection;

namespace PDSystem.LUA
{
    public class LuaManager
    {
        private LuaManager() 
        {
        }

        public static string LuaDirectory => luaDirectory;


        public static LuaManager Instance => instance ??= new();
        public Lua Lua => lua;


        private Lua lua = new();
        private static LuaManager? instance = null;
        private static string luaDirectory = 
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "", "Lua");
    }
}