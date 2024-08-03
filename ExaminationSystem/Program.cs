using System.Diagnostics;

namespace ExaminationSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            var subject1 = new Subject(10, "C#");
            subject1.CreateExam();
            Console.Clear();

            char userInput;
            do
            {
                Console.WriteLine("Do You Want To Start The Exam? (Y or N)");
                string input = Console.ReadLine().ToUpper();

                if (input.Length == 1 && (input[0] == 'Y' || input[0] == 'N'))
                {
                    userInput = input[0];
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
                }
            } while (true);

            if (userInput == 'Y')
            {
                var sw = new Stopwatch();
                sw.Start();
                subject1.SubjectExam.ShowExam();
                Console.Clear();
                subject1.SubjectExam.ShowResults();
                Console.WriteLine("The Elapsed Time : " + sw.Elapsed);
            }
            else
            {
                Console.WriteLine("Exam not started.");
            }
        }
    }
}
