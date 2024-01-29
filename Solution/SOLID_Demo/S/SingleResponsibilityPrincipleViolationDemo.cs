namespace SOLID_Demo.S
{
    internal class SingleResponsibilityPrincipleViolationDemo
    {
    }

    public class Person
    { }

    /*
     * A class should have a single responsibility and it should do it well.
     * This class has 3 responsibilities,
•	It is responsible for connecting to DB and querying data,
•	It is responsible for transforming data into printable text,
•	It is responsible for writing the transformed data in to a text file.

     * A class should not have more than 1 reason to change.
     * This class has 3 reasons to change
•	Let’s say we decided to read people’s data from Excel/XML/Json file or other kind of DBMS. We will need to change the logic of ‘read from database’ method.
•	Let’s say our customers want to print people data in the file in a different format with different colors and fonts. We will need to change the ‘Build Text’ method for this.
•	Let’s say we want to change the text file location which gets saved with people data. Or file name, or extension (PDF or Word file instead of .txt) of the file. For this we will need to change _resultFilePath variable or maybe introduce a new method. 

     */

    public class PeopleInformationPrinter
    {
        private readonly string _connectionString;
        private readonly string _resultFilePath;

        public PeopleInformationPrinter(string connectionString, string resultFilePath)
        {
            _connectionString = connectionString;
            _resultFilePath = resultFilePath;
        }

        // write all people data to a file
        public void Print()
        {
            var people = ReadFromDatabase();
            var text = BuiltText(people);
            File.WriteAllText(_resultFilePath, text);
        }

        // get all people data from DB
        private IEnumerable<Person> ReadFromDatabase()
        {
            throw new NotImplementedException();
        }

        // built a displayable string to write to the file
        private string BuiltText(IEnumerable<Person> people)
        {
            throw new NotImplementedException();
        }

    }
}
