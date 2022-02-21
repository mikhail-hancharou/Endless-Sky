using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Endless_Sky
{
    public class Space
    {
        //GameWindow window;
        //public Space(GameWindow window)
        //{
        //    this.window = window;
        //}

        public Space() { }

        public void drawSpace(Ship myShip)
        {
            for (int i = -2500; i < 2500; i += 50)
            {
                GL.Begin(BeginMode.Lines);
                GL.Vertex2(i, 2500);
                GL.Vertex2(i, -2500);
                GL.Vertex2(2500, i);
                GL.Vertex2(-2500, i);
                GL.End();
            }           

            //GL.PushMatrix();
            //GL.Translate(-1.0 / 280 * myShip.speedX, 0.0, 0.0);
            //GL.Translate(0.0, -1.0 / 280 * myShip.speedY, 0.0);

            
            //GL.PopMatrix();
        }
    }
}
