using System;
using System.Collections.Generic;
using System.Text;

namespace Endless_Sky
{
    class EnemyIntelligence
    {
        double deltaX;
        private double deltaY;
        private double hypotenuse;
        private Player superPlayer;
        public List<Player> enemies = new List<Player>();
        private Controls control;

        public EnemyIntelligence(Controls control, Player superPlayer, List<Player> enemies)
        {
            this.control = control;
            this.superPlayer = superPlayer;
            this.enemies = enemies;
        }

        public void enemiesLogic(Player superPlayer)
        {
            foreach (Player p in enemies)
            {
                if (!p.team)
                {
                    deltaX = superPlayer.coordX - p.coordX;
                    deltaY = superPlayer.coordY - p.coordY;
                    hypotenuse = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
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
