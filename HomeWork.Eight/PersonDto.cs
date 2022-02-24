namespace HomeWork.Eight
{
    public class PersonDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string University { get; set; }
        public string Faculty { get; set; }
        public string Special { get; set; }
        public int Age { get; set; }
        public int Course { get; set; }
        public int SomeField { get; set; }
        public string City { get; set; }

        public PersonDto()
        {
            
        }
        public PersonDto(string name, string surname, string university, string faculty, string special, int age, int course, int someField, string city)
        {
            Name = name;
            Surname = surname;
            University = university;
            Faculty = faculty;
            Special = special;
            Age = age;
            Course = course;
            SomeField = someField;
            City = city;
        }
    }
}