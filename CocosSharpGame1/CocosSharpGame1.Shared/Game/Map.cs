using CCTowerDefense.Game.GameObjects.MapObjects;
using CCTowerDefense.Game.GameObjects.MovingObjects;
using CCTowerDefense.Game.GameObjects.ShootingObjects;
using CocosSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


namespace CCTowerDefense.Game
{
    public class Map : CCNode 
    {

        public int Cols { get; private set; }
        public int Rows { get; private set; }

        private MapEntity[,] gameMap;
        private List<MovingObject> tanks;
        private List<ShootingObject> towers;

        public Map()
        {
            tanks = new List<MovingObject>();
            towers = new List<ShootingObject>();

            GameEventHandler.Self.TankCreated += HandleTankCreated;
            GameEventHandler.Self.TankDead += HandleTankRemove;
            GameEventHandler.Self.TankDead += HandleExplosion;
            GameEventHandler.Self.TankArrived += HandleTankRemove;

            GameEventHandler.Self.TowerCreated += HandleTowerCreated;
            GameEventHandler.Self.BulletCreated += HandleBulletCreated;

        }

        protected override void AddedToScene()
        {
            base.AddedToScene();
            InitializeMap();
            
            ContentSize = new CCSize(768f, 768f);
            Position = new CCPoint(0, 150f);
            //Position = ;
        }

        public MapEntity Get(int i, int j)
        {
            if (i >= Cols || j >= Rows || i < 0 || j < 0)
                return new ExitField(i, j);
            return gameMap[i, j];
        }

        public MovingObject getTankInRange(ShootingObject tower, float range)
        {
            List<MovingObject> nearTanks = new List<MovingObject>();
            foreach (var tank in tanks)
            {
                if (tower.Position.IsNear(tank.Position, range))
                    nearTanks.Add(tank);

            }
            if (nearTanks.Count > 0)
                return nearTanks[0];

            return null;

        }

        private void InitializeMap()
        {

            string mapText = CCFileUtils.GetFileData(filename: "map.txt");
#if __IOS__
            string[] stringSeparators = new string[] { "\n" };
#else
            string[] stringSeparators = new string[] { "\r\n" };
#endif
            string[] lines = mapText.Split(stringSeparators, StringSplitOptions.None);
            string[] dimension = lines[0].Split(' ');

            Cols = int.Parse(dimension[0]);
            Rows = int.Parse(dimension[1]);
            gameMap = new MapEntity[Rows, Cols];

            for (int i = 2; i < lines.Length; i++)
            {
                var items = lines[i].Split(' ');
                for (int j = 0; j < items.Length; j++)
                {
                    switch (items[j])
                    {
                        case "W":
                            gameMap[j, i - 2] = new Wall(j, i - 2);
                            break;
                        case "I":
                            gameMap[j, i - 2] = new EntryField(j, i - 2, this);
                            break;
                        case "F":
                            gameMap[j, i - 2] = new Field(j, i - 2);
                            break;
                        case "O":
                            gameMap[j, i - 2] = new ExitField(j, i - 2);
                            break;

                    }


                }
            }
        
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    AddChild(gameMap[j, i]);
                }
            }
        }

        private void HandleTankCreated(MovingObject obj)
        {
            AddChild(obj);
            tanks.Add(obj);
        }

        private void HandleTankRemove(MovingObject obj)
        {
            obj.Visible = false;

            tanks.Remove(obj);
            RemoveChild(obj);
            obj.Cleanup();
            //obj.Dispose()
        }

        private void HandleExplosion(MovingObject obj)
        {
            AddChild(new CCParticleExplosion(obj.Position));
        }


        private void HandleTowerCreated(ShootingObject obj)
        {
            AddChild(obj);
            towers.Add(obj);
        }


        private void HandleBulletCreated(BulletBase obj)
        {
            AddChild(obj);

        }

    }
}
