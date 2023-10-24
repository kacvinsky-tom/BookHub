using BookHub.DataAccessLayer.Dtos;
using BookHub.DataAccessLayer.Entity;

namespace BookHub.API.Mapper;

public static class UserMapper
{
    public static UserListDto MapList(User user)
    {
        return new UserListDto()
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
    
    public static UserDetailDto MapDetail(User user)
    {
        return new UserDetailDto()
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