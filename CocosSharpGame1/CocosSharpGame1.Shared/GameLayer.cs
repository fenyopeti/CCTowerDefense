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
    public class GameLayer : CCLayerColor
    {
        CCLabel label;
        Map map;
        Gamer gamer;
        CCMusicPlayer backgroungMusic;


        public GameLayer() : base(new CCColor4B(73, 231, 108))
        {

            gamer = new Gamer();
            map = new Map();
            label = new CCLabel($"Life: {gamer.Lifes}  Money: {gamer.Money}", "fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);
            backgroungMusic = new CCMusicPlayer();

            AddChild(label);
            AddChild(map);

            GameEventHandler.Self.TankArrived += HandleLabelChanged;
            GameEventHandler.Self.TankDead += HandleLabelChanged;
            GameEventHandler.Self.TowerCreated += HandleLabelChanged;

            GameEventHandler.Self.GameIsOver += HandleGameOver;
        }

        private void HandleGameOver() //asdfasdf
        {

            Window.DefaultDirector.ReplaceScene(MainLayer.GameScene(Window));
            backgroungMusic.Stop();
            this.RemoveFromParent();
     //       map.Dispose();
          //  this.RemoveFromParent();
        }
        private void HandleLabelChanged(MovingObject obj)
        {
            label.Text = $"Life: {gamer.Lifes}  Money: {gamer.Money}";
        }

        private void HandleLabelChanged(ShootingObject obj)
        {
            label.Text = $"Life: {gamer.Lifes}  Money: {gamer.Money}";
        }


        protected override void AddedToScene()
        {
            base.AddedToScene();
            var bounds = VisibleBoundsWorldspace;

            backgroungMusic.Open("droidsong.mp3", 1);

            label.PositionX = bounds.Center.X;
            label.PositionY = bounds.MaxY - 40f;

            backgroungMusic.Play(true);
            // Register for touch events
            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesEnded = OnTouchesEnded;
            AddEventListener(touchListener, this);

            Schedule((dt) =>
                {
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    {
                        HandleGameOver();
                    }
                }
            );
        }

        internal static CCScene GameScene(CCWindow window)
        {
            var scene = new CCScene(window);
            var layer = new GameLayer();

            scene.AddChild(layer);

            return scene;
        }

        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {

                if (gamer.Money >= 70)
                    GameEventHandler.Self.isTouched(touches[0], map);
                

            }
        }
    }
}
