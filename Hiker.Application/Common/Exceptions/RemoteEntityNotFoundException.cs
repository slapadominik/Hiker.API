using System;

namespace Hiker.Application.Common.Exceptions
{
    public class RemoteEntityNotFoundException : Exception
    {
        public RemoteEntityNotFoundException()
        {
        }

        public RemoteEntityNotFoundException(string message) : base(message)
        {
        }
    }
}