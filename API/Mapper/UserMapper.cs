using BookHub.API.DTO.Output;
using BookHub.API.DTO.Output.User;
using BookHub.DataAccessLayer.Entity;

namespace BookHub.API.Mapper;

public static class UserMapper
{
    public static UserListOutputDto MapList(User user)
    {
        return new UserListOutputDto()
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            IsAdmin = user.IsAdmin,
        };
    }
    
    public static UserDetailOutputDto MapDetail(User user)
    {
        return new UserDetailOutputDto()
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            IsAdmin = user.IsAdmin,
        };
    }
}