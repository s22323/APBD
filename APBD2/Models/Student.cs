using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD2.Models
{
    internal class Student
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Kierunek { get; set; }
        public string Tryb { get; set; }
        public int NrIndeksu { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public String Email { get; set; }
        public String ImieMatki { get; set; }
        public String ImieOjca { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Student student &&
                   Imie == student.Imie &&
                   Nazwisko == student.Nazwisko;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Imie, Nazwisko);
        }
    }
}
