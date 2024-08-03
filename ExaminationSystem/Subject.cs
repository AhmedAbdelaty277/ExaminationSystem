namespace ExaminationSystem
{
    public class Subject : ICloneable, IComparable<Subject>
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam SubjectExam { get; set; }

        public Subject() { }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(Subject other)
        {
            return SubjectId.CompareTo(other.SubjectId);
        }

        public override string ToString()
        {
            return $"SubjectId: {SubjectId}, SubjectName: {SubjectName}";
        }

        public void CreateExam()
        {
            Console.Write("Enter Type Of Exam (1 for Final Eaxm or 2 for Practical Exam) : ");
            int examType;

            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out examType) && (examType == 1 || examType == 2))
                {
                    break;
                }
                else
                {
                    Console.Write("Invalid input. Please enter 1 for Final Exam or 2 for Practical Exam: ");
                }
            }


            Console.Write("Enter The Duration Of The Exam in Minutes : ");
            int duration;

            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out duration) && duration > 0)
                {
                    break;
                }
                else
                {
                    Console.Write("Invalid Input, Please Enter a Positive Number For The Duration : ");
                }
            }

            Console.Write("Enter The Number Of Questions : ");
            int numberOfQuestions;

            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out numberOfQuestions) && numberOfQuestions > 0)
                {
                    break;
                }
                else
                {
                    Console.Write("Invalid Input, Please Enter a Positive Number For The Number Of Questions : ");
                }
            }

            Console.Clear();

            if (examType == 1)
            {
                SubjectExam = new FinalExam(DateTime.Now, numberOfQuestions, duration);
            }
            else
            {
                Console.WriteLine("You Need To Know That Practical Exams Only Allow MCQ Questions");
                SubjectExam = new PracticalExam(DateTime.Now, numberOfQuestions, duration);
            }

            SubjectExam.EnterQuestions();
        }
    }
}
