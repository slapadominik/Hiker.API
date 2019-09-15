using System;

namespace Hiker.Application.Common.Exceptions
{
    public class EntityExistsException : Exception
    {
        public EntityExistsException()
        {
        }

        public EntityExistsException(string message) : base(message)
        {
        }
    }
}