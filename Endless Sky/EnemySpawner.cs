using System;
using System.Collections.Generic;
using System.Text;

namespace Endless_Sky
{
    public class EnemySpawner : IDraw
    {
        const int maxAmount = 5;
        public int currentAmount = 0;
        public List<Player> enemies = new List<Player>();
        private Controls control;
        private double deltaX;
        private double deltaY;
        private double hypotenuse;
        private Player superPlayer;
        private EnemyIntelligence enemyIntelligence;
        public EnemySpawner(Controls control, Player superPlayer, bool spawn)
        {
            this.superPlayer = superPlayer;
            this.control = control;
            if (spawn)
            {
                int maxSpeed = 2;
                int maxRotateStep = 2;
                double maxSpeedStep = 0.3;
                int maxHP = 350;
                int maxShield = 0;
                int hp = 350;
                int coordX = 50;
                int coordY = -50;
                for (int i = 1; i <= 3; i++)
                {
                    int shape = i;

                    Player player = new Player(new Ship(shape, new Weapon(130, 0.2), maxSpeed++, maxRotateStep++,
                        maxSpeedStep, maxHP, maxShield, hp), coordX, coordY, 90, false);
                    coordY += 50;

                    //enemies.Add(player);
                }

                enemyIntelligence = new EnemyIntelligence(control, superPlayer, enemies);
            }
        }

        public void draw()
        {
            foreach (Player p in enemies)
            {
                p.draw();
            }
        }

        private void Spawn()
        {
            Random rnd = new Random();
            int temp = rnd.Next(86);
            temp += (int)Math.Pow((maxAmount - enemies.Count + 1), 2);
            if (temp >= 90 && rnd.Next(100) > 95)
            {
                double maxSpeed = 1.5 + rnd.NextDouble();
                double maxRotateStep = 2 + rnd.NextDouble() * 2;
                double maxSpeedStep = 0.2 + rnd.NextDouble() / 4;
                int maxHP = 300 + rnd.Next(150);
                int maxShield = 0;
                int hp = maxHP;
                double coordX = rnd.Next(-800, 800) + superPlayer.coordX;
                double coordY = Math.Abs(coordX) < 520 ? rnd.Next(350, 500) : rnd.Next(500) + superPlayer.coordY;
                if (rnd.Next(1, 11) > 5)
                {
                    coordY *= -1;
                }
                int shape = rnd.Next(1, 4);
                Player player = new Player(new Ship(shape, new Weapon(130, 0.2), maxSpeed, maxRotateStep,
                maxSpeedStep, maxHP, maxShield, hp), coordX, coordY, 90, false);
                enemies.Add(player);            
            }
        }

        public void enemyIntelligenceMethod(Player superPlayer) //TODO can remove in parametr
        {
            if (enemies.Count != maxAmount)
            {
                Spawn();
            }
            if (enemies.Count != 0)
            {
                enemyIntelligence.enemiesLogic(superPlayer);
            }
            //foreach (Player p in enemies)
            //{
            //    if (!p.team)
            //    {
            //        deltaX = superPlayer.coordX - p.coordX;
            //        deltaY = superPlayer.coordY - p.coordY;
            //        hypotenuse = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
            //        needToMove(p, superPlayer, needToTurn(p));
            //    }
            //}
        }

        public double needToTurn(Player p)
        {
            double angle = Math.Abs(Math.Asin(deltaY / hypotenuse));
            angle = normalizeAngle(angle, deltaX, deltaY);

            double temp = p.rotateAngel % 360;

            angle -= temp < 0 ? 360 + temp : temp;

            if (Math.Abs(angle) < 3)
            {
                return angle;
            }

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
            //hypotenuse = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
            if (p.ship.gun.maxRange < hypotenuse)
            {
                control.up(p);
            }
            else
            {
                if (Math.Abs(angle) < 15)
                {
                    p.ship.gun.actualRange = (int)hypotenuse;
                    control.shoot(p); //angle between two angels should be less then 15 to start shooting
                }

                double angleSP = speedAngle(superP);
                double angleP = speedAngle(p);
                double temp = Math.Abs(angleSP - angleP);
                angle = temp < 180 ? temp : 360 - temp;
                if (angle > 45)
                {
                    control.reduce(p);
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
