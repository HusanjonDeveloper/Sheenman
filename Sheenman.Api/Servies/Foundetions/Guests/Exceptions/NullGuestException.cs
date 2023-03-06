//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//===================================================

using System;
using Xeptions;

namespace Sheenman.Api.Servies.Foundetions.Guests.Exceptions
{
    public class NullGuestException: Xeption
    {
        public NullGuestException()
        :base(message:"Guest is Null")
        {}
    }
}
