using System;
using System.Collections.Generic;

namespace lab4
{

    class Notebook
    {
        private List<Person> list;

        public List<Person> List
        {
            get
            {
                return list;
            }
            set
            {
                list = value;
            }
        }
        public Person this[int i]
        {
            get
            {
                return list[i];
            }
            set
            {
                list[i] = value;
            }
        }
        public Notebook()
        {
            list = new List<Person>();
        }
        public Notebook(List<Person> list)
        {
            this.list = list;
        }
        public Notebook(Person person)
        {
            this.list = new List<Person>();
            this.list.Add(person);
        }
        public Notebook(string lastName, DateTime dateOfBirth, int number)
        {
            this.list = new List<Person>();
            this.list.Add(new Person(lastName, dateOfBirth, number));
        }
        public override string ToString()
        {
            string result = "Notebook:\n";
            foreach (Person person in list)
            {
                result += person;
            }
            return result;
        }
        public static Notebook operator +(Notebook n1, Notebook n2)
        {
            List<Person> p1 = n1.List;
            List<Person> p2 = n2.List;
            p1.AddRange(p2);
            return new Notebook(p1);
        }
        public Person Search(string lastName)
        {
            foreach (Person person in list)
            {
                if (person.LastName == lastName)
                {
                    return person;
                }
            }
            return null;
        }
        public Person Add(Person person)
        {
            list.Add(person);
            return person;
        }
        public int Remove(int i)
        {
            list.RemoveAt(i);
            return i;
        }
        public void Sort()
        {
            list.Sort((el1, el2) => el1.LastName.CompareTo(el2.LastName));
        }
        public Person GetByNumber(int number)
        {
            foreach (Person person in list)
            {
                if (person.Number == number)
                {
                    return person;
                }
            }
            return null;
        }
    }
}
