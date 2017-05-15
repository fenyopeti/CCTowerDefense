using System;
using System.Collections.Generic;
using System.Text;

using CocosSharp;
using System.Diagnostics;
using CCTowerDefense.Game;
using CCTowerDefense.Game.GameObjects.MovingObjects;
using CCTowerDefense.Game.GameObjects.ShootingObjects;
using CocosDenshion;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace CocosSharpGame1.Shared
{
    public class MainLayer : CCLayerColor
    {
        CCLabel label;
        public MainLayer() : base(new CCColor4B(73, 231, 108))
        {

            label = new CCLabel("New Game", "fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);
            AddChild(label);
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();
            var bounds = VisibleBoundsWorldspace;

            label.PositionX = bounds.Center.X;
            label.PositionY = bounds.Center.Y;

            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesEnded = OnTouchesEnded;
            AddEventListener(touchListener, this);

            Schedule(
                (dt) =>
                {
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    {
                        this.Application.ExitGame()
                    }
                }

            );
        }



        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
                if (label.BoundingBox.ContainsPoint(touches[0].Location))
                {
                    Window.DefaultDirector.ReplaceScene(GameLayer.GameScene(Window));
                }
            }
        }

        internal static CCScene GameScene(CCWindow window)
        {
            var scene = new CCScene(window);
            var layer = new MainLayer();

            scene.AddChild(layer);

            return scene;
        }
    }
}
