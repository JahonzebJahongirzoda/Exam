using Domain.Dtos;

namespace Infrastructure.Services;

public interface IVolunteerService 
{
    Task<List<GetVolunteerDto>> GetVolunteers();
    Task<GetVolunteerDto> AddVolunteer(AddVolunteerDto category);
    Task<GetVolunteerDto> UpdateVolunteer(AddVolunteerDto category);
    Task<bool> DeleteVolunteer(int id);
    Task<GetVolunteerDto?> GetVolunteerById(int id);
}