//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//===================================================

using Microsoft.Data.SqlClient;
using Xeptions;

namespace Sheenman.Api.Servies.Foundetions.Guests.Exceptions
{
    public class FaildGuestStorageException:Xeption
    {
        private SqlException sqlException;

        public FaildGuestStorageException(Xeption innerException)
        : base(message:"Faild guest  storage error occcurred ,contact support",
              innerException) 
        {}
        public FaildGuestStorageException(SqlException sqlException)
        {
            this.sqlException = sqlException;
        }
    }
}
