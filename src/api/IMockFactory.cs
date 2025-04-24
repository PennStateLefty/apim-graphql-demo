using apim_graphql_demo.models;

public interface IMockFactory
{
    public void LoadMockData();
    public Person GetPersonById(string id);
    public List<Person> GetAllPersons();
    public List<ManagingUnit> GetAllManagingUnits();
    public List<Person> GetPersonsByManagingUnit(string managingUnitId);
    public ManagingUnit GetManagingUnitById(string id);
}