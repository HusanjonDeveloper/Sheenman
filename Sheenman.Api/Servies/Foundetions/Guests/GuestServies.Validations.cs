//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//===================================================

using System;
using Sheenman.Api.Models.Foundetions.Guests;
using Sheenman.Api.Servies.Foundetions.Guests.Exceptions;

namespace Sheenman.Api.Servies.Foundetions.Guests
{
    public partial class GuestServies
    {
        private void ValidateGuestOnAdd(Guest guest)
        {
            ValidateGuestNotNull(guest);

            Validate(
                (Rule: IsInvalid(guest.id), Parameter: nameof(Guest.id)),
                (Rule: IsInvalid(guest.FristName),Parameter:nameof(Guest.FristName)),
                (Rule: IsInvalid(guest.LastName), Parameter: nameof(Guest.LastName)),
                (Rule: IsInvalid(guest.DateOgBrith), Parameter: nameof(Guest.DateOgBrith)),
                (Rule: IsInvalid(guest.Email), Parameter: nameof(Guest.Email)),
                (Rule: IsInvalid(guest.Adders), Parameter: nameof(Guest.Adders)),
                (Rule: IsInvalid(guest.Gender), Parameter: nameof(Guest.Gender)));
                   
        }
        private void ValidateGuestNotNull(Guest guest)
        {
            if (guest is null)
            {
                throw new NullGuestExceptions();

            }
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Conditon = id == Guid.Empty,
            Message ="Id is requered"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Conditon = string.IsNullOrWhiteSpace(text),
            Message = "Text is requred"
        };

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Conditon = date == default,
            Message = "Date is requred"
        };
        private static dynamic IsInvalid(GenderType gender) => new
        {
            Conditon = Enum.IsDefined(typeof(GenderType), gender) is false,
            Message = "Value is Invalid"
        };

        private static void  Validate(params(dynamic Rule,string Parameter)[]validations)
        {
            var invalidGuestException = new InvalidGuestException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Conditon)
                {
                    invalidGuestException.UpsertDataList(
                        parameter, 
                        rule.Message);
                }
            }

            invalidGuestException.ThrowIfContainsErrors();
        }
    }
}
