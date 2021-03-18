using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityQueueAssignment
{
    class EmptyListException : ApplicationException
    {
        public EmptyListException(string message) : base(message)
        {
        }
    }
}
