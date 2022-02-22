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
                        GL.Color3(0.0, 0.0, 1.0);
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
                    break;
                case 1:
                    GL.Begin(BeginMode.TriangleFan);
                        GL.Color3(1.0, 0.0, 0.0);
                        GL.Vertex2(0, 0);
                        GL.Color3(0.5, 0.5, 0.5);
                        GL.Vertex2(0, 7.0);
                        GL.Vertex2(-5.0, 5.0);
                        GL.Vertex2(-7.0, 0);
                        GL.Vertex2(-5.0, -5.0);
                        GL.Vertex2(0, -7.0);

                        GL.Vertex2(0, 6.0);
                        GL.Vertex2(12.0, 5.0);
                        GL.Vertex2(12.0, 2.0);
                        //GL.Vertex2(12.0, -2.0);
                        //GL.Vertex2(12.0, -5.0);
                        //GL.Vertex2(0, -6.0);
                    GL.End();

                    GL.Begin(BeginMode.TriangleFan);
                        GL.Color3(1.0, 0.0, 0.0);
                        GL.Vertex2(0, 0);
                        GL.Color3(0.5, 0.5, 0.5);
                        GL.Vertex2(0, -6.0);
                        GL.Vertex2(12.0, -5.0);
                        GL.Vertex2(12.0, -2.0);                      
                    GL.End();
                    break;
                case 2:
                    GL.Begin(BeginMode.TriangleFan);
                    GL.Color3(1.0, 0.0, 0.0);
                    GL.Vertex2(0, 0);
                    GL.Color3(0.5, 0.5, 0.5);
                    GL.Vertex2(0, 5.0);
                    GL.Vertex2(-5, 7.0);
                    GL.Vertex2(-4, 4.0);

                    GL.Vertex2(0, 5.0);
                    GL.Vertex2(10.0, 2.0);
                    GL.Vertex2(8.0, 0.0);
                    GL.End();

                    GL.Begin(BeginMode.TriangleFan);
                    GL.Color3(1.0, 0.0, 0.0);
                    GL.Vertex2(0, 0);
                    GL.Color3(0.5, 0.5, 0.5);
                    GL.Vertex2(0, -5.0);
                    GL.Vertex2(-5, -7.0);
                    GL.Vertex2(-4, -4.0);

                    GL.Vertex2(0, -5.0);
                    GL.Vertex2(10.0, -2.0);
                    GL.Vertex2(8.0, 0.0);
                    GL.End();
                    break;
                case 3:
                    GL.Begin(BeginMode.TriangleFan);
                    GL.Color3(1.0, 0.0, 0.0);
                    GL.Vertex2(0, 0);
                    GL.Color3(0.5, 0.5, 0.5);
                    GL.Vertex2(-2, 8.0);
                    GL.Vertex2(-5, 8.0);
                    GL.End();

                    GL.Begin(BeginMode.TriangleFan);
                    GL.Color3(1.0, 0.0, 0.0);
                    GL.Vertex2(0, 0);
                    GL.Color3(0.5, 0.5, 0.5);
                    GL.Vertex2(-2, -8.0);
                    GL.Vertex2(-5, -8.0);
                    GL.End();

                    GL.Begin(BeginMode.TriangleFan);
                    GL.Color3(1.0, 0.0, 0.0);
                    GL.Vertex2(0, 0);
                    GL.Color3(0.5, 0.5, 0.5);
                    GL.Vertex2(-2, 3.0);
                    GL.Vertex2(8, 1.0);
                    GL.Vertex2(8, -1.0);
                    GL.Vertex2(-2, -3.0);
                    GL.Vertex2(-4, 0.0);
                    GL.Vertex2(-2, 3.0);
                    GL.End();
                    break;
                default:
                    break;
            }
        }
    }
}
