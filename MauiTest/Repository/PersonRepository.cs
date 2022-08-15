namespace MauiTest
{
    public class PersonRepository
    {
        public string StatusMessage { get; set; }

        string _dbPath;
        public PersonRepository(string dbPath)=> _dbPath = dbPath;

        private SQLiteConnection connection;
        public void init()
        {
            if (connection != null)
                return;

            connection = new SQLiteConnection(_dbPath);
            connection.CreateTable<Person>();
        }
        public void AddNewPerson(string name) 
        {
            int result = 0;
            try
            {
                init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                result = connection.Insert(new Person { Name = name });
                // TODO: Insert the new person into the database
                result = 0;

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }
        public List<Person> GetAllPersons()
        {

            // TODO: Init then retrieve a list of Person objects from the database into a list
            
            try
            {
                init();
                return connection.Table<Person>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Person>();
        }
    }
}
