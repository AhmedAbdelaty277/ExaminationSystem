namespace ExaminationSystem
{
    public class MCQQuestion : Question
    {
        public MCQQuestion() { }

        public MCQQuestion(string header, string body, int mark) : base(header, body, mark) { }

        public override void EnterAnswers()
        {
            Console.Write("Enter The Number Of Choices : ");
            int numberOfChoices;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out numberOfChoices) && numberOfChoices > 0)
                {
                    break;
                }
                else
                {
                    Console.Write("Invalid input, Please Enter a Positive Integer For The Number Of Choices : ");
                }
            }

            for (int i = 0; i < numberOfChoices; i++)
            {
                Console.Write($"Enter Choice No.{i + 1} : ");
                string choice;
                while (string.IsNullOrWhiteSpace(choice = Console.ReadLine()))
                {
                    Console.Write($"Invalid Input, Please Enter a Valid Choice For Choice No.{i + 1} : ");
                }

                AnswerList.Add(new Answer(i + 1, choice));
            }

            Console.Write("Enter the Correct Answer : ");
            int correctAnswerId;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out correctAnswerId) && AnswerList.Exists(a => a.AnswerId == correctAnswerId))
                {
                    break;
                }
                else
                {
                    Console.Write("Invalid Input, Please Enter a Valid Number That Corresponds To One Of The Choices : ");
                }
            }
            RightAnswer = AnswerList.Find(a => a.AnswerId == correctAnswerId);
        }
    }
}
