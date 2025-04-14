// This class will represent the Managing Unit within a company. It will contain a name, a manager record (of class Person), a cost center code, and a collection of worker records (of class Person).

namespace apim_graphql_demo.models
{
    public class ManagingUnit
    {
        public ManagingUnit()
        {
            Id = string.Empty;
            Name = string.Empty;
            Manager = new Person();
            CostCenterCode = string.Empty;
            Workers = new List<Person>();
        }

        public ManagingUnit(string id, string name, Person manager, string costCenterCode, List<Person> workers)
        {
            
            this.Id = id;
            Name = name;
            Manager = manager;
            CostCenterCode = costCenterCode;
            Workers = workers;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public Person Manager { get; set; }
        public string CostCenterCode { get; set; }
        public List<Person> Workers { get; set; }
    }
}