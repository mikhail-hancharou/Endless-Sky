using System;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Endless_Sky
{
    public class Space : IDraw
    {
        readonly int Cell = 60;
        readonly Player SuperPl;
        readonly EnemySpawner Enemies;
        public Space() { }

        public Space(Player SuperPl, EnemySpawner enemies) 
        {
            this.SuperPl = SuperPl;
            Enemies = enemies;
        }


        public void draw()
        {
            double XUp, YUp;
            XUp = SuperPl.coordX % Cell;
            YUp = SuperPl.coordY % Cell;


            GL.PushMatrix();
            GL.Translate(SuperPl.coordX, SuperPl.coordY, 0);

            for (int i = -550; i <= 550; i += Cell)
            {
                GL.Begin(BeginMode.Lines);
                GL.Vertex2(i - XUp, 550);
                GL.Vertex2(i - XUp, -550);
                GL.Vertex2(550, i - YUp);
                GL.Vertex2(-550, i - YUp);
                GL.End();
            }

            GL.LineWidth(3.5f);
            GL.Begin(BeginMode.Lines);
            GL.Color3(Color.Red);
            GL.Vertex2(-200, -260);
            GL.Vertex2(-200 + (SuperPl.ship.hp / SuperPl.ship.maxHP) * 400, -260);
            int temp = 0;
            foreach (Player p in Enemies.enemies)
            {
                GL.Vertex2(400, 260 - temp);
                GL.Vertex2(400 + (p.ship.hp / p.ship.maxHP) * 80, 260 - temp);
                temp += 20;
            }
            GL.End();

            GL.PopMatrix();
            GL.LineWidth(1f);
        }
    }
}
