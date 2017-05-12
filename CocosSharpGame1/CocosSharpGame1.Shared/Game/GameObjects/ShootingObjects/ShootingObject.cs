using System;
using System.Collections.Generic;
using System.Text;

namespace CCTowerDefense.Game.GameObjects.ShootingObjects
{
    public class ShootingObject : GameEntity
    {
        protected int power;
        protected float range;

        public ShootingObject(int x, int y) : base(x, y)
        {
            power = 30;
            range = 200f;
            Schedule(shoot, interval: 3f);
        }

        public void shoot(float unused)
        {
            var tankToBeShot = Map.Self.getTankInRange(this, range);

            if(tankToBeShot != null)
            {
                GameEventHandler.Self.CreateBullet(this.Position, tankToBeShot, power);
            }

        }
    }
}
