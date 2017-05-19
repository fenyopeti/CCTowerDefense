using CocosSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCTowerDefense.Game.GameObjects.MovingObjects
{
    class EasyTank : MovingObject
    {
        private static float round = 1f;
        public EasyTank(int x, int y, Map map) : base(x, y, map)
        {
            sprite = new CCSprite("swtank.png");
            Value = (int)(40 * round);
            health = (int) (80 * round);
            round += 0.1f;
        }
    }
}
