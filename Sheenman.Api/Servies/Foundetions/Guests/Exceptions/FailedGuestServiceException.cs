//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//===================================================

using System;
using Xeptions;

namespace Sheenman.Api.Servies.Foundetions.Guests.Exceptions
{
    public class FailedGuestServiceException:Xeption
    {
        public FailedGuestServiceException(Exception innerException)
        :base(message:"Faild guestv service error occurred, contact suport",
             innerException)
        {}
        
    }
}
