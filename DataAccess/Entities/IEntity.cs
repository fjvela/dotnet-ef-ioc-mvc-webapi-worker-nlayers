namespace DataAccess
{
    internal interface IEntity<T>
    {
        T Id { get; set; }
    }
}