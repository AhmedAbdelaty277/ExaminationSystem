namespace ExaminationSystem
{
    public abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public List<Answer> AnswerList { get; set; }
        public Answer RightAnswer { get; set; }
        public Answer UserAnswer { get; set; }

        protected Question() { }

        protected Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
            var answers = new List<Answer>();
            AnswerList = answers;
        }


        public abstract void EnterAnswers();

        public override string ToString()
        {
            return $"{Header}. {Body} - {Mark} Marks";
        }
    }
}
