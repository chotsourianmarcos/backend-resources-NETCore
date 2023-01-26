using Entities.Entities;
using Logic.ILogic;
using RRHHWebAPI.IServices;

namespace RRHHWebAPI.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonLogic _personLogic;
        public PersonService(IPersonLogic personLogic)
        {
            _personLogic = personLogic;
        }
        public void DeletePerson(int id)
        {
            throw new NotImplementedException();
        }

        public List<PersonItem> GetAllPersons()
        {
            throw new NotImplementedException();
        }

        public int InsertPerson(PersonItem personItem)
        {
            return _personLogic.InsertPerson(personItem);
        }

        public void UpdatePerson(PersonItem personItem)
        {
            throw new NotImplementedException();
        }
    }
}
