using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._1
{
    public class Exam: InterfaceDateAndCopy
    {
        public string ?Subject { get; set; }
        public int Score { get; set; }
        public DateTime ExamDate { get; set; }

        // Конструктор з параметрами
        public Exam(string subject, int score, DateTime examDate)
        {
            Subject = subject;
            Score = score;
            ExamDate = examDate;
        }

        // Конструктор за замовчуванням
        public Exam()
        {
            Subject = "Unknown";
            Score = 0;
            ExamDate = DateTime.Now;
        }

        // Перевизначений метод ToString()
        public override string ToString()
        {
            return $"Subject: {Subject}, Grade: {Score}, Exam Date: {ExamDate.ToString()}";
        }

        public Object DeepCopy()
        {
            Exam copy = new Exam();
            copy.Subject = this.Subject;
            copy.Score = this.Score;
            copy.ExamDate = new DateTime(this.ExamDate.Ticks);
            return copy;
        }

        public DateTime Date
        {
            get { return ExamDate; }
            set { ExamDate = value; }
        }
    }


}
