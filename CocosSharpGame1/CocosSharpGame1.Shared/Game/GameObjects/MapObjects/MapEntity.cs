using CCTowerDefense.Game.GameObjects.MovingObjects;
using CCTowerDefense.Game.GameObjects.ShootingObjects;
using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;

namespace CCTowerDefense.Game.GameObjects.MapObjects
{
    public abstract class MapEntity : GameEntity
    {
        public MapEntity(int x, int y) : base(x, y)
        {
        }


        public abstract bool acceptTank(MovingObject tank);
        //  public abstract bool acceptTower(ShootingObject tower);

     //   public abstract void OnTouch(CCTouch touch, Map map);
    }
}
