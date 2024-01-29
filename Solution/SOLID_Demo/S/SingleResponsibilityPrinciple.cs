namespace SOLID_Demo.S
{
    internal class SingleResponsibilityPrinciple
    {
    }


    public interface IPeopleTextFormatter
    {
        public string BuiltText(IEnumerable<Person> people);
    }

    public class PeopleTextFormatter : IPeopleTextFormatter
    {
        // built a displayable string to write to the file
        public string BuiltText(IEnumerable<Person> people)
        {
            throw new NotImplementedException();
        }
    }


    public interface IReader<T>
    {
        public IEnumerable<T> ReadFromDatabase();
    }

    // responsible for Database reading
    public class PersonDatabaseReader : IReader<Person>
    {
        private readonly string _connectionString;

        // get all people data from DB
        public PersonDatabaseReader(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Person> ReadFromDatabase()
        {
            throw new NotImplementedException();
        }
    }


    public interface IWriter<T>
    {
        public void Write(string text);
    }

    public class PersonTextWriter : IWriter<Person>
    {
        private readonly string _resultFilePath;

        public PersonTextWriter(string resultFilePath)
        {
            _resultFilePath = resultFilePath;
        }

        public void Write(string text)
        {
            File.WriteAllText(_resultFilePath, text);
        }
    }

    public class PeopleInformationPrinter
    {
        private readonly IReader<Person> _personDatabaseReader;
        private readonly IPeopleTextFormatter _peopleTextFormatter;
        private readonly IWriter<Person> _personTextWriter;

        public PeopleInformationPrinter(IReader<Person> personDatabaseReader, IPeopleTextFormatter peopleTextFormatter, IWriter<Person> personTextWriter)
        {
            _personDatabaseReader = personDatabaseReader;
            _peopleTextFormatter = peopleTextFormatter;
            _personTextWriter = personTextWriter;
        }


        // write all people data to a file
        public void Print()
        {
            var people = _personDatabaseReader.ReadFromDatabase();
            var text = _peopleTextFormatter.BuiltText(people);
            _personTextWriter.Write(text);
        }
    }
}
