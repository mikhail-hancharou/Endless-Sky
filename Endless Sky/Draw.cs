using System;
using System.Collections.Generic;
using System.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Endless_Sky
{
    public class Draw
    {
        public Draw() { }

        public void drawSpace(Ship myShip)
        {
            GL.Begin(BeginMode.Lines);
            for (int i = -2500; i < 2500; i += 50)
            {
                GL.Vertex2(i, 2500);
                GL.Vertex2(i, -2500);
                GL.Vertex2(2500, i);
                GL.Vertex2(-2500, i);
            }
            GL.End();
        }

        public void drawShip(Ship myShip)
        {
            GL.PushMatrix();
            GL.Translate(myShip.coordX, myShip.coordY, 0);
            GL.Rotate(myShip.rotateAngel, 0, 0, 1);
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

            myShip.coordX += myShip.speedX;
            myShip.coordY += myShip.speedY;
            /*
            GL.PushMatrix();

            GL.Rotate(myShip.rotateAngel, 0, 0, 1);
            GL.Begin(BeginMode.TriangleFan);
                GL.Color3(1.0, 0.0, 0.0);
                GL.Vertex2(myShip.coordX, myShip.coordY);
                GL.Color3(0.5, 0.5, 0.5);
                GL.Vertex2(myShip.coordX, myShip.coordY + 6.0);
                GL.Vertex2(myShip.coordX - 4.0, myShip.coordY + 4.0);
                GL.Vertex2(myShip.coordX - 6.0, myShip.coordY);
                GL.Vertex2(myShip.coordX - 4.0, myShip.coordY - 4.0);
                GL.Vertex2(myShip.coordX, myShip.coordY - 6.0);

                GL.Vertex2(myShip.coordX, myShip.coordY + 5.0);
                GL.Vertex2(myShip.coordX + 9.0, myShip.coordY + 1.0);
                GL.Vertex2(myShip.coordX + 9.0, myShip.coordY - 1.0);
                GL.Vertex2(myShip.coordX, myShip.coordY - 5.0);
            GL.End();
            GL.PopMatrix();

            myShip.coordX += myShip.speedX;
            myShip.coordY += myShip.speedY;
            //GL.Color3(1.0, 0.0, 0.0);
            //GL.Vertex2(0.0, 0.0);
            //GL.Color3(0.5, 0.5, 0.5);
            //GL.Vertex2(-6.0, 0.0);
            //GL.Vertex2(-4.0, -4.0);
            //GL.Vertex2(0.0, -6.0);
            //GL.Vertex2(4.0, -4.0);
            //GL.Vertex2(6.0, 0.0);
            //
            //GL.Vertex2(-5.0, 0.0);
            //GL.Vertex2(-1.0, 9.0);
            //GL.Vertex2(1.0, 9.0);
            //GL.Vertex2(5.0, 0.0);
            */
        }
    }
}
