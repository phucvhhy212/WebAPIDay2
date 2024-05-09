using Infrastructure;

namespace WebAPI.Services
{
    public class PersonService:IPersonService
    {
        private static List<Person> _persons = GetPersons();
        private readonly ILogger<PersonService> _logger;

        public PersonService(ILogger<PersonService> logger)
        {
            _logger = logger;
        }
        private static List<Person> GetPersons()
        {
            return new List<Person>
            {
                new Person
                {
                    Id = Guid.NewGuid(),
                    BirthPlace = "HN1",
                    DateOfBirth = DateOnly.Parse("02/02/2000"),
                    FirstName = "Doe",
                    LastName = "John",
                    Gender = GenderType.Male
                },
                new Person
                {
                    Id = Guid.NewGuid(),
                    BirthPlace = "HN1",
                    DateOfBirth = DateOnly.Parse("02/02/2000"),
                    FirstName = "Phuc",
                    LastName = "Huy",
                    Gender = GenderType.Male

                },
                new Person
                {
                    Id = Guid.NewGuid(),
                    BirthPlace = "HN1",
                    DateOfBirth = DateOnly.Parse("02/02/2000"),
                    FirstName = "Phuc",
                    LastName = "Huy",
                    Gender = GenderType.Female
                },
                new Person
                {
                    Id = Guid.NewGuid(),
                    BirthPlace = "HN1",
                    DateOfBirth = DateOnly.Parse("02/02/2000"),
                    FirstName = "F4",
                    LastName = "L4",
                    Gender = GenderType.Female
                }
            };
        }

        public IEnumerable<Person> GetAll()
        {
            return _persons;
        }

        public Person? GetById(Guid id)
        {
            _logger.Log(LogLevel.Information,$"Getting person {id}");
            return _persons.FirstOrDefault(x => x.Id == id);
        }

        public Guid Add(Person person)
        {
            _logger.Log(LogLevel.Information,$"Adding person {person.Id}");
            _persons.Add(person);
            return person.Id;
        }

        public bool Update(Guid id, Person person)
        {
            var findPerson = GetById(id);
            if (findPerson != null)
            {
                _logger.Log(LogLevel.Information, $"Updating peron {id}");
                findPerson.FirstName = person.FirstName;
                findPerson.LastName = person.LastName;
                findPerson.Gender = person.Gender;
                findPerson.BirthPlace = person.BirthPlace;
                findPerson.DateOfBirth = person.DateOfBirth;
                return true;
            }
            else
            {
                _logger.Log(LogLevel.Information, $"Update failed, can't find person {id}");
                throw new Exception($"Update failed, can't find person {id}");
            }

        }

        public bool Delete(Guid id)
        {
            var findPerson = GetById(id);
            if (findPerson != null)
            {
                _logger.Log(LogLevel.Information, $"Deleting peron {id}");
                _persons.Remove(findPerson);
                return true;
            }
            else
            {
                _logger.Log(LogLevel.Information, $"Delete failed, can't find person {id}");
                throw new Exception($"Delete failed, can't find person {id}");
            }
        }

        public IEnumerable<Person> Filter(string? fullName, string? birthPlace, GenderType? gender)
        {
            var allPersons = GetAll();
            if (!String.IsNullOrEmpty(fullName))
            {
                _logger.Log(LogLevel.Information, $"Getting all persons with full name = {fullName}");
                allPersons = allPersons.Where(x => (x.LastName + " " + x.FirstName) == fullName);
            }

            if (gender != null)
            {
                _logger.Log(LogLevel.Information, $"Getting all persons with gender = {gender}");
                allPersons = allPersons.Where(x => x.Gender == gender);
            }

            if (!String.IsNullOrEmpty(birthPlace))
            {
                _logger.Log(LogLevel.Information, $"Getting all persons with birth place = {birthPlace}");
                allPersons = allPersons.Where(x => x.BirthPlace == birthPlace);
            }

            return allPersons;
        }
    }
}
