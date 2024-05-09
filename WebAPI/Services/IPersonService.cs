using Infrastructure;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll();
        Person? GetById(Guid id);
        Guid Add(Person person);
        bool Update(Guid id, Person person);
        bool Delete(Guid id);
        IEnumerable<Person> Filter(string? fullName, string? birthPlace, GenderType? gender);

    }
}
