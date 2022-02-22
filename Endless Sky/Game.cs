using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

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
        EnemySpawner spawn = new EnemySpawner(true);
        int time = 0;
        int upTime = 0;

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
            //Console.WriteLine("Key {0}", e.KeyChar);
            //Console.WriteLine(me.rotateAngel);
            //if (e.KeyChar == 'a')
            //{
            //    control.turnLeft(me);
            //}
            //if (e.KeyChar == 'd')
            //{
            //    control.turnRight(me);
            //}
            //if (e.KeyChar == 'w')
            //{
            //    control.up(me);
            //}
            //if (e.KeyChar == ' ')
            //{
            //    control.reduce(me);
            //}
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

        void updateF(object o, EventArgs e)
        {
            ++upTime;
            if (upTime == 60)
            {
                upTime = 0;
                time++;
                Console.WriteLine("-----update----- {0}", time);
            }

            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Key.W))
            {
                control.up(me);
            }
            if (keyState.IsKeyDown(Key.A))
            {
                control.turnLeft(me);
            }
            if (keyState.IsKeyDown(Key.D))
            {
                control.turnRight(me);
            }
            if (keyState.IsKeyDown(Key.Space))
            {
                control.reduce(me);
            }
        }

        void renderF(object o, EventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();

            draw.drawAll(space, me, spawn);

            window.SwapBuffers();
        }
    }
}
