using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml.Linq;
using Task3._1;
using System.Collections.Specialized;

class Program
{
    static void Main(string[] args)
    {

        Console.OutputEncoding = UTF8Encoding.UTF8;

        ArrayList exams = new ArrayList()
        {
            new Exam("Programming Basics", 45, new DateTime(2022, 1, 15)),
            new Exam("Algorithms and Data Structures", 32, new DateTime(2022, 1, 20)),
            new Exam("Object-Oriented Programming", 45, new DateTime(2022, 1, 25)),
        };

        ArrayList tests = new ArrayList()
        {
            new Test("Math", true),
            new Test("English", false),
            new Test("Biologi",true),
        };

        Student student = new Student("John", "Doe", new DateTime(2000, 1, 1), Education.Bachelor, 45, exams, tests);


        Console.WriteLine($"Виведення даних про студента в короткому форматі:\n{student.ToShortString()}");

        Console.WriteLine("Виведення значення індексатора для різних значень Education:");
        Console.WriteLine($"Is education Bachelor? {student[Education.Bachelor]}");
        Console.WriteLine($"Is education Specialist? {student[Education.Specialist]}");
        Console.WriteLine($"Is education SecondEducation? {student[Education.SecondEducation]}\n");

        Console.WriteLine("Зміна значень властивостей та виведення даних про студента в повному форматі:");
        student.Name = "Jane";
        student.Surname = "Smith";
        student.GroupNumber = 54;
        student.Education = Education.Specialist;
        Console.Write(student.ToString());

        //Проводжу провірку на глибоку копію за властивостями інкапсуляції 
        exams[0]=new Exam("Programming", 85, new DateTime(2022, 1, 15));
        tests[0]=new Test("IT", true);

        Console.WriteLine("Додавання нових елементів до списку іспитів та виведення даних про студента:");
        student.AddExams(new Exam("Databases", 54, new DateTime(2022, 2, 1)), new Exam("Web Development", 75, new DateTime(2022, 2, 5)));
        Console.WriteLine(student.ToString());


        //Звіт за іспити та тести студента
        Console.WriteLine("Звіт за іспити та тести студента:");
        foreach (var element in student.ExamAndTestConut())
        {
            Console.WriteLine(element);
        }

        Console.WriteLine("\nЗвіт за іспити та тести студента з оцінкою більше 40:");
        foreach (var element in student.ExamAndTestConut(40))
        {
            Console.WriteLine(element);
        }


        //вивести значення хешкодів для об'єктів
        Person person1 = new Person("John", "Doe", new DateTime(1990, 1, 1));
        Person person2 = new Person("John", "Doe", new DateTime(1990, 1, 1));

        if (object.ReferenceEquals(person1, person2))
        {
            Console.WriteLine("\nObject references are equal");
        }
        else if (person1.Equals(person2))
        {
            Console.WriteLine("\nObject values are equal");
        }

        Console.WriteLine("Hash code for person1: {0}", person1.GetHashCode());
        Console.WriteLine("Hash code for person2: {0}", person2.GetHashCode());

        //Вивести значення тих властивостей для об'єкту типу Student, які отримали від Person:
        Console.WriteLine("\nЗначення тих властивостей для об'єкту типу Student, які отримали від Person:");
        Console.WriteLine($"Name: {student.Name}");
        Console.WriteLine($"Surname: {student.Surname}");
        Console.WriteLine($"Birthday: {student.BirthDate}");

        //Здопомогою методу DeepCopy  ()створити повну копію об'єкта Student.
        Student student1 = (Student)student.DeepCopy();
        Console.Write($"\nПовна копія обєкту:\n{student1}");
        Console.WriteLine("\nЗміна значень властивостей та виведення даних про студента в повному форматі:");
        student.Name = "Mike";
        student.Surname = "Derry";
        student.GroupNumber = 43;
        student.Education = Education.SecondEducation;
        Console.Write(student.ToString());
        Console.Write($"\nПровірка копії обєкту:\n{student1}");

        //У блоці try / catch привласнити властивості з номером групи некоректне значення
        Console.Write($"Провірка на коректність умов номера групи:\n");
        try
        {
            Student s = new Student("John", "Doe", new DateTime(2000, 1, 1), Education.Bachelor, 90, exams, tests);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        //Random rand = new Random();
        //int count= rand.Next(7, 10);
        //int Size = rand.Next(2, 2);

        //using (StreamWriter writer = new StreamWriter("E:\\C#\\Task3.1\\file.txt"))
        //{
        //    // Генеруємо випадкові дані для 10 студентів та записуємо їх у файл
        //    Random random = new Random();

        //    for (int i = 0; i < count; i++)
        //    {
        //        string name = "Student" + (i + 1);
        //        string surname = "Surname" + (i + 1);
        //        DateTime birthDate = new DateTime(random.Next(1980, 2005), random.Next(1, 13), random.Next(1, 29));
        //        Education education = (Education)random.Next(0, 3);
        //        int groupNumber = random.Next(11, 69);
        //        string Subject = "Subject" + (i+1);
        //        int Score = random.Next(0, 100);
        //        DateTime ExamDate = new DateTime(random.Next(2006, 2023), random.Next(1, 13), random.Next(1, 29));
        //        string SubjectName = "SubjectName"+ (i+1);
        //        bool randomBool = random.Next(2) == 0;
        //        writer.WriteLine($"{name};{surname};{birthDate};{education};{groupNumber};{Subject};{Score};{ExamDate};{SubjectName};{randomBool}");
        //    }
        //}

        Console.WriteLine("\nСтуденти, які здали всі заліки та іспити:");
        //string filename = "E:\\C#\\Task3.1\\file.txt";
        //ArrayList students = new ArrayList();
        //using (StreamReader reader = new StreamReader(filename))
        //{
        //    string line;
        //    while ((line = reader.ReadLine()) != null)
        //    {
        //        students.Add(line);

        //    }


        //}
        ////Console.WriteLine($"{students[0]}\n");
        ////Console.WriteLine($"{students[1]}\n");
        ////Console.WriteLine($"{students[2]}\n");
        ////Console.WriteLine($"{students[3]}\n");

        ////foreach (Student st in students.OfType<Student>())
        ////{
        ////    //var examList = st.Exams.OfType<Exam>().Where(a => a.Score > 51).ToList();
        ////    //var testList = st.Tests.OfType<Test>().Where(a => a.Passed == true).ToList();
        ////    if (examList.Count == st.Exams.Count && testList.Count == st.Tests.Count)
        ////    {
        ////        Console.WriteLine(st);
        ////    }
        ////}
        //foreach (var item in students)
        //{
        //    if (item is Student student6)
        //    {
        //        var passedExams = student6.Exams.OfType<Exam>().Where(e => e.Score > 51).ToList();
        //        Console.WriteLine($"Student: {student6.Name}, Passed exams: {string.Join(", ", passedExams.Select(e => e.Subject))}");
        //    }
        //}
        ArrayList students = new ArrayList();
        string filename = "E:\\C#\\Task3.1\\file.txt";
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var stud = Student.Load(line);
                if (stud != null && stud.Exams != null && stud.Exams.Count > 0)
                {
                    bool allGradesAbove51 = true;
                    foreach (Exam exam in stud.Exams)
                    {
                        if (exam.Score <= 51)
                        {
                            allGradesAbove51 = false;
                            break;

                        }
                    }
                    if (allGradesAbove51)
                    {
                        students.Add(stud);
                    }
                }
            }
        }

        // вивід інформації про студентів з балами вищими за 51
        foreach (Student stud in students)
        {
            Console.WriteLine("Student: " + stud.Name + " " + stud.Surname);
            Console.WriteLine("Birth date: " + stud.BirthDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("Education: " + stud.Education);
            Console.WriteLine("Group number: " + stud.GroupNumber);
            Console.WriteLine("Exams:");
            foreach (Exam exam in stud.Exams)
            {
                Console.WriteLine("- " + exam.Subject + ": " + exam.Score + " (" + exam.ExamDate.ToString("yyyy-MM-dd") + ")");
            }
            Console.WriteLine("Tests:");
            foreach (Test test in stud.Tests)
            {
                Console.WriteLine("- " + test.SubjectName + ": " + test.Passed);
            }
            Console.WriteLine();
        }


    }
}
