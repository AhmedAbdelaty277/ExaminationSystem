namespace ExaminationSystem
{
    public class FinalExam : Exam
    {
        public FinalExam() { }

        public FinalExam(DateTime examTime, int numberOfQuestions, int duration) : base(examTime, numberOfQuestions, duration) { }

        public override void EnterQuestions()
        {
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"Enter Details For Question No.{i + 1}");

                Console.Write("Enter Question Type (1 for True/False Question, 2 for MCQ Question) : ");
                int questionType;
                while (!int.TryParse(Console.ReadLine(), out questionType) || (questionType != 1 && questionType != 2))
                {
                    Console.Write("Invalid Input, Please Enter 1 for True/False Question, 2 for MCQ Question : ");
                }

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

                Question question;
                if (questionType == 1)
                {
                    question = new TrueFalseQuestion(header, body, mark);
                }
                else
                {
                    question = new MCQQuestion(header, body, mark);
                }

                question.EnterAnswers();
                Questions.Add(question);
                Console.Clear();
            }
        }

        public override void ShowExam()
        {
            int totalMark = 0;
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
                    totalMark += question.Mark;
                }
            }
        }

        public override void ShowResults()
        {
            Console.Clear();
            Console.WriteLine("Final Exam Results");
            int totalMark = 0;
            int totalMarkForQuestion = 0;

            foreach (var question in Questions)
            {
                Console.WriteLine(question);
                Console.WriteLine($"Your Answer : {question.UserAnswer}");
                Console.WriteLine($"Correct Answer : {question.RightAnswer}");
                Console.WriteLine();
                if (question.UserAnswer == question.RightAnswer)
                {
                    totalMark += question.Mark;
                }
                totalMarkForQuestion += question.Mark;
            }
            Console.WriteLine($"Your Total Mark is : {totalMark} Out Of {totalMarkForQuestion}");
        }
    }
}
