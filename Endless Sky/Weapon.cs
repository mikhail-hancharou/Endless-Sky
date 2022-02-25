using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL;

namespace Endless_Sky
{
    public class Weapon
    {
        public readonly int maxRange;
        public readonly int damagePT;//damage per tick

        public Weapon(int maxRange, int damagePT)
        {
            this.maxRange = maxRange;
            this.damagePT = damagePT;
        }

        public void tracer()
        {
            GL.Begin(BeginMode.Lines);
            GL.LineWidth(2);
            GL.Color3(1.0, 0.274, 0.0);
            GL.Vertex2(0, 1);
            GL.Vertex2(maxRange, 0);
            GL.Vertex2(0, -1);
            GL.Vertex2(maxRange, 0);
            GL.End();
        }
    }
}
