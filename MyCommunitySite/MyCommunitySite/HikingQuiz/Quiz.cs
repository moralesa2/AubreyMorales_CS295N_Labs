namespace MyCommunitySite.HikingQuiz
{
    public class Quiz
    {
        private List<Question> _questions = new List<Question>();

        public Quiz()
        {
            _questions.Add(new Question()
            {
                Q = "What is the most popular outdoor activity in the United States?",
                A = "Hiking",
                UserA = "",
            });
        }

        public List<Question> Questions
        {
            get { return _questions; }
        }

        public bool CheckAnswer(Question q)
        {
            return q.UserA.ToLower() == q.A.ToLower();
        }
    }
}
/* https://www.advnture.com/features/hiking-facts */