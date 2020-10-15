using UnityEngine;

namespace Assets.Code.Player
{
    public static class ControlHub
    {
        public static IControlScheme[] controlSchemes { get; }

        static ControlHub()
        {
            controlSchemes = new IControlScheme[]
            {
                new KeyboardControlScheme()
            };
        }

        private class KeyboardControlAction : IControlAction
        {
            private KeyCode key;
            public KeyboardControlAction(KeyCode key)
            {
                this.key = key;
            }
            public bool onPress => Input.GetKeyDown(key);
            public bool onRelease => Input.GetKeyUp(key);
            public bool whilePressed => Input.GetKey(key);
            public float analogValue => whilePressed ? 1 : 0;
        }

        private class KeyboardControlScheme : IControlScheme
        {
            public IControlAction up { get; }
            public IControlAction down { get; }
            public IControlAction left { get; }
            public IControlAction right { get; }
            public KeyboardControlScheme()
            {
                up = new KeyboardControlAction(KeyCode.W);
                down = new KeyboardControlAction(KeyCode.S);
                left = new KeyboardControlAction(KeyCode.A);
                right = new KeyboardControlAction(KeyCode.D);
            }
        }
    }
}
