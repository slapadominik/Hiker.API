using System;

namespace Hiker.Application.Common.Exceptions
{
    public class UniqueConstraintViolatedException : Exception
    {
        public UniqueConstraintViolatedException(string message) : base(message)
        {
            
        }
    }
}