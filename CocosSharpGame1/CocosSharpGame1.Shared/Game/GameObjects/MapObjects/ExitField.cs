using CCTowerDefense.Game.GameObjects.MovingObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCTowerDefense.Game.GameObjects.MapObjects
{
    public class ExitField : Field
    {
        public ExitField(int x, int y) : base(x, y)
        {
            sprite = new CocosSharp.CCSprite("outfield.png");
        }
    }
}
