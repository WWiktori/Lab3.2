using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3._1
{
    internal class Person: InterfaceDateAndCopy
    {
        protected string name;
        protected string surname;
        protected System.DateTime birthDate;

        public Person(string name, string surname, DateTime date)
        {
            this.name = name;
            this.surname = surname;
            this.birthDate = date;
        }

        public Person()
        {
            name = "default";
            surname = "default";
            birthDate = DateTime.MinValue;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public int BirthYear
        {
            get { return birthDate.Year; }
            set { birthDate = new DateTime(value, birthDate.Month, birthDate.Day); }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Person other = (Person)obj;
            return name == other.name && surname == other.surname && birthDate == other.birthDate;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + name?.GetHashCode() ?? 0;
                hash = hash * 23 + surname?.GetHashCode() ?? 0;
                hash = hash * 23 + birthDate.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Person p1, Person p2)
        {
            if (object.ReferenceEquals(p1, null))
                return object.ReferenceEquals(p2, null);

            return p1.Equals(p2);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}, born on {2}", name, surname, birthDate.ToString("dd/MM/yyyy"));
        }

        public virtual string ToShortString()
        {
            return string.Format("{0} {1}", name, surname);
        }

        public virtual object DeepCopy()
        {
            Person copy = new Person();
            copy.Name = this.Name;
            copy.Surname = this.Surname;
            copy.BirthDate = new DateTime(this.BirthDate.Ticks);
            return copy;
        }
        public DateTime Date
        {
            get { return birthDate; }
            set { birthDate = value; }
        }
    }
}
