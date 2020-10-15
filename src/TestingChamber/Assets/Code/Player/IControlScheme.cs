namespace Assets.Code.Player
{
    public interface IControlScheme
    {
        IControlAction up { get; }
        IControlAction down { get; }
        IControlAction left { get; }
        IControlAction right { get; }
    }
}
