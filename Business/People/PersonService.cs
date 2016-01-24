using DataAccess;

namespace Business
{
    public class PersonService : EntityService<Person>, IPersonService
    {
        private IPersonRepository personRepository;

        public PersonService(IUnitOfWork unitOfWork, IPersonRepository repository) : base(unitOfWork, repository)
        {
            this.personRepository = repository;
        }

        public Person GetById(int id)
        {
            return personRepository.GetById(id);
        }
    }
}