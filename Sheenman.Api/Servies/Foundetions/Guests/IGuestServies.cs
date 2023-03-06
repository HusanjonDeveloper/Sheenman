//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free To Use To find Comfort and Peace 
//===================================================

using System.Threading.Tasks;
using Sheenman.Api.Models.Foundetions.Guests;

namespace Sheenman.Api.Servies.Foundetions.Guests
{
    public interface IGuestServies
    {
        ValueTask<Guest> AddGuestAsync(Guest guest);
    }
}
