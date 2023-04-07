using Entities.Entities;

namespace RRHHWebAPI.IServices
{
    public interface IPersonService
    {
        int InsertPerson(PersonItem personItem);
        void UpdatePerson(PersonItem personItem);
        void DeletePerson(int id);
        List<PersonItem> GetAllPersons();
    }
}
