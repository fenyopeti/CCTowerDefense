using CocosSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCTowerDefense.Game.GameObjects
{
    public class GameEntity : CCNode
    {
        protected CCSprite sprite;
        protected int x, y;

        public float Width { get; set; }
        public float Height { get; set; }

        public GameEntity(int x, int y) : base()
        {
            this.x = x;
            this.y = y;
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            ContentSize = sprite.ContentSize = new CCSize(153.6f, 153.6f);

            PositionX = x * 153.6f + 76.8f;
            PositionY = y * 153.6f + 76.8f;

            AddChild(sprite);
        }
    }
}
