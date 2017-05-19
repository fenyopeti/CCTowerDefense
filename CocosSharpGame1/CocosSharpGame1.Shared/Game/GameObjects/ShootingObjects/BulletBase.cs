using CCTowerDefense.Game.GameObjects.MovingObjects;
using CocosSharp;

namespace CCTowerDefense.Game.GameObjects.ShootingObjects
{
    public class BulletBase : CCNode, IMoving
    {
        private float velocity;
        private int power;
        private MovingObject target;
        protected CCSprite sprite;

        public BulletBase(MovingObject target, int power, float v)
        {
            this.velocity = v;
            this.target = target;
            this.power = power;



            Schedule(move);
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            ContentSize = new CCSize(100f, 100f);
            sprite.ContentSize = new CCSize(153.6f, 153.6f);

            AddChild(sprite);
        }

        public void move(float t)
        {
            if (target == null || target.isDead)
            {
                RemoveFromParent();
                Cleanup();
                return;
            }


            t *= velocity;

            var normVekt = (target.Position - this.Position) / ((target.Position - this.Position).Length);

            PositionX += normVekt.X * t;
            PositionY += normVekt.Y * t;

            Rotation = -normVekt.Angle * 57f + 90f;

            if (this.BoundingBox.IntersectsRect(new CCRect(target.Position.X, target.Position.Y, 5f, 5f)))
            {
                target.getShot(power);
                RemoveFromParent();
                return;
            }
        }
    }
}