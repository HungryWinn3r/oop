using System.Collections.Generic;

namespace Isu
{
    public class Ognp
    {
        public Ognp(string name, string fac)
        {
            Name = name;
            Fac = fac;
            StreamsAtOgnp = new List<Stream>();
        }

        public string Name { get; }

        public string Fac { get; }

        public List<Stream> StreamsAtOgnp { get; }
    }
}
