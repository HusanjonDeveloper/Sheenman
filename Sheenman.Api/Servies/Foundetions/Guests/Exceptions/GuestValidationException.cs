//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//===================================================

using Xeptions;

namespace Sheenman.Api.Servies.Foundetions.Guests.Exceptions
{
    public class GuestValidationException:Xeption
    {
        public GuestValidationException(Xeption innerException )
        :base(message:"Guest Validation error occurred, fix the errors and try again",
             innerException)
        {}
    }
}
