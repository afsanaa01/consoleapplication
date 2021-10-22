using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp49
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public List<Mark> Marks { get; set; }
        

        private static int count;
        public readonly int Id;

        public Student()
        {
            count++;
            Id = count;
        }

        public Student(string name, string surname, int age, int studentNumber) :this()
        {
            Name = name;
            Surname = surname;
            Age = age;
        }


        public override string ToString()
        {
            return $"Student: {Id} - Name: {Name} Surname: {Surname} Age: {Age}";
        }

        public override bool Equals(object obj)
        {
            return Name == ((Student)obj).Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        internal bool AddMark(Mark newMark)
        {
            return true;
        }
    }
}
