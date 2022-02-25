using System;
using System.Collections.Generic;
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

        public void shoot(Player player)
        {
            player.shooting = true;
        }
    }
}
