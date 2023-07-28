using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        [HttpPost("AddUser")]
        public Task<ActionResult<User>> AddUser(User _user)
        {
            const string connectionUri = "mongodb+srv://sametkoser66:16236176Sk.@gamecluster.jakalvg.mongodb.net/?retryWrites=true&w=majority";
            var settings =MongoClientSettings.FromConnectionString(connectionUri);
            // Set the ServerApi field of the settings object to Stable API version 1
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            // Create a new client and connect to the server
            var client = new MongoClient(settings);
            // Send a ping to confirm a successful connection

            var database = client.GetDatabase("Users");
            var collection = database.GetCollection<User>("User");

            User user = new User()
            {
                Id=ObjectId.GenerateNewId(),
                registerDate = DateTime.Now,
                userName = "Guest",
                lastLogin = DateTime.Now,
            };
            collection.InsertOne(user);
            _logger.LogInformation("New User Added {@user}", user);
            return Task.FromResult<ActionResult<User>>(user);

        }
    }
}