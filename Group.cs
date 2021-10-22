using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp49
{
    class Group
    {
        public string Number { get; set; }
        public string TeacherName { get; set; }

        public List<Student> Students { get; set; }

        public int MaxStudentCount
        {
            get
            {
                int result = 0;
                foreach (Student item in Students)
                {
                    result += item.Id;
                }
                return result;
            }
        }

        private static int count;
        public readonly int Id;

        public Group()
        {
            count++;
            Id = count;
            Students = new List<Student>();
        }

        public Group(string number, string teachername) : this()
        {
            Number = number;
            TeacherName = teachername;

        }

        public override string ToString()
        {
            return $"Group: {Id} - Number: {Number} Teacher's name: {TeacherName} Max student count: {MaxStudentCount} Student Count: {Students.Count}";
        }

        public override bool Equals(object obj)
        {
            return Number == ((Group)obj).Number;
        }

        public bool AddStudent(Student student)
        {
            int count = Students.Count;

            if (Students.Contains(student))
            {
                return false;
            }

            Students.Add(student);
            return true;
        }

        public bool RemoveStudent(int id)
        {
            int count = Students.Count;

            for (int i = 0; i < count; i++)
            {
                if (Students[i].Id == id)
                {
                    Students.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public void PrintAllStudents()
        {
            foreach (Student item in Students)
            {
                Console.WriteLine($"{Number}-daki {item}");
            }
        }

        public void SearchAndPrintStudents(string query)
        {
            bool resultFound = false;
            foreach (Student item in Students)
            {
                if (item.Name.Contains(query))
                {
                    Console.WriteLine($"{item} in Group {Number} ");
                    resultFound = true;
                }
            }

            if (resultFound)
            {
                Console.WriteLine($"No results found in {Number}.");
            }
        }

    }
}
