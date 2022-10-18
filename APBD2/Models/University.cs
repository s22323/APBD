using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD2.Models
{
    internal class University
    {
        public HashSet<Student> Students { get; set; }
        public string createdAt { get; set; }
        public string author { get; set; }

        public Dictionary<string, int> activeStudies;
    }
}
