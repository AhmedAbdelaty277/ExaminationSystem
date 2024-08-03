namespace ExaminationSystem
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion() { }

        public TrueFalseQuestion(string header, string body, int mark) : base(header, body, mark) { }

        public override void EnterAnswers()
        {
            AnswerList.Add(new Answer(1, "True"));
            AnswerList.Add(new Answer(2, "False"));

            Console.Write("Enter The Correct Answer (1 for True or 2 for False) : ");
            int correctAnswerId;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out correctAnswerId) && (correctAnswerId == 1 || correctAnswerId == 2))
                {
                    break;
                }
                else
                {
                    Console.Write("Invalid input, Please Enter 1 for True or 2 for False : ");
                }
            }

            RightAnswer = AnswerList.Find(a => a.AnswerId == correctAnswerId);
        }
    }
}
