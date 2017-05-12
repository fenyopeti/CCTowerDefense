using CCTowerDefense.Game.GameObjects.MovingObjects;
using CCTowerDefense.Game.GameObjects.ShootingObjects;
using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;

namespace CCTowerDefense.Game.GameObjects.MapObjects
{
    public class Wall : MapEntity
    {
        public Wall(int x, int y) : base(x, y)
        {
            sprite = new CocosSharp.CCSprite("wall.png");
        }

        public override bool acceptTank(MovingObject tank)
        {
            return false;
        }

        public override void OnTouch(CCTouch touch)
        {

            GameEventHandler.Self.CreateTower(x, y);
        }


    }
}
