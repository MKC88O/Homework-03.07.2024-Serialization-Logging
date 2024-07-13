using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Homework_03._07._2024_Serialization_Logging
{
    public delegate void StudentEventHandler(int x);
    public delegate void StudEventHandler();
    public delegate void GroupEventHandler(Student student);
    public delegate void GroupEventHandlerChange(Student student, Group group);
    internal class Program
    {
        static void Main(string[] args)
        {

            Student student = new();
            student.AddTestsRatings(12);
            student.AddCourseWorksRatings(12);
            student.AddExamsRatings(12);

            Student student1 = new("Евгения", "Садова", new DateOnly(2001, 01, 01));
            student1.AddTestsRatings(12);
            student1.AddCourseWorksRatings(12);
            student1.AddExamsRatings(12);

            Student student2 = new("Ирина", "Страт", new DateOnly(2002, 02, 02));
            student2.AddTestsRatings(12);
            student2.AddCourseWorksRatings(12);
            student2.AddExamsRatings(12);

            Student student3 = new("Лилия", "Хачатарян", new DateOnly(2003, 03, 03));
            student3.AddTestsRatings(12);
            student3.AddCourseWorksRatings(12);
            student3.AddExamsRatings(12);

            Student student4 = new("Артем", "Карп", new DateOnly(2004, 04, 04));
            student4.AddTestsRatings(12);
            student4.AddCourseWorksRatings(12);
            student4.AddExamsRatings(12);

            Student student5 = new("Максим", "Федоров-Марущак", new DateOnly(2006, 06, 06));
            student5.AddTestsRatings(12);
            student5.AddCourseWorksRatings(12);
            student5.AddExamsRatings(12);

            Student student6 = new("Виталий", "Огородников", new DateOnly(2006, 06, 06));
            student6.AddTestsRatings(12);
            student6.AddCourseWorksRatings(12);
            student6.AddExamsRatings(12);

            Group group = new();
            group.Add(student);
            group.Add(student1);
            group.Add(student2);
            group.Add(student3);
            group.Add(student4);
            group.Add(student5);
            group.Add(student6);

            var serializer = new XmlSerializer(typeof(Group));
            string path = @"C:\1\XMLSerialize1.xml";
            TextWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, group);
            writer.Close();


            var read = new FileStream(@"C:\1\XMLSerialize1.xml", FileMode.Open, FileAccess.Read);
            var copy = (Group)serializer.Deserialize(read);
            read.Close();
            if (copy is null)
            {
                Console.WriteLine("ERROR!");
            }
            else
            {
                Console.WriteLine("Группа:\t\t" + copy.Name);
                Console.WriteLine("Специализация:\t" + copy.SpecializationOfGroup);
                Console.WriteLine("Курс:\t\t" + copy.NumberOfCourse + "\n");
                Console.WriteLine("Студенты:");
                foreach (var stud in copy.students)
                {
                    Console.WriteLine(stud.Name + " " + stud.LastName);
                    foreach (var courseWorks in stud.CourseWorks)
                    {
                        Console.WriteLine("Курсовые:\t" + courseWorks);
                    }
                    foreach (var exams in stud.Exams)
                    {
                        Console.WriteLine("Экзамены:\t" + exams);
                    }
                    foreach (var tests in stud.Tests)
                    {
                        Console.WriteLine("Зачеты:\t\t" + tests);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
