using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL;

namespace Endless_Sky
{
    public class Player : IDraw
    {
        public readonly Ship ship;
        public readonly bool team;
        public double speedX = 0;
        public double speedY = 0;
        public double coordX = 0;
        public double coordY = 0;
        public double rotateAngel = 0;

        public Player(Ship ship, double coordX, double coordY, double rotateAngel, bool team = true)
        {
            this.ship = ship;
            this.coordX = coordX;
            this.coordY = coordY;
            this.rotateAngel = rotateAngel;
            this.team = team;
        }

        public void draw()
        {
            GL.PushMatrix();
            GL.Translate(coordX, coordY, 0);
            GL.Rotate(rotateAngel, 0, 0, 1);
            ship.draw();

            coordX += speedX;
            coordY += speedY;

            GL.PopMatrix();

            if (team)
            {
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                GL.Ortho(-500.0 + coordX, 500.0 + coordX, -280.0 + coordY, 280.0 + coordY, -1.0, 1.0);
                GL.MatrixMode(MatrixMode.Modelview);
            }
        }
    }
}
