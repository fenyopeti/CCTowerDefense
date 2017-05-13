using CCTowerDefense.Game.GameObjects.MovingObjects;
using CocosSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCTowerDefense.Game.GameObjects.ShootingObjects
{
    public class ShootingObject : GameEntity
    {
        protected int power;
        protected float range;

        private MovingObject target;

        public static int Value { get; protected set; }

        public ShootingObject(int x, int y, bool isActive = true) : base(x, y)
        {
            Schedule(rotation);
            Schedule(shoot, interval: 3f);
        }

        public void rotation(float unused)
        {
            target = Map.Self.getTankInRange(this, range);

            if (target != null)
            {

                var normVekt = (target.Position - this.Position) / ((target.Position - this.Position).Length);
                Rotation = -normVekt.Angle * 57f + 90f;
            }
            else
            {
                Rotation = 0;
            }
        }

        public void shoot(float unused)
        {
            if (target != null)
                GameEventHandler.Self.CreateBullet(this.Position, target, power);
        }
    }
}
