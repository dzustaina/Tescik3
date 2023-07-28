using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using TicketApp.Models;
using TicketApp.Services;

namespace TicketApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{Userid}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var addedUser = _userService.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = addedUser.Userid }, addedUser);
        }

        [HttpPut("{Userid}")]
        public IActionResult UpdateUser(int id, User updatedUser)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            _userService.UpdateUser(id, updatedUser);
            return NoContent();
        }

        [HttpDelete("{Userid}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(id);
            return NoContent();
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            // Autentykacja użytkownika na podstawie przekazanych danych (np. email i hasło)
            var isAuthenticated = _userService.AuthenticateUser(email, password);

            if (isAuthenticated)
            {
                // Tutaj można np. wygenerować i zwrócić token JWT, który będzie używany do uwierzytelniania użytkownika w kolejnych żądaniach
                // W tym przykładzie zwracamy po prostu komunikat o powodzeniu logowania
                return Ok("Logowanie udane.");
            }
            else
            {
                return Unauthorized("Niepoprawny email lub hasło.");
            }
        }

        [HttpPost("register")]
        public IActionResult Register(string firstName, string lastName, string email, string password)
        {
            try
            {
                // Rejestracja nowego użytkownika na podstawie przekazanych danych
                _userService.RegisterUser(firstName, lastName, email, password);
                return Ok("Rejestracja udana.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        


        

       
    }
}
