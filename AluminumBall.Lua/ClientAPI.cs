using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AluminumBall.Lua
{
    public class ClientAPI
    {
        public Color BallColor { get; set; }
        public Color ClearColor { get; set; }

        public Vector2 Trajectory { get; set; }

        private dynamic _lua;

        public ClientAPI(string scriptPath)
        {
            ClearColor = Color.SkyBlue;
            BallColor = Color.White;
            Trajectory = Vector2.Zero;

            _lua = new DynamicLua.DynamicLua();
            _lua.SetBallColor = new Action<double, double, double>(SetBallColor);
            _lua.SetClearColor = new Action<double, double, double>(SetClearcolor);
            _lua.ChangeTrajectory = new Action<double, double>(ChangeTrajectory);

            _lua.DoFile(scriptPath);
        }

        private void SetBallColor(double red, double green, double blue)
        {
            BallColor = new Color((int)red, (int)green, (int)blue);
        }

        private void SetClearcolor(double red, double green, double blue)
        {
            ClearColor = new Color((int)red, (int)green, (int)blue);
        }

        private void ChangeTrajectory(double x, double y)
        {
            Trajectory = new Vector2((float) x, (float) y);
        }

        public void Run(double ticks)
        {
            if (_lua.Run != null)
                _lua.Run(ticks);
        }
    }

    
}
