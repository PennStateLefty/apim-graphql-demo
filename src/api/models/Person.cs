namespace apim_graphql_demo.models
{
    public class Person
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }

        public decimal Salary { get; set; }
        public string Phone { get; set; }

        #region Constructors
        public Person() 
        {
            Id = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            JobTitle = string.Empty;
            Salary = 0;
            Phone = string.Empty;
        }
        public Person(string id, string firstName, string lastName, string email, string jobTitle, decimal salary, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            JobTitle = jobTitle;
            Salary = salary;
            Phone = phone;
        }
        #endregion
    }
}