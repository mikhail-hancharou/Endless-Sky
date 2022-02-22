using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Endless_Sky
{
    public class Space : IDraw
    {
        public Space() { }

        public void draw()
        {
            for (int i = -2500; i < 2500; i += 50)
            {
                GL.Begin(BeginMode.Lines);
                GL.Vertex2(i, 2500);
                GL.Vertex2(i, -2500);
                GL.Vertex2(2500, i);
                GL.Vertex2(-2500, i);
                GL.End();

                GL.PointSize(8);
                GL.Begin(BeginMode.Points);
                GL.Vertex2(0, 0);
                GL.End();
            }
        }
    }
}
