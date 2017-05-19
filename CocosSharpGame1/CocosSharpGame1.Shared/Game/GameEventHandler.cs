using CCTowerDefense.Game.GameObjects.MovingObjects;
using CCTowerDefense.Game.GameObjects.ShootingObjects;
using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;

namespace CCTowerDefense.Game
{
    class GameEventHandler
    {



        static Lazy<GameEventHandler> self = new Lazy<GameEventHandler>(() => new GameEventHandler());

        // simple singleton implementation
        public static GameEventHandler Self
        {
            get
            {
                return self.Value;
            }
        }

        public event Action<MovingObject> TankCreated;
        public event Action<MovingObject> TankArrived;
        public event Action<MovingObject> TankDead;

        public event Action<ShootingObject> TowerCreated;
        public event Action<BulletBase> BulletCreated;

        public event Action GameIsOver;

        public event Action<CCTouch, Map> TouchScreen;

        private GameEventHandler()
        {

        }

        public void CreateTank(int x, int y, Direction dir, Map map)
        {
            MovingObject newTank = new EasyTank(x, y, map);
            newTank.Dir = dir;
            TankCreated?.Invoke(newTank);
        }

        public void TankOnExit(MovingObject tank)
        {
            TankArrived?.Invoke(tank);
        }


        public void TankDestroy(MovingObject tank)
        {
            TankDead?.Invoke(tank);
        }

        public void CreateTower(int x, int y, Map map)
        {
            ShootingObject newTower = new EasyTower(x, y, map);
            TowerCreated?.Invoke(newTower);
        }

        public void isTouched(CCTouch touch, Map map)
        {
            TouchScreen?.Invoke(touch, map);
        }

        public void CreateBullet(CCPoint position, MovingObject target, int power)
        {
            var newBullet = (new BulletFactory()).Position(position)
                                                 .Target(target)
                                                 .Power(power)
                                                 .Velocity(200f)
                                                 .Create();
            BulletCreated?.Invoke(newBullet);
        }


        public void GameOver()
        {
            GameIsOver?.Invoke();
        }


    }
}
