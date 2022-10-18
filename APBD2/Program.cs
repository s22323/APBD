using APBD2.Models;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

class Program
{
    private static String adresPlikuCsv;
    private static String adresDocelowy;
    private static String format;
    static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            throw new ArgumentException("Niepoprawna ilość argumentów");
        }
        adresPlikuCsv = args[0];
        adresDocelowy = args[1];
        format = args[2];

       if(!Directory.Exists(adresPlikuCsv))
        {
            throw new ArgumentException("Podana ścieżka jest niepoprawna");
        }
        if(!File.Exists(adresDocelowy))
        {
            throw new FileNotFoundException("Plik nie istnieje");
        }
        List<String> data = new List<String>();

        FileInfo fi = new FileInfo(adresPlikuCsv);
        StreamReader sr = new StreamReader(fi.OpenRead());
        string line = null;
        while((line = sr.ReadLine()) != null)
        {
            data.Add(line);
        }

        HashSet<Student> students = new HashSet<Student>();
        foreach (string element in data)
        {
            string[] lines = element.Split(",");
            if (lines.Length == 9) {
                bool nowhitespace = true;
                foreach (String s in lines)
                {
                    if(string.IsNullOrWhiteSpace(s))
                    {
                        logError("Pusty rekord");
                        nowhitespace = false;
                    }
                }
                if (nowhitespace = true)
                {
                    Student student = new Student
                    {
                        Imie = lines[0],
                        Nazwisko = lines[1],
                        Kierunek = lines[2],
                        Tryb = lines[3],
                        NrIndeksu = int.Parse(lines[4]),
                        DataUrodzenia = DateTime.Parse(lines[5]),
                        Email = lines[6],
                        ImieMatki = lines[7],
                        ImieOjca = lines[8]
                    };
                    students.Add(student);
                }
            } else
            {
                logError("Zła liczba kolumn");
            }

        }
        Dictionary<string, int> activeStudies = new Dictionary<string, int>();
        foreach (Student student in students)
        {
            if(!activeStudies.ContainsKey(student.Kierunek))
            {
                activeStudies.Add(student.Kierunek, 1);
            } else
            {
                activeStudies[student.Kierunek]++;
            }
        }
        University university = new University();
        university.author = "Marta Peska";
        university.createdAt = DateTime.Now.ToString();
        university.Students = students;
        university.activeStudies = activeStudies;

        StreamWriter sw = new StreamWriter(adresDocelowy);
        string json = JsonSerializer.Serialize(university);
        sw.Write(json);
    }

    private static void logError(string ErrorMessage)
    {
        StreamWriter streamWriter = new StreamWriter(@".\Source\dane.csv");
        streamWriter.WriteLine(ErrorMessage);
    }
}