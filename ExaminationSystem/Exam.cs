namespace ExaminationSystem
{
    public abstract class Exam
    {
        public DateTime ExamTime { get; set; }
        public int NumberOfQuestions { get; set; }
        public int Duration { get; set; }
        public List<Question> Questions { get; set; }

        protected Exam() { }

        protected Exam(DateTime examTime, int numberOfQuestions, int duration)
        {
            ExamTime = examTime;
            NumberOfQuestions = numberOfQuestions;
            Duration = duration;
            var questions = new List<Question>();
            Questions = questions;
        }

        public abstract void EnterQuestions();
        public abstract void ShowExam();
        public abstract void ShowResults();
    }
}
