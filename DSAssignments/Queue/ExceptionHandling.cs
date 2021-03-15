using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    //if user tries to delete from empty list
    class EmptyListException : ApplicationException
    {
        public EmptyListException(string message) : base(message)
        {
        }
    }




}
