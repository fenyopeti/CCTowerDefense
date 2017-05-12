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

       // public event Action<int> TowerBought;
        public event Action<ShootingObject> TowerCreated;
        public event Action<BulletBase> BulletCreated;


        public event Action GameIsOver;

        private GameEventHandler()
        {

        }

        public void CreateTank(int x, int y)
        {
            MovingObject newTank = new EasyTank(x, y);
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

        public void CreateTower(int x, int y)
        {
            ShootingObject newTower = new Tower(x, y);
            TowerCreated?.Invoke(newTower);
        }


        public void CreateBullet(CCPoint position, MovingObject tankToBeShot, int power)
        {
            var newBullet = (new BulletFactory()).Position(position)
                                                 .Target(tankToBeShot)
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
