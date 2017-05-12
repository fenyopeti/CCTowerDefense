using System;
using System.Collections.Generic;
using System.Text;

using CocosSharp;
using System.Diagnostics;
using CCTowerDefense.Game;
using CCTowerDefense.Game.GameObjects.MovingObjects;

namespace CocosSharpGame1.Shared
{
    public class GameLayer : CCLayerColor
    {

        Gamer gamer;

        CCLabel label;
        Map map;
        Store store;
        public GameLayer() : base(CCColor4B.Gray)
        {

            gamer = new Gamer();
            map = Map.Self;
            store = new Store();
            label = new CCLabel($"Life: {gamer.Lifes}  Money: {gamer.Money}", "fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);

            AddChild(label);
            AddChild(map);
            AddChild(store);

            GameEventHandler.Self.TankArrived += HandleLabelChanged;
            GameEventHandler.Self.TankDead += HandleLabelChanged;
        }

        private void HandleLabelChanged(MovingObject obj)
        {
            label.Text = $"Life: {gamer.Lifes}  Money: {gamer.Money}";
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();
            var bounds = VisibleBoundsWorldspace;

            label.PositionX = bounds.Center.X;
            label.PositionY = bounds.MaxY - 25;


            // Register for touch events
            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesEnded = OnTouchesEnded;
            AddEventListener(touchListener, this);
        }

        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
                if (map.BoundingBox.ContainsPoint(touches[0].Location)){
                    map.OnTouch(touches[0]);
                }
                
            }
        }
    }
}
