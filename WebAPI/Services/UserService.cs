using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Identity;
using WebAPI.DTO.Input.User;

namespace WebAPI.Services;

public class UserService
{
    public User Create(UserInputDto userInputDto)
    {
        var passwordHasher = new PasswordHasher<User>();
        var user = new User
        {
            Username = userInputDto.Username,
            Email = userInputDto.Email,
            FirstName = userInputDto.FirstName,
            LastName = userInputDto.LastName,
            PhoneNumber = userInputDto.PhoneNumber,
            IsAdmin = userInputDto.IsAdmin,
        };
        user.Password = passwordHasher.HashPassword(user, userInputDto.Password);

        return user;
    }

    public void Update(User user, UserInputDto userInputDto)
    {
        var passwordHasher = new PasswordHasher<User>();
        user.Username = userInputDto.Username;
        user.Email = userInputDto.Email;
        user.FirstName = userInputDto.FirstName;
        user.LastName = userInputDto.LastName;
        user.PhoneNumber = userInputDto.PhoneNumber;
        user.IsAdmin = userInputDto.IsAdmin;
        // This should be moved away to separate endpoint/flow of user actions in the future
        user.Password = passwordHasher.HashPassword(user, userInputDto.Password);
    }
}