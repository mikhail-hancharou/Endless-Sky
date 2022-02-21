using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Endless_Sky
{
    class Game
    {
        GameWindow window;
        Ship myShip = new Ship(3, 4, 0.3, 350, 0, 90, 350, true);
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
                //myShip.rotateAngel %= 360;
                myShip.speedX += Math.Cos(myShip.rotateAngel * Math.PI / 180) * myShip.maxSpeedStep;
                myShip.speedY += Math.Sin(myShip.rotateAngel * Math.PI / 180) * myShip.maxSpeedStep;

                myShip.speedX %= myShip.maxSpeed;
                myShip.speedY %= myShip.maxSpeed;

                double spX = Math.Pow(myShip.speedX, 2.0);
                double spY = Math.Pow(myShip.speedY, 2.0);
                double spMax = Math.Pow(myShip.maxSpeed, 2.0);

                if (spX + spY > spMax)
                {
                    myShip.speedX -= (Math.Sqrt(spX + spY - spMax) * myShip.speedX) / (Math.Abs(myShip.speedX) + Math.Abs(myShip.speedY));
                    myShip.speedY -= (Math.Sqrt(spX + spY - spMax) * myShip.speedY) / (Math.Abs(myShip.speedX) + Math.Abs(myShip.speedY));
                    Console.WriteLine(myShip.rotateAngel / 180);
                    Console.WriteLine("{0} - {1}", myShip.speedX, myShip.speedY);
                }
            }
        }

        void updateF(object o, EventArgs e)
        {

        }

        double tmp = -500.0;
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
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();

            draw.drawSpace(myShip);
            GL.Translate(myShip.coordX, myShip.coordY, 0);
            draw.drawShip(myShip);

            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-500.0 + myShip.coordX, 500.0 + myShip.coordX, -280.0 + myShip.coordY, 280.0 + +myShip.coordY, -1.0, 1.0);
            GL.MatrixMode(MatrixMode.Modelview);

            GL.PointSize(8);
            GL.Begin(BeginMode.Points);
            GL.Vertex2(0, 0);
            GL.End();

            window.SwapBuffers();
        }
    }
}
