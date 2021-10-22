using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp49
{
    class Mark
    {
        public int Mark1 { get; set; }
        public int Mark2 { get; set; }
        public int Mark3 { get; set; }
        public int Average { get; set; }

        private static int count;
        private object studentMark;
        public readonly int Id;

        public Mark(int mark1, int mark2, int mark3):this()
        {
            Mark1 = mark1;
            Mark2 = mark2;
            Mark3 = mark3;          
        }


        public Mark()
        {
            count++;
            Id = count;
        }
        public void AverageOfMarks()
        {
            Average = (Mark1 + Mark2 + Mark3) / 3;
            Console.WriteLine(Average);
        }

        public Mark(object studentMark)
        {
            this.studentMark = studentMark;
        }
    }
}
