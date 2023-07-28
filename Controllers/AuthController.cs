// using Microsoft.AspNetCore.Mvc;
// using TicketApp.Models;
// using TicketApp.Services;

// namespace TicketApp.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class AuthController : ControllerBase
//     {
//         private readonly UserService _userService;

//         public AuthController(UserService userService)
//         {
//             _userService = userService;
//         }

//         [HttpPost("login")]
//         public IActionResult Login(LoginModel loginModel)
//         {
//             // Implementacja logiki logowania (np. weryfikacja hasła, generowanie tokena, sesji itp.)
//             // ...

//             // Jeśli logowanie powiodło się, zwróć token lub informacje o zalogowanym użytkowniku
//             // Jeśli logowanie nie powiodło się, zwróć odpowiedni komunikat lub kod błędu
//         }

//         [HttpPost("register")]
//         public IActionResult Register(RegisterModel registerModel)
//         {
//             // Implementacja logiki rejestracji użytkownika
//             // ...

//             // Jeśli rejestracja powiodła się, zwróć odpowiedni komunikat lub kod sukcesu
//             // Jeśli rejestracja nie powiodła się, zwróć odpowiedni komunikat lub kod błędu
//         }
//     }
// }
