using System;

namespace lab4
{
    class Person
    {
        private string lastName;
        private DateTime dateOfBirth;
        private int number;

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public char this[int i]
        {
            get
            {
                return lastName[i];
            }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
            }
        }
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }
        public Person()
        {
            lastName = "Ivanov";
            dateOfBirth = new DateTime();
            number = 0;
        }
        public Person(string lastName, DateTime dateOfBirth, int number)
        {
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.number = number;
        }
        public override string ToString()
        {
            return $"Person[last name: {lastName}, birthday: {dateOfBirth}, number: {number}]\n";
        }
        public static Person operator +(Person n1, Person n2)
        {
            return new Person($"{n1.lastName} & {n2.lastName}", new DateTime(), new Random().Next(10) < 5 ? n1.number : n2.number);
        }
        public int CompareTo(Person comparePerson)
        {
            if (comparePerson == null)
            {
                return 1;
            }
            else
            {
                return lastName.CompareTo(comparePerson.LastName);
            }
        }
    }
}
