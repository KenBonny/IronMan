namespace IronMan.Core
{
    public interface IMissileFactory
    {
        IMissile Create(MissileType missileType);
    }
}