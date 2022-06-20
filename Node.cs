using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    public class Node
    {
        public Node(string english, string type, string meaning)
        {
            this.english = english;
            this.type = type;
            this.meaning = meaning;

        }
        public Node() { }
        public string english { get; set; }
        public string type { get; set; }
        public string meaning { get; set; }
        public Node Next { get; set; }

        public Node Pre { get; set; }
    }
}
