//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//===================================================

using System;
using Xeptions;

namespace Sheenman.Api.Servies.Foundetions.Guests.Exceptions
{
    public class GuestDependencyValidationException:Xeption
    {
        public GuestDependencyValidationException(Xeption innerException)
        :base(message:"Guest dependensy Validation error occucrred, fix the errorrs and tyr agin"
             ,innerException)
        {}
    }
}
