using System;
using System.Collections.Generic;
using System.Text;

namespace CCTowerDefense.Game.GameObjects.MovingObjects
{
    public abstract class MovingObject : GameEntity
    {
        protected Direction dir;
        protected int health;

        public int Value { get; private set; }

        public MovingObject(int x, int y) : base(x, y)
        {
            this.Schedule(move);
            Value = 30;
        }



        public void move(float t)
        {
            float velocity = 50;
            t *= velocity;

            switch (dir)
            {
                case Direction.UP:
                    this.PositionY += t;

                    if (this.BoundingBox.IntersectsRect(Map.Self.Get(x, y + 1).BoundingBox))
                    {
                        if (Map.Self.Get(x, y + 1).acceptTank(this))
                        {
                            y = y + 1;
                        }
                        else if (Map.Self.Get(x + 1, y).acceptTank(this))
                        {
                            x = x + 1;
                            dir = Direction.RIGHT;
                        }
                        else
                        {
                            x = x - 1;
                            dir = Direction.LEFT;
                        }
                    }

                    break;
                case Direction.RIGHT:
                    this.PositionX += t;
                    if (this.BoundingBox.IntersectsRect(Map.Self.Get(x + 1, y).BoundingBox))
                    {
                        if (Map.Self.Get(x + 1, y).acceptTank(this))
                        {
                            x = x + 1;
                        }
                        else if (Map.Self.Get(x, y + 1).acceptTank(this))
                        {
                            y = y + 1;
                            dir = Direction.UP;
                        }
                        else
                        {
                            y = y - 1;
                            dir = Direction.DOWN;
                        }
                    }
                    break;
                case Direction.DOWN:
                    this.PositionY -= t;
                    if (this.BoundingBox.IntersectsRect(Map.Self.Get(x, y - 1).BoundingBox))
                    {
                        if (Map.Self.Get(x, y - 1).acceptTank(this))
                        {
                            y = y - 1;
                        }
                        else if (Map.Self.Get(x + 1, y).acceptTank(this))
                        {
                            x = x + 1;
                            dir = Direction.RIGHT;
                        }
                        else
                        {
                            x = x - 1;
                            dir = Direction.LEFT;
                        }
                    }

                    break;
                case Direction.LEFT:
                    this.PositionX -= t;
                    if (this.BoundingBox.IntersectsRect(Map.Self.Get(x - 1, y).BoundingBox))
                    {
                        if (Map.Self.Get(x - 1, y).acceptTank(this))
                        {
                            x = x - 1;
                        }
                        else if (Map.Self.Get(x, y + 1).acceptTank(this))
                        {
                            y = y + 1;
                            dir = Direction.UP;
                        }
                        else
                        {
                            y = y - 1;
                            dir = Direction.DOWN;
                        }
                    }

                    break;
            }

            //TODO minden irányba!
            if(this.BoundingBox.MinX > VisibleBoundsWorldspace.MaxX)
            {
                GameEventHandler.Self.TankOnExit(this);
            }
        }

        public void getShot(int power)
        {
            health -= power;

            if (health <= 0)
                GameEventHandler.Self.TankDestroy(this);
        }

    }
    public enum Direction
    {
        UP, RIGHT, DOWN, LEFT
    }
}
