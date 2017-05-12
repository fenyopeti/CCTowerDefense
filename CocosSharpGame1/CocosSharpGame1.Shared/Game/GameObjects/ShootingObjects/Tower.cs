using CocosSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCTowerDefense.Game.GameObjects.ShootingObjects
{
    class Tower : ShootingObject
    {
        public Tower(int x, int y) : base(x, y)
        {
            sprite = new CCSprite();
        }
    }
}
