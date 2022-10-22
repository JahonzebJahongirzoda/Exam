using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class VolunteerService:IVolunteerService
{
    private readonly DataContext _context;

    public VolunteerService(DataContext  context)
    {
        _context = context;
    }
    
    public async Task<List<GetVolunteerDto>> GetVolunteers()
    {
        return await _context.Volunteers.Select(x => new GetVolunteerDto()
        {
            Id = x.Id,
            Name = x.Name,
            Address = x.Address,
            Occupation = x.Occupation,
            EmailAddress = x.EmailAddress,
            PhoneNumber = x.PhoneNumber,
            YourMessage = x.YourMessage,
        }).ToListAsync();
    }
    
    //add category
    public async Task<GetVolunteerDto> AddVolunteer(AddVolunteerDto category)
    {
        var newVolunteer = new Volunteer()
        {
            Name = category.Name,
            Address = category.Address,
            Occupation = category.Occupation,
            EmailAddress = category.EmailAddress,
            PhoneNumber = category.PhoneNumber,
            YourMessage = category.YourMessage,
        };
        await _context.Volunteers.AddAsync(newVolunteer);
        await _context.SaveChangesAsync();
        return new GetVolunteerDto()
        {
            Id = newVolunteer.Id,
            Name = newVolunteer.Name,
            Address = newVolunteer.Address,
            Occupation = newVolunteer.Occupation,
            EmailAddress = newVolunteer.EmailAddress,
            PhoneNumber = newVolunteer.PhoneNumber,
            YourMessage = newVolunteer.YourMessage,
        };
    }
    
    //update category
    public async Task<GetVolunteerDto> UpdateVolunteer(AddVolunteerDto category)
    {
        var updateVolunteer = await _context.Volunteers.FirstOrDefaultAsync(x => x.Id == category.Id);
        if (updateVolunteer == null)
        {
            return null;
        }
        updateVolunteer.Name = category.Name;
        updateVolunteer.Address = category.Address;
        updateVolunteer.Occupation = category.Occupation;
        updateVolunteer.EmailAddress = category.EmailAddress;
        updateVolunteer.PhoneNumber = category.PhoneNumber;
        updateVolunteer.YourMessage = category.YourMessage;
        await _context.SaveChangesAsync();
        return new GetVolunteerDto()
        {
            Id = updateVolunteer.Id,
            Name = updateVolunteer.Name,
            Address = updateVolunteer.Address,
            Occupation = updateVolunteer.Occupation,
            EmailAddress = updateVolunteer.EmailAddress,
            PhoneNumber = updateVolunteer.PhoneNumber,
            YourMessage = updateVolunteer.YourMessage,
        };
    }
    
    //delete category
    public async Task<bool> DeleteVolunteer(int id)
    {
        var deleteVolunteer = await _context.Volunteers.FirstOrDefaultAsync(x => x.Id == id);
        if (deleteVolunteer == null)
        {
            return false;
        }
        _context.Volunteers.Remove(deleteVolunteer);
        await _context.SaveChangesAsync();
        return true;
    }
    
    //get category by id
    public async Task<GetVolunteerDto?> GetVolunteerById(int id)
    {
        return await _context.Volunteers.Where(x => x.Id == id).Select(x => new GetVolunteerDto()
        {
            Id = x.Id,
            Name = x.Name,
            Address = x.Address,
            Occupation = x.Occupation,
            EmailAddress = x.EmailAddress,
            PhoneNumber = x.PhoneNumber,
            YourMessage = x.YourMessage,
        }).FirstOrDefaultAsync();
    }
}