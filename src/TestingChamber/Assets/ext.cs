using UnityEngine;

namespace extensions
{
    public static class ext
    {
        public enum Direction
        {
            RIGHT, LEFT, UP, DOWN, BACK, FORTH, NONE
        }
        public static void move(this GameObject obj, Direction direction, float speed)
        {
            switch (direction)
            {
                case Direction.BACK:
                    {
                        obj.transform.position = new Vector3(
                            obj.transform.position.x,
                            obj.transform.position.y,
                            obj.transform.position.z - speed
                        );
                        break;
                    }
                case Direction.FORTH:
                    {
                        obj.transform.position = new Vector3(
                            obj.transform.position.x,
                            obj.transform.position.y,
                            obj.transform.position.z + speed
                        );
                        break;
                    }
                case Direction.LEFT:
                    {
                        obj.transform.position = new Vector3(
                            obj.transform.position.x - speed,
                            obj.transform.position.y,
                            obj.transform.position.z
                        );
                        break;
                    }
                case Direction.RIGHT:
                    {
                        obj.transform.position = new Vector3(
                            obj.transform.position.x + speed,
                            obj.transform.position.y,
                            obj.transform.position.z
                        );
                        break;
                    }
                case Direction.UP:
                    {
                        obj.transform.position = new Vector3(
                            obj.transform.position.x,
                            obj.transform.position.y + speed,
                            obj.transform.position.z
                        );
                        break;
                    }
                case Direction.DOWN:
                    {
                        obj.transform.position = new Vector3(
                            obj.transform.position.x,
                            obj.transform.position.y - speed,
                            obj.transform.position.z
                        );
                        break;
                    }
            }
        }
    }
}
