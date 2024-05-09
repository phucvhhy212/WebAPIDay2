using Infrastructure;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll();
        Person? GetById(Guid id);
        void Add(Person person);
        void Update(Guid id, Person person);
        void Delete(Guid id);
        IEnumerable<Person> Filter(string? fullName, string? gender, GenderType? birthPlace);

    }
}
