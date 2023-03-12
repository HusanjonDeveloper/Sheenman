//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//===================================================

using Xeptions;

namespace Sheenman.Api.Servies.Foundetions.Guests.Exceptions
{
    public class GuestServiceException:Xeption
    {
        public GuestServiceException(Xeption innerException)
        :base(message:"Guest Service Error occurred, contact support",
             innerException)
        {}

    }
}
