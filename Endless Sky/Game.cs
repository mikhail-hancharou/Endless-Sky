using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Endless_Sky
{
    class Game
    {
        GameWindow window;
        Ship myShip = new Ship(50, 4, 1.0, 350, 0, 90, 350, true);
        //Space space = new Space();
        Draw draw = new Draw();
        float temp = 0;
        public Game(GameWindow window)
        {
            this.window = window;
            Start();
        }

        void Start()
        {
            window.Load += loaded;
            window.RenderFrame += renderF;
            window.UpdateFrame += updateF;
            window.KeyPress += keyPress;
            window.Resize += resize;
            window.Run(1.0 / 60.0);
        }
        void keyPress(object o, KeyPressEventArgs e)
        {
            Console.WriteLine("Key {0} - {1}", e.KeyChar, o);
            Console.WriteLine(myShip.rotateAngel);
            if (e.KeyChar == 'a')
            {
                myShip.rotateAngel += myShip.maxRotateStep;
            }
            else if (e.KeyChar == 'd')
            {
                myShip.rotateAngel -= myShip.maxRotateStep;
            }
            else if (e.KeyChar == 'w')
            {
                myShip.rotateAngel %= 360;
                Console.WriteLine(myShip.rotateAngel / 180);
                myShip.speedX += Math.Cos(myShip.rotateAngel * Math.PI / 180) * myShip.maxSpeedStep;
                myShip.speedY += Math.Sin(myShip.rotateAngel * Math.PI / 180) * myShip.maxSpeedStep;
                Console.WriteLine("{0} - {1}", myShip.speedX, myShip.speedY);
            }
        }

        void updateF(object o, EventArgs e)
        {

        }

        void resize(object o, EventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-500.0, 500.0, -280.0, 280.0, -1.0, 1.0);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        void loaded(object o, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }

        void renderF(object o, EventArgs e)
        {
            //GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.PushMatrix();

            GL.PopMatrix();

            draw.drawSpace(myShip);
            draw.drawShip(myShip);

            GL.Translate(myShip.speedX, 0.0, 0.0);
            GL.Translate(0.0, myShip.speedY, 0.0);

            //GL.LoadIdentity();
            //GL.Begin(BeginMode.Points);
            //GL.PointSize(10);
            //GL.Vertex2(0.0, temp++);
            //GL.End();
            //GL.PopMatrix();
            window.SwapBuffers();
        }
    }
}
