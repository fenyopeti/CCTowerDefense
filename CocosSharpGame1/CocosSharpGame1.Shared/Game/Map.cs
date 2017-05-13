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
    class Map : CCNode
    {
        static Lazy<Map> self = new Lazy<Map>(() => new Map());

        // simple singleton implementation
        public static Map Self
        {
            get
            {
                return self.Value;
            }
        }



        public int Cols { get; private set; }
        public int Rows { get; private set; }

        private MapEntity[,] gameMap;
        private List<MovingObject> tanks;
        private List<ShootingObject> towers;

        private Map()
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
            Position = new CCPoint(0, 200f);
            //Position = ;
        }

        public MapEntity Get(int i, int j)
        {
            //if (i == Cols || j == Rows)
            //return new ExitField(i, j);
            if (i >= Cols || j >= Rows)
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

        public void OnTouch(CCTouch touch)
        {
            for(int i = 0; i < Rows; i++)
            {
                for(int j  = 0; j < Cols; j++)
                {
                    if(gameMap[j, i].BoundingBox.ContainsPoint(new CCPoint(touch.Location.X, touch.Location.Y-200f)))
                    {
                        gameMap[j, i].OnTouch(touch);
                        Debug.WriteLine($"x: {j}, y: {i}");
                    }
                }
            }
        }

        private void InitializeMap()
        {

            var mapJson = CCFileUtils.GetFileData(filename: "map.txt");


            Cols = 5;
            Rows = 5;
            gameMap = new MapEntity[Rows, Cols];

            gameMap[0, 0] = new Wall(0, 0);
            gameMap[0, 1] = new EntryField(0, 1);
            gameMap[0, 2] = new Wall(0, 2);
            gameMap[0, 3] = new Wall(0, 3);
            gameMap[0, 4] = new Wall(0, 4);

            gameMap[1, 0] = new Wall(1, 0);
            gameMap[1, 1] = new Field(1, 1);
            gameMap[1, 2] = new Field(1, 2);
            gameMap[1, 3] = new Field(1, 3);
            gameMap[1, 4] = new Wall(1, 4);

            gameMap[2, 0] = new Wall(2, 0);
            gameMap[2, 1] = new Wall(2, 1);
            gameMap[2, 2] = new Wall(2, 2);
            gameMap[2, 3] = new Field(2, 3);
            gameMap[2, 4] = new Wall(2, 4);

            gameMap[3, 0] = new Wall(3, 0);
            gameMap[3, 1] = new Field(3, 1);
            gameMap[3, 2] = new Field(3, 2);
            gameMap[3, 3] = new Field(3, 3);
            gameMap[3, 4] = new Wall(3, 4);

            gameMap[4, 0] = new Wall(4, 0);
            gameMap[4, 1] = new ExitField(4, 1);
            gameMap[4, 2] = new Wall(4, 2);
            gameMap[4, 3] = new Wall(4, 3);
            gameMap[4, 4] = new Wall(4, 4);

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
