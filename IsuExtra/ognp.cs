using System.Collections.Generic;

namespace Isu
{
    public class Ognp
    {
        public Ognp(string name, string faculty)
        {
            Name = name;
            Faculty = faculty;
            StreamsAtOgnp = new List<Stream>();
        }

        public string Name { get; }

        public string Faculty { get; }

        public List<Stream> StreamsAtOgnp { get; }
    }
}
