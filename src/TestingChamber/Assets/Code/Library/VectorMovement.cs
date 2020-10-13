using UnityEngine;

namespace Assets.Code.Library
{
    public static class VectorMovement
    {
        public enum Direction
        {
            RIGHT, LEFT, UP, DOWN, BACK, FORTH, NONE
        }
        public static Vector3 move(this Vector3 vector, Direction direction, float speed)
        {
            switch (direction)
            {
                case Direction.BACK:
                    {
                        return new Vector3(
                            vector.x,
                            vector.y,
                            vector.z - speed
                        );
                    }
                case Direction.FORTH:
                    {
                        return new Vector3(
                            vector.x,
                            vector.y,
                            vector.z + speed
                        );
                    }
                case Direction.LEFT:
                    {
                        return new Vector3(
                            vector.x - speed,
                            vector.y,
                            vector.z
                        );
                    }
                case Direction.RIGHT:
                    {
                        return new Vector3(
                            vector.x + speed,
                            vector.y,
                            vector.z
                        );
                    }
                case Direction.UP:
                    {
                        return new Vector3(
                            vector.x,
                            vector.y + speed,
                            vector.z
                        );
                    }
                case Direction.DOWN:
                    {
                        return new Vector3(
                            vector.x,
                            vector.y - speed,
                            vector.z
                        );
                    }
            }
            return vector;
        }
        public static void move(this Rigidbody obj, Direction direction, float speed)
        {
            obj.MovePosition(
                obj.position.move(direction, speed)
            );
        }
        public static void move(this GameObject obj, Direction direction, float speed)
        {
            obj.transform.position = obj.transform.position.move(direction, speed);
        }
    }
}