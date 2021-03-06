﻿using CCTowerDefense.Game.GameObjects.MovingObjects;
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
        private Map map;

        public static int Value { get; protected set; }

        public ShootingObject(int x, int y, Map map) : base(x, y)
        { 
            this.map = map;
            Schedule(rotation);
            Schedule(shoot, interval: 3f);
        }

        private void rotation(float unused)
        {
            target = map.getTankInRange(this, range);

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

        public void Upgrade()
        {
            power = (int)(power*1.1f);
            
        }

        private void shoot(float unused)
        {
            if (target != null)
                GameEventHandler.Self.CreateBullet(this.Position, target, power);
        }


    }
}
