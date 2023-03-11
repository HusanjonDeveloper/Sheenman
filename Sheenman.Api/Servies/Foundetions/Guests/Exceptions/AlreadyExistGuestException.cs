//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//===================================================

using System;
using Xeptions;

namespace Sheenman.Api.Servies.Foundetions.Guests.Exceptions
{
    public class AlreadyExistGuestException:Xeption
    {
        public AlreadyExistGuestException(Exception innerException)
        :base(message:"Guest already exists",innerException)
        {}
    }
}
