using System;

namespace Hiker.Application.Common.Exceptions
{
    public class UpdateRecordFailedException : Exception
    {
        public UpdateRecordFailedException(string message) : base(message)
        {

        }
    }
}