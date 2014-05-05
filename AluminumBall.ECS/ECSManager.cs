using AluminumBall.Lua;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AluminumBall.ECS
{
    public class ECSManager
    {
        public static List<ILogicSystem> LogicSystems { get; set; }
        public static List<IGraphicSystem> GraphicSystems { get; set; }

        public static Dictionary<string, Texture2D> Textures { get; set; }

        public static ClientAPI ClientAPI { get; set; }

        private const string LuaMainPath = "Lua/script.lua";

        static ECSManager()
        {
            LogicSystems = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && t.GetInterface("ILogicSystem") != null)
                .Select(t => (ILogicSystem) Activator.CreateInstance(t)).ToList();

            GraphicSystems = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && t.GetInterface("IGraphicSystem") != null)
                .Select(t => (IGraphicSystem)Activator.CreateInstance(t)).ToList();

            Textures = new Dictionary<string, Texture2D>();
        }

        public static void InitClientAPI() 
        {
            ClientAPI = new ClientAPI(LuaMainPath);
        }

        public static Color GetClearColor()
        {
            return ClientAPI.ClearColor;
        }

        public static void Run(GameTime gameTime)
        {
            ClientAPI.Run(gameTime.ElapsedGameTime.Milliseconds);
        }
    }
}
