using CocosSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCTowerDefense.Game.GameObjects.ShootingObjects
{
    class EasyTower : ShootingObject
    {
        public EasyTower(int x, int y, Map map) : base(x, y, map)
        {
            sprite = new CCSprite("etower.png");
            Value = 60;
            power = 50;
            range = 300f;
        }
    }
}
