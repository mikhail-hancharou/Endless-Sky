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
        private double deltaX;
        private double deltaY;
        private double hypotenuse;
        public EnemySpawner(Controls control, bool spawn)
        {
            this.control = control;
            if (spawn)
            {
                Weapon gun = new Weapon(130, 2);
                int maxSpeed = 2;
                int maxRotateStep = 3;
                double maxSpeedStep = 0.3;
                int maxHP = 350;
                int maxShield = 0;
                int hp = 350;
                int coordX = 50;
                int coordY = -50;
                for (int i = 1; i <= maxAmount; i++)
                {
                    int shape = i;

                    Player player = new Player(new Ship(shape, gun, maxSpeed++, maxRotateStep++,
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
                    deltaX = superPlayer.coordX - p.coordX;
                    deltaY = superPlayer.coordY - p.coordY;
                    hypotenuse = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
                    //needToTurn(p);
                    needToMove(p, superPlayer, needToTurn(p));
                }
            }
        }

        public double needToTurn(Player p)
        {
            double angle = Math.Abs(Math.Asin(deltaY / hypotenuse));
            angle = normalizeAngle(angle, deltaX, deltaY);

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

            return angle;
        }

        public void needToMove(Player p, Player superP, double angle)
        { 
            hypotenuse = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
            if (p.ship.gun.maxRange < hypotenuse)
            {
                control.up(p);
            }
            else
            {
                if (Math.Abs(angle) < 15)
                {
                    control.shoot(p); //angle between two angels should be less then 15 to start shooting
                }

                double angleSP = speedAngle(superP);
                double angleP = speedAngle(p);
                double temp = Math.Abs(angleSP - angleP);
                angle = temp < 180 ? temp : 360 - temp;
                if (angle > 45)
                {
                    control.reduce(p);
                    Console.WriteLine("reduse {0}", p.ship.shape);
                }
            }
        }

        private double speedAngle(Player p)
        {
            hypotenuse = Math.Sqrt(Math.Pow(p.speedX, 2) + Math.Pow(p.speedY, 2));
            double angle = Math.Abs(Math.Asin(p.speedY / hypotenuse));
            angle = normalizeAngle(angle, p.speedX, p.speedY);
            return angle;
        }

        private double normalizeAngle(double angle, double X, double Y)
        {
            angle = (angle / Math.PI) * 180;

            if (X < 0 && Y < 0)
            {
                angle += 180;
            }
            else if (X < 0 && Y > 0)
            {
                angle = 180 - angle;
            }
            else if (X > 0 && Y < 0)
            {
                angle = 360 - angle;
            }

            return angle;
        }
    }
}
