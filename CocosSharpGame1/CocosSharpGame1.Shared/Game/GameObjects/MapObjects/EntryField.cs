using System;
using System.Collections.Generic;
using System.Text;

namespace CCTowerDefense.Game.GameObjects.MapObjects
{
    public class EntryField : Field
    {
        public EntryField(int x, int y) : base(x, y)
        {
            sprite = new CocosSharp.CCSprite("infield.png");

            Schedule(createTank, interval: 5f);
        }

        public void createTank(float unusedVariable)
        {
            GameEventHandler.Self.CreateTank(x, y);
        }
    }
}
