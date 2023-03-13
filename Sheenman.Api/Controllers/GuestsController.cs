//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//===================================================

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using Sheenman.Api.Models.Foundetions.Guests;
using Sheenman.Api.Servies.Foundetions.Guests;
using Sheenman.Api.Servies.Foundetions.Guests.Exceptions;

namespace Sheenman.Api.Controllers
{
    [ApiController]
    [Route("api/controller")]

    public class GuestsController : RESTFulController
    {
        private readonly IGuestServies guestServies;

        public GuestsController(IGuestServies guestServies)
        {
            this.guestServies = guestServies;
        }

        [HttpGet]
        public async ValueTask<ActionResult<Guest>> PostGuestAsync(Guest guest)
        {
            try
            {
                 Guest postedGuest =await this.guestServies.AddGuestAsync(guest);
                 return Created(postedGuest);

            }
            catch (GuestValidationException guestValidationException)
            {
                return BadRequest(guestValidationException);
            }
            catch(GuestDependencyValidationException guestDependencyValidationException)
               when (guestDependencyValidationException.InnerException is AlreadyExistGuestException )
            {
                return Conflict(guestDependencyValidationException.InnerException);
            }
            catch(GuestDependencyValidationException guestDependencyValidationException)
            {
                return BadRequest(guestDependencyValidationException.InnerException);
            }
            catch(GuestDependencyException guestDependencyException)
            {
                return InternalServerError(guestDependencyException.InnerException);
            }
            catch(GuestServiceException guestServiceException)
            {
                return InternalServerError(guestServiceException.InnerException);
            }
        }
    }
}
