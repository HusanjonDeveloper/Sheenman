//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//===================================================

using System.Threading.Tasks;
using Sheenman.Api.Models.Foundetions.Guests;

namespace Sheenman.Api.Brokers.Storeges
{
    public partial interface IStoregesBroker
    {
        ValueTask<Guest> InsertGuestAsync(Guest guest);
    }
}
