using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers;

[Area("Admin")]
public class VolunteerController:Controller
{
    private readonly IVolunteerService _volunteerService;

    public VolunteerController(IVolunteerService volunteerService)
    {
        _volunteerService = volunteerService;
    }
    
        public async Task<IActionResult> Index()
        {
            return View(await _volunteerService.GetVolunteers());
        }
        
        public IActionResult Create()
        {
            return View( new AddVolunteerDto());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(AddVolunteerDto volunteer)
        {
            if (ModelState.IsValid)
            {
                await _volunteerService.AddVolunteer(volunteer);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Edit(int id)
        {
            var volunteer = await _volunteerService.GetVolunteerById(id);
            return View(new AddVolunteerDto()
            {
                Id = volunteer.Id,
                Name = volunteer.Name,
                Address = volunteer.Address,
                Occupation = volunteer.Occupation,
                EmailAddress = volunteer.EmailAddress,
                YourMessage = volunteer.YourMessage,
                PhoneNumber = volunteer.PhoneNumber,
               
              
            });
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(AddVolunteerDto volunteer)
        {
            if (ModelState.IsValid)
            {
                await _volunteerService.UpdateVolunteer(volunteer);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            await _volunteerService.DeleteVolunteer(id);
            return RedirectToAction("Index");
        }
}