using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections;

namespace LinqLab32
{
    public class Student : IComparable<Student>
    {
        public string Name { set; get; }
        public int Age { set; get; }

        public Student(string NameIn, int AgeIn)
        {
            Name = NameIn;
            Age = AgeIn;
        }

        public int CompareTo(Student other)
        {
            return Age.CompareTo(other.Age);
        }

        public override string ToString()
        {
            string output = "Student(" + Name + "," + Age + ")";
            return output;
        }
    }
    public class Program
    {
        public static int[] nums = { 10, 2330, 112233, 10, 949, 3764, 2942 };
        public static List<int> numsList = nums.ToList();

        public static List<Student> students = new List<Student>();

        static Program()
        {
            students.Add(new Student("Jimmy", 13));
            students.Add(new Student("Hannah Banana", 21));
            students.Add(new Student("Justin", 30));
            students.Add(new Student("Sarah", 53));
            students.Add(new Student("Hannibal", 15));
            students.Add(new Student("Phillip", 16));
            students.Add(new Student("Maria", 63));
            students.Add(new Student("Abe", 33));
            students.Add(new Student("Curtis", 10));
        }

        public static void PrintList(IEnumerable list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("INTs: the minimum value is: " + numsList.Min());
            Console.WriteLine("INTs: the maximum value is: " + numsList.Max());
            Console.WriteLine("INTs: the maximum value less than 10,000 is: " +
            numsList.Where(x => x < 10000).Max());

            Console.WriteLine("INTs: all values between 10 and 100: ");
            PrintList(numsList.Where(x => x <= 100 && x >= 10));

            Console.WriteLine("INTs: all values between 100,000 and 999,999: ");
            PrintList(numsList.Where(x => x <= 999999 && x >= 100000));

            Console.WriteLine("INTs: all evens: ");
            PrintList(numsList.Where(x => x % 2 == 0));

            //For students: 
            //Find all students age of 21 and over(aka US drinking age)
            Console.WriteLine("Find all students age of 21 and over(aka US drinking age)");
            PrintList(students.Where(x => x.Age >= 21));

            Console.WriteLine("\nFind the oldest student");
            Console.WriteLine(students.Max());

            Console.WriteLine("\nFind the youngest student");
            Console.WriteLine(students.Min());

            Console.WriteLine("\nFind the oldest student under the age of 25");
            Console.WriteLine(students.Where(x => x.Age < 25).Max());

            Console.WriteLine("\nFind all students over 21 and with even ages");
            PrintList(students.Where(x => x.Age % 2 == 0 && x.Age > 21));

            Console.WriteLine("\nFind all teenage students(13 to 19 inclusive)");
            PrintList(students.Where(x => x.Age <= 19 && x.Age >= 13));

            Console.WriteLine("\nFind all students whose name starts with a vowel");
            PrintList(students.Where(x => Regex.IsMatch(x.Name, "^[aeiouAEIOU]\\w+")));
        }
    }
}
