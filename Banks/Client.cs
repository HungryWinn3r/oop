using System;
using System.Collections.Generic;
using System.Text;

namespace Banks
{
    public class Client
    {
        public Client(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string Name { get; }

        public string Surname { get; }
    }
}
