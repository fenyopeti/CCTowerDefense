using System;
using System.Collections.Generic;
using System.Text;
using CCTowerDefense.Game.GameObjects.MovingObjects;

namespace CCTowerDefense.Game.GameObjects.MapObjects
{
    public class EntryField : Field
    {
        Map map;
        public EntryField(int x, int y, Map map) : base(x, y)
        {
            this.map = map;
            sprite = new CocosSharp.CCSprite("infield.png");

            Schedule(createTank, interval: 3f);
        }

        public Direction DefaultDir { get; set; }

        public void createTank(float unusedVariable)
        {
            GameEventHandler.Self.CreateTank(x, y, DefaultDir, map);
        }
    }
}
