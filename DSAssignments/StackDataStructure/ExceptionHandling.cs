using System;
using System.Collections.Generic;
using System.Text;

namespace StackDataStructure
{
    class EmptyListException : ApplicationException
    {
        public EmptyListException(string message) : base(message)
        {
        }
    }
}
