using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL;

namespace Endless_Sky
{
    public class Ship : IDraw
    {
        public readonly int maxSpeed;
        public readonly int maxRotateStep;
        public double maxSpeedStep;
        public readonly int maxHP;
        public readonly int maxShield;
        public int hp;
        public Shape shape;
        public Weapon gun;

        public Ship(int shape, Weapon gun, int maxSpeed, int maxRotateStep, double maxSpeedStep, int maxHP, int maxShield, int hp)
        {
            this.shape = new Shape(shape);
            this.gun = gun;
            this.maxSpeed = maxSpeed;
            this.maxRotateStep = maxRotateStep;
            this.maxSpeedStep = maxSpeedStep;
            this.maxHP = maxHP;
            this.maxShield = maxShield;
            this.hp = hp;
        }

        public void draw()
        {
            shape.draw();
        }
    }
}
