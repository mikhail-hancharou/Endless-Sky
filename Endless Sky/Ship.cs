using System;
using System.Collections.Generic;
using System.Text;

namespace Endless_Sky
{
    public class Ship
    {
        public readonly int maxSpeed;
        public readonly int maxRotateStep;
        public readonly double maxSpeedStep;
        public readonly int maxHP;
        public readonly int maxShield;
        public double speedX = 0;
        public double speedY = 0;
        public double coordX = 0;
        public double coordY = 0;
        public double rotateAngel = 0;
        public int hp;
        public bool team;

        public Ship(int maxSpeed, int maxRotateSpeed, double maxSpeedStep, int maxHP, int maxShield, double rotateAngel, int hp, bool team = true)
        {
            this.maxSpeed = maxSpeed;
            this.maxRotateStep = maxRotateSpeed;
            this.maxSpeedStep = maxSpeedStep;
            this.maxHP = maxHP;
            this.maxShield = maxShield;
            this.rotateAngel = rotateAngel;
            this.hp = hp;
            this.team = team;
        }
    }
}
