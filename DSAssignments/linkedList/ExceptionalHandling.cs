using System;
using System.Collections.Generic;
using System.Text;

namespace linkedList
{

    //if user tries to delete from empty list
     class EmptyListException : ApplicationException
     {
        public EmptyListException(string message) : base(message)
        {
        }
     }
    //if user enter invalid index
     class InvalidIndexInputException : ApplicationException
     {
        public InvalidIndexInputException(string message) : base(message)
        {
        }
     }
}
