using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Business
{
    public interface IPersonService : IEntityService<Person>
    {
        Person GetById(int id);

    }
}
