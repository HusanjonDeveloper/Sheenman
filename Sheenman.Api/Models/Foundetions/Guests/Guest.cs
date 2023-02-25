//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//==================================================

using System;

namespace Sheenman.Api.Models.Foundetions.Guests
{
    public class Guest
    {
        public Guid id { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOgBrith { get; set; }
        public string  Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Adders { get; set; }
        public GenderType Gender { get; set; }


    }
}
