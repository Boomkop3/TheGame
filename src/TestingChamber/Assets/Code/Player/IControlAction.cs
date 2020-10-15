namespace Assets.Code.Player
{
    public interface IControlAction
    {
        bool onPress { get; }
        bool onRelease { get; }
        bool whilePressed { get; }
        float analogValue { get; }
    }
}
