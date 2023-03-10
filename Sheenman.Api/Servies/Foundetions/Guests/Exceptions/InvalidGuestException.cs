//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//===================================================

using Xeptions;

namespace Sheenman.Api.Servies.Foundetions.Guests.Exceptions
{
    public class InvalidGuestException:Xeption
    {
        public InvalidGuestException()
          :base(message:"Guest is invalid")
        {}
    }
}
