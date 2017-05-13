using CocosSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCTowerDefense.Game.GameObjects.ShootingObjects
{
    class EasyTower : ShootingObject
    {
        public EasyTower(int x, int y) : base(x, y)
        {
            sprite = new CCSprite("etower.png");
            Value = 60;
            power = 30;
            range = 300f;
        }
    }
}
