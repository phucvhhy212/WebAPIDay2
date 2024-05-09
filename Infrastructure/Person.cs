namespace Infrastructure
{
    public class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public string BirthPlace { get; set; }
    }
}
