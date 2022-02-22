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
        public EnemySpawner(bool spawn)
        { 
            if (spawn)
            {
                int maxSpeed = 3;
                int maxRotateStep = 4;
                double maxSpeedStep = 0.3;
                int maxHP = 350;
                int maxShield = 0;
                int hp = 350;
                int coordX = -50;
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
    }
}
