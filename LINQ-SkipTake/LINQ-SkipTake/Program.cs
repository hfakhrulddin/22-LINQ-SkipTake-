using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_SkipTake
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] grades = { 59, 82, 70, 56, 92, 98, 85 };
            int[] amounts = { 5000, 2500, 9000, 8000, 6500, 4000, 1500, 5500 };
            string[] fruits1 = { "apple", "banana", "mango", "orange", "passionfruit", "grape" };
            string[] fruits2 = { "apple", "passionfruit", "banana", "mango", "orange", "blueberry", "grape", "strawberry" };

            SkipFirst3grades(grades);
            SkipFirst3more80(grades);
            Top3Grads(grades);
            Skip1000(amounts);
            Fruits1Query(fruits1);
            Fruits2Query(fruits2);

            Console.ReadLine();
        }


        public static void SkipFirst3grades(int[] grades)
        {

            IEnumerable<int> lowerGrades =
                grades
                .OrderByDescending(grad => grad)
                .Skip(3);

            Console.WriteLine("All grades except the top three are:");
            foreach (int grade in lowerGrades)
            {
                Console.WriteLine(grade);
            }

        }

        public static void SkipFirst3more80(int[] grades)
        {

            IEnumerable<int> lowerGrades =
                 grades
                .OrderByDescending(grade => grade)
                .SkipWhile(grade => grade >= 80);

            Console.WriteLine("All grades below 80:");
            foreach (int grade in lowerGrades)
            {
                Console.WriteLine(grade);
            }
        }

        public static void Top3Grads(int[] grades)
        {

            IEnumerable<int> topThreeGrades =
                 grades
                 .OrderByDescending(grade => grade)
                 .Take(3);

            Console.WriteLine("The top three grades are:");
            foreach (int grade in topThreeGrades)
            {
                Console.WriteLine(grade);
            }

            /*
             This code produces the following output:

             The top three grades are:
             98
             92
             85
            */
        }

        public static void Skip1000(int[] amounts)
        {

            IEnumerable<int> query =
                amounts
                .SkipWhile((amount, index) => (amount > index * 1000));

            foreach (int amount in query)
            {
                Console.WriteLine(amount);
            }

            /*
            This code produces the following output:

            4000
            1500
            5500
            */
        }
        public static void Fruits1Query(string[] fruits1)
        {
            IEnumerable<string> query =
                                        fruits1
                                        .TakeWhile(fruit => String.Compare("orange", fruit, true) != 0);

            foreach (string fruit in query)
            {
                Console.WriteLine(fruit);
            }

            /*
            This code produces the following output:

            apple
            banana
            mango
            */
        }

        public static void Fruits2Query(string[] fruits2)
        {
            IEnumerable<string> query =
                                        fruits2
                                        .TakeWhile((fruit, index) => fruit.Length >= index);

            foreach (string fruit in query)
            {
            Console.WriteLine(fruit);
            }

            /*
            This code produces the following output:

            apple
            passionfruit
            banana
            mango
            orange
            blueberry
            */
            }
    }
}
