using LuaInterface;

namespace PDSystem.LUA
{
    public class LuaManager
    {
        private LuaManager() 
        {
        }

        public static LuaManager Instance => instance ??= new();
        public Lua Lua => lua;


        private Lua lua = new();
        private static LuaManager? instance = null;
    }
}