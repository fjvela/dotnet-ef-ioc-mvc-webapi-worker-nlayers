namespace DataAccess
{
    public partial class Person : Entity<int>
    {
        public override int Id
        {
            get
            {
                return this.BusinessEntityID;
            }

            set
            {
                this.BusinessEntityID = value;
            }
        }
    }
}