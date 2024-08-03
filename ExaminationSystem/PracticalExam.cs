using System;
using System.Reflection.PortableExecutable;

namespace ExaminationSystem
{
    public class PracticalExam : Exam
    {
        public PracticalExam() { }

        public PracticalExam(DateTime examTime, int numberOfQuestions, int duration) : base(examTime, numberOfQuestions, duration) { }

        public override void EnterQuestions()
        {
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"Enter details for Question {i + 1}");

                Console.Write("Enter Question Header : ");
                string header;
                while (string.IsNullOrWhiteSpace(header = Console.ReadLine()))
                {
                    Console.Write("Question Header Can't Be Empty. Please Enter Question Header : ");
                }

                Console.Write("Enter Question Body : ");
                string body;
                while (string.IsNullOrWhiteSpace(body = Console.ReadLine()))
                {
                    Console.Write("Question Body Can't Be Empty, Please Enter Question Body : ");
                }

                Console.Write("Enter Question Mark: ");
                int mark;
                while (true)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out mark) && mark > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Invalid Input, Please Enter a Positive Number For The Question Mark : ");
                    }
                }

                var question = new MCQQuestion(header, body, mark);

                question.EnterAnswers();
                Questions.Add(question);
                Console.Clear();
            }
        }

        public override void ShowExam()
        {
            foreach (var question in Questions)
            {
                Console.WriteLine(question);
                foreach (var answer in question.AnswerList)
                {
                    Console.WriteLine(answer);
                }

                Console.Write("Enter Your Answer : ");
                int answerId;
                while (true)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out answerId) && question.AnswerList.Any(a => a.AnswerId == answerId))
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Invalid Answer, Enter a Valid Answer : ");
                    }
                }

                Console.WriteLine();
                Answer userAnswer = question.AnswerList.Find(a => a.AnswerId == answerId);
                question.UserAnswer = userAnswer;
                if (userAnswer == question.RightAnswer)
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine("Wrong.");
                }
                Console.WriteLine($"Right Answer: {question.RightAnswer}");
                Console.WriteLine();
            }
        }

        public override void ShowResults()
        {
            Console.Clear();
            Console.WriteLine("Practical Exam Results");
            int totalMark = 0;
            int totalMarkForQuestion = 0;

            foreach (var question in Questions)
            {
                Console.WriteLine(question);
                Console.WriteLine($"Your Answer :  {question.UserAnswer}");
                Console.WriteLine($"Correct Answer : {question.RightAnswer}");
                if (question.UserAnswer == question.RightAnswer)
                {
                    totalMark += question.Mark;
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine("Wrong.");
                }
                totalMarkForQuestion += question.Mark;
                Console.WriteLine();
            }
            Console.WriteLine($"Your Total Mark is : {totalMark} Out Of {totalMarkForQuestion}");
        }
    }
}
