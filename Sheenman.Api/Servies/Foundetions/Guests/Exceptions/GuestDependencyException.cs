//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//===================================================

using Xeptions;

namespace Sheenman.Api.Servies.Foundetions.Guests.Exceptions
{
    public class GuestDependencyException:Xeption
    {
        public GuestDependencyException(Xeption innerException)
        : base(message: " Guest Dependebcy error occcurred ,contact support",
              innerException)
        { }
    }
}
