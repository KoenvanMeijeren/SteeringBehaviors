namespace Src.entity
{
    public interface IPlayer : IMovingEntity
    {
        int Health { get; }
        void TakeDamage();
    }
}
