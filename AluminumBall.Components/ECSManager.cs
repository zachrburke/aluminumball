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
    }
}
