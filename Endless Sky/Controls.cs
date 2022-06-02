using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Endless_Sky
{
    public class Controls
    {
        public Controls() { }

        public void turnLeft(Player player)
        {
            player.rotateAngel += player.ship.maxRotateStep;
        }

        public void turnRight(Player player)
        {
            player.rotateAngel -= player.ship.maxRotateStep;
        }

        public void up(Player player)
        {
            player.speedX += Math.Cos(player.rotateAngel * Math.PI / 180) * player.ship.maxSpeedStep / 5;
            player.speedY += Math.Sin(player.rotateAngel * Math.PI / 180) * player.ship.maxSpeedStep / 5;

            double spX = Math.Pow(player.speedX, 2.0);
            double spY = Math.Pow(player.speedY, 2.0);
            double spMax = Math.Pow(player.ship.maxSpeed, 2.0);

            double bothSpeed = (Math.Abs(player.speedX) + Math.Abs(player.speedY));

            if (spX + spY > spMax)
            {
                player.speedX -= (Math.Sqrt(spX + spY - spMax) * player.speedX) / bothSpeed;
                player.speedY -= (Math.Sqrt(spX + spY - spMax) * player.speedY) / bothSpeed;
                Console.WriteLine(player.rotateAngel / 180);
                Console.WriteLine("{0} :: {1}", player.speedX, player.speedY);
            }
        }

        public void reduce(Player player)
        {
            //TODO
            //if (player.speedX == 0 && player.speedY == 0) return;
            //double generalSpeed = Math.Sqrt(Math.Pow(player.speedX, 2) + Math.Pow(player.speedY, 2));
            //double temp = generalSpeed * player.speedX / (Math.Abs(player.speedX) + Math.Abs(player.speedY));
            //player.speedX -= temp;
            //player.speedX = player.speedX < 0 ? 0 : player.speedX;
            //
            //if (player.speedX == 0 && player.speedY == 0) return;
            //temp = generalSpeed * player.speedY / (Math.Abs(player.speedX) + Math.Abs(player.speedY));
            //player.speedY -= temp;
            //player.speedY = player.speedY < 0 ? 0 : player.speedY;
            double bothSpeed = (Math.Abs(player.speedX) + Math.Abs(player.speedY));

            if (bothSpeed != 0)
            {
                player.speedX -= player.ship.maxSpeedStep * player.speedX / (bothSpeed * 10);
                player.speedY -= player.ship.maxSpeedStep * player.speedY / (bothSpeed * 10);
            }
        }

        public void shoot(Player player, EnemySpawner esp = null)
        {
            player.shooting = true;

            if (esp == null)
            {
                return;
            }

            player.ship.gun.actualRange = player.ship.gun.maxRange;
            var enemies = esp.enemies;
            foreach (Player p in enemies.ToList())
            {
                double deltaX = p.coordX - player.coordX;
                double deltaY = p.coordY - player.coordY;
                double hypotenuse = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
                double angle = Math.Abs(Math.Asin(deltaY / hypotenuse));
                angle = normalizeAngle(angle, deltaX, deltaY, player);

                if (Math.Abs(angle) <= 10)
                {
                    player.ship.gun.actualRange = hypotenuse > player.ship.gun.actualRange ? player.ship.gun.actualRange : hypotenuse;
                    //player.ship.gun.actualRange = hypotenuse;

                    double arc = (Math.PI * player.ship.gun.actualRange * angle) / 180;
                    if (arc <= 10 && player.ship.gun.actualRange >= hypotenuse) //circle with r = 10 is hitbox
                    {
                        p.ship.hp -= player.ship.gun.damagePT;
                        player.ship.hp += player.ship.gun.damagePT / 3;
                        if (p.ship.hp <= 0)
                        {
                            esp.enemies.Remove(p);
                        }
                    }
                }
            }
        }

        private double normalizeAngle(double angle, double X, double Y, Player player)
        {
            angle = (angle / Math.PI) * 180;

            if (X < 0 && Y <= 0)//=
            {
                angle += 180;
            }
            else if (X < 0 && Y >= 0)//=
            {
                angle = 180 - angle;
            }
            else if (X > 0 && Y < 0)
            {
                angle = 360 - angle;
            }

            angle -= player.rotateAngel % 360;
            if (angle > 180)
            {
                angle = angle - 360;
            }
            else if (angle < -180)
            {
                angle = 360 + angle;
            }

            return angle;
        }
    }
}
