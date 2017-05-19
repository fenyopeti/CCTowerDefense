using CCTowerDefense.Game.GameObjects.MovingObjects;
using CCTowerDefense.Game.GameObjects.ShootingObjects;
using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;

namespace CCTowerDefense.Game.GameObjects.MapObjects
{
    public class Field : MapEntity
    {
        public Field(int x, int y) : base(x, y)
        {
            sprite = new CocosSharp.CCSprite("field.png");
        }

        public override bool acceptTank(MovingObject tank)
        {
            return true;
        }

      //  public override void OnTouch(CCTouch touch, Map map)
      //  {

    //    }

    }
}
