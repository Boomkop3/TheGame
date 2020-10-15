using Assets.Code.Player.Hardware;
using Direction = Assets.Code.Library.VectorMovement.Direction;

namespace Assets.Code.Player
{
    public class Controls
    {
        
        public static class WalkingDirection
        {
            public static IControlSchemeKeys keys => ControlHub.lastUsedControlScheme;
            public static float x
            {
                get
                {
                    float x = 0;
                    foreach (IControlScheme scheme in ControlHub.controlSchemes)
                    {
                        if (scheme.right.whilePressed) x++;
                        if (scheme.left.whilePressed) x--;
                    }
                    return x;
                }
            }
            public static float y
            {
                get
                {
                    float y = 0;
                    foreach (IControlScheme scheme in ControlHub.controlSchemes)
                    {
                        if (scheme.up.whilePressed) y++;
                        if (scheme.down.whilePressed) y--;
                    }
                    return y;
                }
            }
            public static Direction direction
            {
                get
                {
                    if (x < -0.5) return Direction.LEFT;
                    if (x > 0.5) return Direction.RIGHT;
                    if (y > 0.5) return Direction.UP;
                    if (y < -0.5) return Direction.DOWN;
                    return Direction.NONE;
                }
            }
        }
    }
}
