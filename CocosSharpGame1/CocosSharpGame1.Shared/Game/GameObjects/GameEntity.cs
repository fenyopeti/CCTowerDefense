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


        public GameEntity(int x, int y) : base()
        {
            this.x = x;
            this.y = y;
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            var Size = 768f / 7;// Map.Self.Cols;

            ContentSize = sprite.ContentSize = new CCSize(Size, Size);

            PositionX = x * Size + Size / 2;
            PositionY = y * Size + Size / 2;

            AddChild(sprite);
        }
    }
}
