using CCTowerDefense.Game.GameObjects.MovingObjects;
using CocosSharp;

namespace CCTowerDefense.Game.GameObjects.ShootingObjects
{
    public class BulletBase : CCNode
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

            ContentSize = sprite.ContentSize = new CCSize(25f, 25f);

            AddChild(sprite);
        }

        private void move(float obj)
        {

        }
    }
}