using System.Data.Entity;
using System.Linq;

namespace DataAccess
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context) : base(context)
        {
        }

        public Person GetById(int id)
        {
            return _dbset.FirstOrDefault(x => x.BusinessEntityID == id);
        }
    }
}