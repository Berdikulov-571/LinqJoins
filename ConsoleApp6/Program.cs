using Microsoft.VisualBasic;

namespace ConsoleApp6
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student() {firstName = "Sanjarbek",lastName = "Berdikulov",Age = 17,Course = 1},
                new Student() {firstName = "Alisher",lastName = "Alisherov",Age = 15,Course = 2},
                new Student() {firstName = "Jonibek",lastName = "Sardorov",Age = 17,Course = 3},
                new Student() {firstName = "Abu Bakr",lastName = "Muminov",Age = 18,Course = 4},
                new Student() {firstName = "Javohir",lastName = "Sanjarbekov",Age = 19,Course = 1},
                new Student() {firstName = "Sardor",lastName = "Abu Bakirov",Age = 17,Course = 2},
                new Student() {firstName = "Muhammad",lastName = "Umarov",Age = 15,Course = 3},
                new Student() {firstName = "Azizbek",lastName = "Aizibekov",Age = 16,Course = 4},
                new Student() {firstName = "Alisher",lastName = "Jonibekov",Age = 17,Course = 1},
                new Student() {firstName = "Madina",lastName = "Nosirov",Age = 18,Course = 2},
                new Student() {firstName = "Javdod",lastName = "Nosirov",Age = 19,Course = 3},
                new Student() {firstName = "Muhlisa",lastName = "Sayidjonova",Age = 17,Course = 4},
                new Student() {firstName = "Abu Bakr",lastName = "Muminov",Age = 15,Course = 1},
                new Student() {firstName = "Ali",lastName = "Kimdur",Age = 16,Course = 2},
                new Student() {firstName = "Pulat",lastName = "Berdikulov",Age = 17,Course = 3},
                new Student() {firstName = "Memati",lastName = "Berdikulov",Age = 19,Course = 4},
                new Student() {firstName = "Suhrob",lastName = "Berdikulov",Age = 18,Course = 1},
                new Student() {firstName = "Ulug'bek",lastName = "Abdullohov",Age = 15,Course = 2},
                new Student() {firstName = "Bekzod",lastName = "Bekzodov",Age = 16,Course = 3},
                new Student() {firstName = "Diyorbek",lastName = "Azizbekov",Age = 17,Course = 4},
                new Student() {firstName = "Abdulloh",lastName = "Berdikulov",Age = 18,Course = 1},
            };

            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher() {firstName = "Kamoliddin",lastName = "Bekmirzayev",Course = 3},
                new Teacher() {firstName = "Sardor",lastName = "Sohibnazarov",Course = 1},
                new Teacher() {firstName = "Shohruh",lastName = "Nosirov",Course = 2},
                new Teacher() {firstName = "Muhammad Abdulloh",lastName = "Komilov",Course = 4},
            };

            var result = teachers.GroupJoin(students,
                                            teacher => (teacher.Course,teacher.lastName),
                                            student => (student.Course, student.lastName),
                                            (teachers, students) => new
                                            {
                                                teacher = teachers,
                                                student = students
                                            }).ToList();

            //foreach (var i in result)
            //{
            //    Console.WriteLine($"Teacher: {i.teacher.firstName} {i.teacher.lastName} {i.teacher.Course}");
            //    foreach (var j in i.student)
            //    {
            //        Console.WriteLine($"{j.firstName} {j.lastName} {j.Course}");
            //    }
            //    Console.WriteLine();
            //}

            //Console.WriteLine("---------------------------------------------");



            //var JoinResult = teachers.Join(students,
            //                               teacher => teacher.Course,
            //                               student => student.Course,
            //                               (teachers,students) => new
            //                               {
            //                                   teacher = teachers,
            //                                   student = students
            //                               }).ToList();

            //foreach (var i in JoinResult)
            //{
            //    Console.WriteLine($"S:{i.student.firstName} {i.student.Course}");
            //    Console.WriteLine($"T:{i.teacher.firstName} {i.teacher.Course}");
            //}

            var GroupJoin = teachers.GroupJoin(students,
                                               teachers => teachers.Course,
                                               students => students.Course,
                                               (teachers,students) => new
                                               {
                                                   teacher = teachers,
                                                   student = students
                                               }).ToList();

            foreach (var i in GroupJoin)
            {
                Console.WriteLine($"Teacher: {i.teacher.firstName} {i.teacher.lastName} {i.teacher.Course}");
                Console.WriteLine("Students: ");
                foreach (var j in i.student)
                {
                    Console.WriteLine($"{j.firstName} {j.lastName} {j.Course}");
                }
                Console.WriteLine("------------------------------------------------------");
            }


        }
    }
    class Student
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int Age { get; set; }
        public int Course { get; set; }
    }

    class Teacher
    {
        public string firstName { get; set;}
        public string lastName { get; set;}
        public int Course { get; set;}
    }
}