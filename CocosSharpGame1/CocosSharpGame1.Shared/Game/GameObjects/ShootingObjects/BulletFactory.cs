using CCTowerDefense.Game.GameObjects.MovingObjects;
using CocosSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCTowerDefense.Game.GameObjects.ShootingObjects
{
    public interface IBulletFactory
    {
        IBulletFactory Position(CCPoint pos);
        IBulletFactory Target(MovingObject target);
        IBulletFactory Power(int power);
        IBulletFactory Velocity(float velocity);
        BulletBase Create();
    }

    class BulletFactory : IBulletFactory
    {
        private CCPoint pos;
        private MovingObject target;
        private int power;
        private float velocity;

        public IBulletFactory Position(CCPoint pos)
        {
            this.pos = pos;
            return this;
        }

        public IBulletFactory Target(MovingObject target)
        {
            this.target = target;
            return this;
        } 

        public IBulletFactory Power(int power)
        {
            this.power = power;
            return this;
        }

        public IBulletFactory Velocity(float velocity)
        {
            this.velocity = velocity;
            return this;
        }

        public BulletBase Create()
        {
            var bullet = new Bullet(target, power, velocity);
            bullet.Position = pos;
            return bullet;
        }

    }


}
