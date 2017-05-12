using CocosSharp;
using System;
using System.Collections.Generic;
using System.Text;
using CCTowerDefense.Game.GameObjects.MovingObjects;

namespace CCTowerDefense.Game.GameObjects.ShootingObjects
{
    class Bullet : BulletBase
    {
        public Bullet(MovingObject target, int power, float v) : base(target, power, v)
        {
            sprite = new CCSprite();
        }
    }
}
