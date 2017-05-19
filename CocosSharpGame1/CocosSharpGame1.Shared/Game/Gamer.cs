using CCTowerDefense.Game.GameObjects.MovingObjects;
using CCTowerDefense.Game.GameObjects.ShootingObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCTowerDefense.Game
{
    class Gamer
    {
 

        public int Lifes { get; private set; }
        public int Money { get; private set; }
      //  public int Score { get; private set; }

        public Gamer()
        {
            Money = 100;
            Lifes = 10;
         //   Score = 0;

            GameEventHandler.Self.TankArrived += HandleTankArrived;
            GameEventHandler.Self.TankDead += HandleTankDestroyed;
            GameEventHandler.Self.TowerCreated += HandleTowerBought;
        }

        private void HandleTankDestroyed(MovingObject obj)
        {
          //  Score += obj.Value;
            Money += obj.Value;
        }

        private void HandleTankArrived(MovingObject obj)
        {
            Lifes--;

            if (Lifes <= 0)
            {
                GameEventHandler.Self.GameOver();
            }
        }

        private void HandleTowerBought(ShootingObject obj)
        {
            if(Money >= ShootingObject.Value)
            {
                Money -= ShootingObject.Value;
            }
        }

        public void Reset()
        {
            Lifes = 10;
            Money = 100;
        }
    }
}
