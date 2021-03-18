using System;
using System.Collections.Generic;
using System.Text;

namespace HashTableAssignment
{
    public class KeyNotFoundException : Exception
    {
        public KeyNotFoundException(String message) : base(message)
        {
            
        }
    }
}
