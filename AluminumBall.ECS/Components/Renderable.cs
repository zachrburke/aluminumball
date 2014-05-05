using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AluminumBall.Components
{
    public class Renderable : IComponent
    {
        public string TexName { get; set; }

        public Renderable(string name)
        {
            TexName = name;
        }

        public string GetName()
        {
            return "Renderable";
        }
    }
}
