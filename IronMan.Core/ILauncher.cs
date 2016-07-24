namespace IronMan.Core
{
    public interface ILauncher
    {
        int MissileCount { get; }

        void Launch();
    }
}