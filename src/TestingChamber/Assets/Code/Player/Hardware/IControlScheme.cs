namespace Assets.Code.Player.Hardware
{
    public interface IControlSchemeKeys
    {
        IKeyUnit up { get; }
        IKeyUnit down { get; }
        IKeyUnit left { get; }
        IKeyUnit right { get; }
    }
    public interface IControlScheme : IControlSchemeKeys
    {
        new IControlAction up { get; }
        new IControlAction down { get; }
        new IControlAction left { get; }
        new IControlAction right { get; }
    }
}
