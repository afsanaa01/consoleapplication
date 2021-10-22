using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp49
{
        enum AppMenuSelection
        {
            AddGroup = 1, AddStudent, AddStudentMark, ViewStudentList, FindStudent, DeleteGroup
        }

    class Program
    {
        private static object studentMark;
        

        public static object StudentMark { get => studentMark; set => studentMark = value; }


        static void Main(string[] args)
        {
            
            List<Group> groupContext = new List<Group>();
            List<Student> studentContext = new List<Student>();

            var result = from p in groupContext
                         select p.MaxStudentCount;
            

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Menu: Add Group - 1 | Add Student - 2 | Add Student Mark - 3 | View Student List - 4 | Find Student - 5 | Delete Group - 6 | exit");
                Console.ResetColor();

                string userResponse = Console.ReadLine();

                if (userResponse.ToLower() == "exit")
                {
                    break;
                }
                    
                int selection;
                bool selectionIsValid = int.TryParse(userResponse, out selection);

                if (selectionIsValid && selection >= 1 && selection <= 6)
                {
                    switch (selection)
                    {
                        case (int)AppMenuSelection.AddGroup:

                            Console.Write("Enter group number: ");
                            string groupNumber = Console.ReadLine();
                            if (string.IsNullOrEmpty(groupNumber))
                            {
                                Console.WriteLine("Group number invalid.");
                                break;
                            }

                            Console.Write("Enter group's teacher name: ");
                            string groupTeacher = Console.ReadLine();
                            if (string.IsNullOrEmpty(groupTeacher))
                            {
                                Console.WriteLine("Teacher name invalid.");
                                break;
                            }


                            Console.Write("Enter max student count: ");
                            int Max;
                            bool groupMaxIsValid = int.TryParse(Console.ReadLine(), out Max);
                            if (!groupMaxIsValid)
                            {
                                Console.WriteLine("Max count invalid.");
                                break;
                            }

                           
                            
                            Group newGroup = new Group(groupNumber, groupTeacher);

                            if (groupContext.Contains(newGroup))
                            {
                                Console.WriteLine("Group already exists.");
                                break;
                            }

                            groupContext.Add(newGroup);
                            Console.WriteLine("Group added successfully.");

                            break;
                            
                        case (int)AppMenuSelection.AddStudent:
                            
                            if (groupContext.Count <= 0)
                            {
                                Console.WriteLine("Add a group firstly.");
                                break;
                            }

                            Console.Write("Enter student number in class: ");
                            int studentNumber;
                            bool studenNumberIsValid = int.TryParse(Console.ReadLine(), out studentNumber);
                            if (!studenNumberIsValid)
                            {
                                Console.WriteLine("Count invalid.");
                                break;
                            }

                            if (groupContext.Count > 2)
                            {
                                Console.WriteLine("daxil edilmir");
                                break;
                            }

                            Console.Write("Enter student name: ");
                            string studentName = Console.ReadLine();
                            if (string.IsNullOrEmpty(studentName))
                            {
                                Console.WriteLine("Student name invalid.");
                                break;
                            }

                            Console.Write("Enter Surname: ");
                            string surname = Console.ReadLine();
                            if (string.IsNullOrEmpty(surname))
                            {
                                Console.WriteLine("Surname invalid.");
                                break;
                            }

                            Console.Write("Enter Age: ");
                            int age;
                            bool ageIsValid = int.TryParse(Console.ReadLine(), out age);
                            if (!ageIsValid)
                            {
                                Console.WriteLine("Age invalid.");
                                break;
                            }

                            foreach (Group item in groupContext)
                            {
                                Console.WriteLine(item);
                            }

                          
                            Console.Write("Enter the id of the group that you want to add the student to: ");
                            int studentGroupId;
                            bool studentGroupIdIsValid = int.TryParse(Console.ReadLine(), out studentGroupId);
                            if (!studentGroupIdIsValid)
                            {
                                Console.WriteLine("Group id invalid.");
                                break;
                            }

                            Group groupToAddstudentTo = null;

                            foreach (Group item in groupContext)
                            {
                                if (item.Id == studentGroupId)
                                {
                                    groupToAddstudentTo = item;
                                }
                            }

                            if (groupToAddstudentTo == null)
                            {
                                Console.WriteLine("Group does not exist.");
                                break;
                            }



                            Student newStudent = new Student(studentName, surname, age, studentNumber);
                            

                            if (studentContext.Contains(newStudent))
                            {
                                Console.WriteLine("Student already exists.");
                                break;
                            }

                            studentContext.Add(newStudent);
                            Console.WriteLine("Student added successfully.");
                            
                            break;
                            
                        case (int)AppMenuSelection.AddStudentMark:

                            if (studentContext.Count <= 0)
                            {
                                Console.WriteLine("Add a student firstly.");
                                break;
                            }


                            Console.Write("Enter mark1 between 0 and 100: ");
                            int mark1;
                            bool mark1IsValid = int.TryParse(Console.ReadLine(), out mark1);
                            if (!mark1IsValid || mark1 > 100)
                            {
                                Console.WriteLine("Mark1 invalid.");
                                break;
                            }

                            Console.Write("Enter mark2 between 0 and 100: ");
                            int mark2;                           
                            bool mark2IsValid = int.TryParse(Console.ReadLine(), out mark2);
                            if (!mark1IsValid || mark2 > 100)
                            {
                                Console.WriteLine("Mark2 invalid.");
                                break;
                            }

                            Console.Write("Enter mark3 between 0 and 100: ");
                            int mark3;
                            bool mark3IsValid = int.TryParse(Console.ReadLine(), out mark3);
                            if (!mark1IsValid || mark3>100)
                            {
                                Console.WriteLine("Mark2 invalid.");
                                break;
                            }

                            int Average = (mark1 + mark2 + mark3) / 3;
                            Console.WriteLine($"Average Mark: {Average}");

                            foreach (Student item in studentContext)
                            {
                                Console.WriteLine(item);
                            }

                            Console.Write("Enter the id of the student that you want to add the mark to: ");
                            int markStudentId;
                            bool markStudentIdIsValid = int.TryParse(Console.ReadLine(), out markStudentId);
                            if (!markStudentIdIsValid)
                            {
                                Console.WriteLine("Student id invalid.");
                                break;
                            }

                            Student studentToAddmarkTo = null;

                            foreach (Student item in studentContext)
                            {
                                if (item.Id == markStudentId)
                                {
                                    studentToAddmarkTo = item;
                                }
                            }

                            if (studentToAddmarkTo == null)
                            {
                                Console.WriteLine("Student does not exist.");
                                break;
                            }

                            Mark newMark = new Mark(mark1,mark2,mark3);

                            if (studentToAddmarkTo.AddMark(newMark))
                            {
                                Console.WriteLine("Mark added successfully.");
                            }                          
                            break;

                        case (int)AppMenuSelection.ViewStudentList:

                            foreach (Group item in groupContext)
                            {
                                item.PrintAllStudents();
                            }
                            break;

                        case (int)AppMenuSelection.FindStudent:

                            Console.Write("Enter query: ");
                            string usersQuery = Console.ReadLine();

                            if (string.IsNullOrEmpty(usersQuery))
                            {
                                Console.WriteLine("Query invalid.");
                                break;
                            }

                            foreach (Group item in groupContext)
                            {
                                item.SearchAndPrintStudents(usersQuery);
                            }

                            break;

                        case (int)AppMenuSelection.DeleteGroup:

                            foreach (Group item in groupContext)
                            {
                                Console.WriteLine(item);
                            }

                            Console.Write("Enter the id of the group that you want to delete: ");
                            int deleteGroupId;
                            bool deleteGroupIdIsValid = int.TryParse(Console.ReadLine(), out deleteGroupId);
                            if (!deleteGroupIdIsValid)
                            {
                                Console.WriteLine("Group id invalid.");
                                break;
                            }

                            Group groupToDelete = null;

                            foreach (Group item in groupContext)
                            {
                                if (item.Id == deleteGroupId)
                                {
                                    groupToDelete = item;
                                }
                            }

                            if (groupToDelete == null)
                            {
                                Console.WriteLine("Group does not exist.");
                                break;
                            }

                            groupContext.Remove(groupToDelete);

                            Console.WriteLine("Group deleted successfully.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid menu selection.");
                }
            }
            
        }
    }
}
