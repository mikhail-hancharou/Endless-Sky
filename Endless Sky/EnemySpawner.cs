using System;
using System.Collections.Generic;
using System.Text;

namespace Endless_Sky
{
    public class EnemySpawner : IDraw
    {
        const int maxAmount = 3;
        public int currentAmount = 0;
        public List<Player> enemies = new List<Player>();
        private Controls control;
        public EnemySpawner(Controls control, bool spawn)
        {
            this.control = control;
            if (spawn)
            {
                int maxSpeed = 3;
                int maxRotateStep = 4;
                double maxSpeedStep = 0.3;
                int maxHP = 350;
                int maxShield = 0;
                int hp = 350;
                int coordX = 50;
                int coordY = -50;
                for (int i = 1; i <= maxAmount; i++)
                {
                    int shape = i;

                    Player player = new Player(new Ship(shape, maxSpeed, maxRotateStep,
                        maxSpeedStep, maxHP, maxShield, hp), coordX, coordY, 90, false);
                    coordY += 50;

                    enemies.Add(player);
                }
            }
        }

        public void draw()
        {
            foreach (Player p in enemies)
            {
                p.draw();
            }
        }

        public void enemyIntelligence(Player superPlayer)
        {
            foreach (Player p in enemies)
            {
                if (!p.team)
                {
                    needToTurn(p, superPlayer);
                }
            }
        }

        public void needToTurn(Player p, Player superP)
        {
            Console.WriteLine($"{superP.coordX} --- {superP.coordY}");
            double deltaX = superP.coordX - p.coordX;
            double deltaY = superP.coordY - p.coordY;
            //double hypotenuse = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
            double angle = Math.Abs(Math.Atan(deltaY / deltaX));
            angle = (angle / Math.PI) * 180;

            if (deltaX < 0 && deltaY < 0)
            {
                angle += 180;
            }
            else if (deltaX < 0 && deltaY > 0)
            {
                angle = 180 - angle;
            }
            else if (deltaX > 0 && deltaY < 0)
            {
                angle = 360 - angle;
            }

            double temp = p.rotateAngel % 360;

            angle -= temp < 0 ? 360 + temp : temp;

            if ((angle > 0 && angle < 180) || angle < -180)
            {
                control.turnLeft(p);
            }
            else
            {
                control.turnRight(p);
            }
        }

        public void needToMove(Player p, Player superP)
        {

        }
    }
}
