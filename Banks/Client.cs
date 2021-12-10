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
            Level = 1;
        }

        public Client(string name, string surname, int passport)
        {
            Name = name;
            Surname = surname;
            Level = 2;
            Passport = passport;
        }

        public int Passport { get; }

        public int Level { get; }

        public string Name { get; }

        public string Surname { get; }
    }
}
