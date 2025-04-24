using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using apim_graphql_demo.models;

namespace ApimDemo.GraphQLResolver
{
    public class PersonAPI_HTTPTrigger
    {
        private readonly ILogger<PersonAPI_HTTPTrigger> _logger;
        private readonly IMockFactory _mockFactory;

        public PersonAPI_HTTPTrigger(ILogger<PersonAPI_HTTPTrigger> logger, IMockFactory mockFactory)
        {
            _mockFactory = mockFactory;
            _logger = logger;
        }

        [Function("GetPersonById")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetPersonById/{id}")] HttpRequest req, string id)
        {
            _logger.LogInformation($"Fetching person with ID: {id}.");
            var person = _mockFactory.GetPersonById(id);
            if (person == null)
            {
            return new NotFoundResult();
            }
            return new OkObjectResult(person);
        }

        [Function("GetAllPersons")]
        public IActionResult GetAllPersons([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetAllPersons")] HttpRequest req)
        {
            _logger.LogInformation("Fetching all persons.");
            return new OkObjectResult(_mockFactory.GetAllPersons());
        }

        [Function("GetAllManagingUnits")]
        public IActionResult GetAllManagingUnits([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetAllManagingUnits")] HttpRequest req)
        {
            _logger.LogInformation("Fetching all managing units.");
            return new OkObjectResult(_mockFactory.GetAllManagingUnits());
        }

        [Function("GetPersonsByManagingUnit")]
        public IActionResult GetPersonsByManagingUnit([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetPersonsByManagingUnit/{managingUnitId}")] HttpRequest req, string managingUnitId)
        {
            _logger.LogInformation($"Fetching persons for managing unit ID: {managingUnitId}.");
            var persons = _mockFactory.GetPersonsByManagingUnit(managingUnitId);
            if (persons == null || !persons.Any())
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(persons);
        }

        [Function("GetManagingUnitById")]
        public IActionResult GetManagingUnitById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetManagingUnitById/{id}")] HttpRequest req, string id)
        {
            _logger.LogInformation($"Fetching managing unit with ID: {id}.");
            var managingUnit = _mockFactory.GetManagingUnitById(id);
            if (managingUnit == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(managingUnit);
        }
    }
}
