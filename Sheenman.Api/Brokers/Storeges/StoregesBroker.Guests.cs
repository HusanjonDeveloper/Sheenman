//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//===================================================


using Microsoft.EntityFrameworkCore;
using Sheenman.Api.Models.Foundetions.Guests;

namespace Sheenman.Api.Brokers.Storeges
{
    public partial class StoregesBroker
    {
        public DbSet<Guest> Guests { get; set; }
    }
}
