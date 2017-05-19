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
        public bool HasTower { get; set; }

        public Wall(int x, int y) : base(x, y)
        {
            HasTower = false;
            sprite = new CocosSharp.CCSprite("wall.png");

            GameEventHandler.Self.TouchScreen += OnTouch;
        }

        public override bool acceptTank(MovingObject tank)
        {
            return false;
        }

        public void OnTouch(CCTouch touch, Map map)
        {
            if (BoundingBox.ContainsPoint(new CCPoint(touch.Location.X, touch.Location.Y - 150f)))
            {
                if (!HasTower/* && Gamer.Money >= EasyTower.Value*/)
                {
                    GameEventHandler.Self.CreateTower(x, y, map);
                    HasTower = true;
                }
                else
                {
                    //   map.GetTower(x, y).Upgrade();
                }
            }
        }


    }
}
