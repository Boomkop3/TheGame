using Assets.Code.Player.Hardware;
using System.Transactions;
using UnityEngine;

namespace Assets.Code.Player.Hardware.Devices
{
    public class KeyboardControlAction : ControlAction
    {
        public KeyboardControlAction(KeyCode key, string keyName, IControlScheme scheme)
            : base (getOnPress, getOnRelease, getWhilePressed, getAnalogValue, key, scheme)
        {
            base.keyName = keyName;
        }
        private static bool getOnPress(KeyCode key)
        {
            return Input.GetKeyDown(key);
        }
        private static bool getOnRelease(KeyCode key)
        {
            return Input.GetKeyUp(key);
        }
        private static bool getWhilePressed(KeyCode key)
        {
            return Input.GetKey(key);
        }
        private static float getAnalogValue(KeyCode key)
        {
            return getWhilePressed(key) ? 1 : 0;
        }
    }

    public class KeyboardControlScheme : IControlScheme
    {
        public IControlAction up { get; }
        public IControlAction down { get; }
        public IControlAction left { get; }
        public IControlAction right { get; }
        IKeyUnit IControlSchemeKeys.up => (IKeyUnit)up;
        IKeyUnit IControlSchemeKeys.down => (IKeyUnit)down;
        IKeyUnit IControlSchemeKeys.left => (IKeyUnit)left;
        IKeyUnit IControlSchemeKeys.right => (IKeyUnit)right;

        public KeyboardControlScheme()
        {
            up = new KeyboardControlAction(KeyCode.W, "W", this);
            down = new KeyboardControlAction(KeyCode.S, "S", this);
            left = new KeyboardControlAction(KeyCode.A, "A", this);
            right = new KeyboardControlAction(KeyCode.D, "D", this);
        }
    }
}
