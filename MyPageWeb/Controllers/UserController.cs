using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.DataProtection;
using MyPageWeb.Model;

namespace MyPageWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //dependency injection
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public UserController(IConfiguration configuration)
        {
            
            _configuration = configuration;

            /*//retrieve connection string from appsettings
            var server = configuration["MyDatabaseConnection:Server"];
            var port = configuration["MyDatabaseConnection:Port"];
            var database = configuration["MyDatabaseConnection:Database"];
            var username = configuration["MyDatabaseConnection:Uid"];
            //retrieve the password from environment variable
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            //create connection string
            _connectionString = $"Server: {server};Port: {port};Database: {database};Uid: {username};Pwd: {password};";*/

        }

        //API method to get all data from table
        [HttpGet]
        public JsonResult Get()
        {
            //using raw querries
            string query = @"select id, username from users";

            //save data to datatable
            DataTable table = new DataTable();

            //taking connection string from User secrets
            string sqlDataSource = _configuration.GetConnectionString("MyDatabaseConnection");
            //string sqlDataSource = _connectionString;
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        //API method to insert values to table users
        [HttpPost]
        public JsonResult Post(User user)
        {
            //using raw querries
            string query = @"INSERT INTO users(username, email, password) VALUES(@Username, @Email, @Password) ";

            //save data to datatable
            DataTable table = new DataTable();

            //taking connection string from User secrets
            string sqlDataSource = _configuration.GetConnectionString("MyDatabaseConnection");
            //string sqlDataSource = _connectionString;
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Username", user.UserName);
                    myCommand.Parameters.AddWithValue("@Email", user.Email);
                    myCommand.Parameters.AddWithValue("@Password", user.Password);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        // API method to update values for selected user
        [HttpPut("{id}")]
        public JsonResult Put(int id, User user)
        {
            // using raw queries
            string query = @"UPDATE users SET username = @Username, email = @Email, password = @Password WHERE id = @Id";

            // save data to datatable
            DataTable table = new DataTable();

            // taking connection string from User secrets
            string sqlDataSource = _configuration.GetConnectionString("MyDatabaseConnection");
            //string sqlDataSource = _connectionString;
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Id", id);
                    myCommand.Parameters.AddWithValue("@Username", user.UserName);
                    myCommand.Parameters.AddWithValue("@Email", user.Email);
                    myCommand.Parameters.AddWithValue("@Password", user.Password);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

    }
}
