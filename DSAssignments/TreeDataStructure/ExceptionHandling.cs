using System;
using System.Collections.Generic;
using System.Text;

namespace TreeDataStructure
{
    class ElementDoesNotExistException : ApplicationException
    {
        public ElementDoesNotExistException(string message) : base(message)
        {
        }
    }
}
