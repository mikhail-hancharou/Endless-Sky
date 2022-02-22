using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Endless_Sky
{
    class Game
    {
        public GameWindow window;
        Ship myShip = new Ship(0, 3, 4, 0.3, 350, 0, 350);
        Player me = new Player(new Ship(0, 3, 4, 0.3, 350, 0, 350), 0, 0, 90, true);
        Space space = new Space();
        Draw draw = new Draw();
        Controls control = new Controls();

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
            Console.WriteLine("Key {0}", e.KeyChar);
            Console.WriteLine(me.rotateAngel);
            if (e.KeyChar == 'a')
            {
                control.turnLeft(me);
            }
            else if (e.KeyChar == 'd')
            {
                control.turnRight(me);
            }
            else if (e.KeyChar == 'w')
            {
                control.up(me);
            }
            else if (e.KeyChar == ' ')
            {
                control.reduce(me);
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
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();

            //draw.TestDraw(space);
            //draw.TestDraw(me);
            draw.drawAll(space, me);

            window.SwapBuffers();
        }
    }
}
