using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._1
{
    public class Test
    {
        public string SubjectName { get; set; }
        public bool Passed { get; set; }

        public Test(string subjectName, bool passed)
        {
            SubjectName = subjectName;
            Passed = passed;
        }

        public Test()
        {
            SubjectName = "No subject";
            Passed = false;
        }

        public override string ToString()
        {
            return $"Subject: {SubjectName}, Passed: {Passed}";
        }
    }

}
