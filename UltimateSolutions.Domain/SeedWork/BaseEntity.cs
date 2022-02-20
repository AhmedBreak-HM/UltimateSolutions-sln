namespace UltimateSolutions.Domain.SeedWork
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; }
    }
}