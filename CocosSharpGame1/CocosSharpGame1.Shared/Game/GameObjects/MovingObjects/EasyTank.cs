using CocosSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCTowerDefense.Game.GameObjects.MovingObjects
{
    class EasyTank : MovingObject
    {
        public EasyTank(int x, int y) : base(x, y)
        {
            sprite = new CCSprite("swtank.png");
        }
    }
}
