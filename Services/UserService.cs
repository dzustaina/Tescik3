using System.Collections.Generic;
using System.Linq;
using TicketApp.Models;

namespace TicketApp.Services
{
    public class UserService
    {
        private readonly MovieAppContext _context;

        public UserService(MovieAppContext context)
        {
            _context = context;
        }

        // public bool AuthenticateUser(string email, string password)
        // {
        //     var user = _context.Users.SingleOrDefault(u => u.Email == email);

        //     if (user == null)
        //     {
        //         return false;
        //     }

        //     // Haszujemy podane hasło
        //     var hashedPassword = HashPassword(password);

        //     // Porównujemy hasła
        //     return user.Password == hashedPassword;
        // }

        // public void RegisterUser(string firstName, string lastName, string email, string password)
        // {
        //     // Sprawdzamy, czy użytkownik o podanym emailu już istnieje
        //     if (_context.Users.Any(u => u.Email == email))
        //     {
        //         throw new Exception("Użytkownik o podanym adresie email już istnieje.");
        //     }

        //     // Haszujemy podane hasło
        //     var hashedPassword = HashPassword(password);

        //     // Tworzymy nowego użytkownika
        //     var newUser = new User
        //     {
        //         FirstName = firstName,
        //         LastName = lastName,
        //         Email = email,
        //         Password = hashedPassword,
        //         IsRegistered = true // Zakładamy, że rejestracja jest pełna
        //     };

        //     // Dodajemy użytkownika do bazy danych
        //     _context.Users.Add(newUser);
        //     _context.SaveChanges();
        // }

        // private string HashPassword(string password)
        // {
        //     using (SHA256 sha256Hash = SHA256.Create())
        //     {
        //         byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

        //         StringBuilder builder = new StringBuilder();
        //         for (int i = 0; i < bytes.Length; i++)
        //         {
        //             builder.Append(bytes[i].ToString("x2"));
        //         }
        //         return builder.ToString();
        //     }
        // }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(user => user.Userid == id);
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void UpdateUser(int id, User updatedUser)
{
    var user = _context.Users.FirstOrDefault(u => u.Userid == id);
    if (user != null)
    {
        if (user.Email != updatedUser.Email)
        {
            // Użytkownik próbuje zmienić adres email - zablokuj operację
            throw new Exception("Zmiana adresu email nie jest dozwolona.");
        }

        // Update properties of the existing user based on updatedUser
        user.Firstname = updatedUser.Firstname;
        user.Lastname = updatedUser.Lastname;
        user.Password = updatedUser.Password;

        _context.SaveChanges();
    }
}


        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Userid == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
