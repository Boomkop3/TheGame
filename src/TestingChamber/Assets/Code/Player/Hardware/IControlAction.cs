using System;
using UnityEngine;

namespace Assets.Code.Player.Hardware
{
    public interface IKeyUnit
    {
        string keyName { get; set; }
    }
    public interface IControlAction
    {
        bool onPress { get; }
        bool onRelease { get; }
        bool whilePressed { get; }
        float analogValue { get; }
    }

    public abstract class ControlAction : IControlAction, IKeyUnit
    {
        public string keyName { get; set; }
        private Func<KeyCode, bool> onPressFunc;
        private Func<KeyCode, bool> onReleaseFunc;
        private Func<KeyCode, bool> whilePressedFunc;
        private Func<KeyCode, float> analogValueFunc;
        private KeyCode key;
        private IControlScheme scheme;
        private bool handleKeyStroke(Func<KeyCode, bool> check, KeyCode key)
        {
            if (check(key))
            {
                ControlHub.lastUsedControlScheme = (IControlSchemeKeys)scheme;
                return true;
            }
            return false;
        }
        public ControlAction(
                Func<KeyCode, bool> onPress,
                Func<KeyCode, bool> onRelease,
                Func<KeyCode, bool> whilePressed,
                Func<KeyCode, float> analogValue,
                KeyCode key,
                IControlScheme scheme
            )
        {
            this.onPressFunc = (_key) => handleKeyStroke(onPress, _key);
            this.onReleaseFunc = (_key) => handleKeyStroke(onRelease, _key);
            this.whilePressedFunc = (_key) => handleKeyStroke(whilePressed, _key);
            this.analogValueFunc = analogValue;
            this.key = key;
            this.scheme = scheme;
        }
        public bool onPress => onPressFunc(key);

        public bool onRelease => onReleaseFunc(key);

        public bool whilePressed => whilePressedFunc(key);

        public float analogValue => analogValueFunc(key);
    }
}
