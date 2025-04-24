// This class will be used to represent a company organization and its structure, including managing units and personnel.

using apim_graphql_demo.models;
public class Organization
{
    public string Name { get; set; }
    public List<ManagingUnit> ManagingUnits { get; set; }

    public Organization(string name, List<ManagingUnit> managingUnits)
    {
        Name = name;
        ManagingUnits = managingUnits;
    }

    public Organization()
    {
        Name = string.Empty;
        ManagingUnits = new List<ManagingUnit>();
    }
}