using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL;

namespace Endless_Sky
{
    public class Shape : IDraw
    {
        readonly int typeOfShip;
        public Shape(int typeOfShip)
        {
            this.typeOfShip = typeOfShip;
        }

        public void draw()
        {
            switch (typeOfShip)
            {
                case 0:
                    GL.Begin(BeginMode.TriangleFan);
                    GL.Color3(1.0, 0.0, 0.0);
                    GL.Vertex2(0, 0);
                    GL.Color3(0.5, 0.5, 0.5);
                    GL.Vertex2(0, 6.0);
                    GL.Vertex2(-4.0, 4.0);
                    GL.Vertex2(-6.0, 0);
                    GL.Vertex2(-4.0, -4.0);
                    GL.Vertex2(0, -6.0);

                    GL.Vertex2(0, 5.0);
                    GL.Vertex2(9.0, 1.0);
                    GL.Vertex2(9.0, -1.0);
                    GL.Vertex2(0, -5.0);
                    GL.End();
                    GL.PopMatrix();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
    }
}
