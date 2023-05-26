using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Task3._1
{
    class Student: Person, InterfaceDateAndCopy
    {

        private Education education;
        private int groupNumber;
        private ArrayList exams;
        private ArrayList tests;

        // Конструктор з параметрами
        public Student(string name,string surname,DateTime birthDate, Education education, int groupNumber, ArrayList exams, ArrayList tests)
            :base(name, surname, birthDate)
        {
            this.education = education;
            this.groupNumber = groupNumber;
            if (groupNumber <= 10 || groupNumber >= 70){throw new ArgumentOutOfRangeException(nameof(groupNumber), groupNumber, $"Group number must be between 11 and 69. Given value: {groupNumber}.");}
            this.exams = new ArrayList(exams.Cast<Exam>()
         .Select(exams => new Exam(exams.Subject, exams.Score, exams.ExamDate)).ToList());
            this.tests = new ArrayList(tests.Cast<Test>()
         .Select(tests => new Test(tests.SubjectName, tests.Passed)).ToList());
        } 
        
        public Student() : base()
        {
            this.education=Education.Bachelor;
            this.groupNumber=0;
            this.exams = new ArrayList();
            this.tests = new ArrayList();
        }


        // Властивість для доступу до поля education
        public Education Education
        {
            get { return education; }
            set { education = value; }
        }

        // Властивість для доступу до поля groupNumber
        public int GroupNumber
        {
            get { return groupNumber; }
            set
            {
                if (value <= 10 || value >= 70)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"Group number must be between 11 and 69. Given value: {value}.");
                }

                groupNumber = value;
            }
        }

        // Властивість для доступу до поля exams
        public ArrayList Tests
        {
            get { return new ArrayList(tests.Cast<Test>().Select(tests => new Test(tests.SubjectName, tests.Passed)).ToList());}
            set { tests = new ArrayList(value.Cast<Test>().Select(tests => new Test(tests.SubjectName, tests.Passed)).ToList());}
        }

        public ArrayList Exams
        {
            get { return new ArrayList(exams.Cast<Exam>().Select(exams => new Exam(exams.Subject, exams.Score, exams.ExamDate)).ToList()); }
            set { exams = new ArrayList(value.Cast<Exam>().Select(exams => new Exam(exams.Subject, exams.Score, exams.ExamDate)).ToList()); }
        }

        public IEnumerable ExamAndTestConut(int minScore=0)
        {
            foreach (var element in exams)
            {
                if (element is Exam exam && exam.Score > minScore)
                {
                    yield return element;
                }

            }

            foreach (var element in tests)
            {
                yield return element;
            }
        }


        public double AverageScore
        {
            get
            {
                if (exams.Count == 0)
                {
                    return 0;
                }

                double sum = 0;
                foreach (Exam exam in exams)
                {
                    sum += exam.Score;
                }

                return sum / exams.Count;
            }
        }

        public bool this[Education ed]
        {
            get { return education == ed; }
        }

        public void AddExams(params Exam[] newExams)
        {
            foreach (Exam exam in newExams)
            {
                exams.Add(new Exam(exam.Subject,exam.Score, exam.ExamDate));
            }
  
        }
        
        public void AddTest(params Test[] newTests)
        {
            foreach (Test test in newTests)
            {
                tests.Add(new Test(test.SubjectName,test.Passed));
            }
        }

        public override string ToString()
        {
            string examsString = "";
            foreach (Exam exam in exams)
            {
                examsString += exam.ToString() + "\n";
            }

            string ispytString = "";
            foreach (Test test in tests)
            {
                ispytString += test.ToString() + "\n";
            }


            return $"Person:\nName: {Name}\nSurname: {Surname}\nBirthday: {birthDate}\nEducation: {education}\nGroup number: {groupNumber}\n\nExams:\n{examsString}\nIspyt:\n{ispytString}\n";
        }

        public virtual string ToShortString()
        {
            return $"Person:\nName: {Name}\nSurname: {Surname}\nBirthday: {birthDate}\nEducation: {education}\nGroup number: {groupNumber}\nAverage score: {AverageScore:F2}\n";
        }

        public virtual object DeepCopy()
        {
            Student copy = new Student(name, surname, birthDate, education, groupNumber, new ArrayList(exams), new ArrayList(tests));
            return copy;
        }


        public static Student Load(string filename)
        {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string name = reader.ReadLine();
                    string surname = reader.ReadLine();
                    DateTime birthDate = DateTime.ParseExact(reader.ReadLine(), "yyyy-MM-dd", null);
                    Education education = (Education)Enum.Parse(typeof(Education), reader.ReadLine());
                    int groupNumber = int.Parse(reader.ReadLine());
                    ArrayList exams = new ArrayList();
                    ArrayList tests = new ArrayList();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');
                        if (fields.Length == 4)
                        {
                            Exam exam = new Exam(fields[0], int.Parse(fields[1]), DateTime.ParseExact(fields[2], "yyyy-MM-dd", null));
                            exams.Add(exam);
                        }
                        else if (fields.Length == 2)
                        {
                            Test test = new Test(fields[0], bool.Parse(fields[1]));
                            tests.Add(test);
                        }
                    }

                    Student student = new Student(name, surname, birthDate, education, groupNumber, exams, tests);
                    return student;
                }
        }




public bool Save(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine(name);
                    writer.WriteLine(surname);
                    writer.WriteLine(birthDate.ToString("yyyy-MM-dd"));
                    writer.WriteLine(education.ToString());
                    writer.WriteLine(groupNumber);

                    writer.WriteLine(exams.Count);
                    foreach (var exam in exams)
                    {
                        writer.WriteLine(exam.ToString());
                    }

                    writer.WriteLine(tests.Count);
                    foreach (var test in tests)
                    {
                        writer.WriteLine(test.ToString());
                    }
                }

                return true;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error while saving student to file {filename}: {ex.Message}");
                return false;
            }
        }
    }

}
