namespace MyCommunitySite.Models.Quizz
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

            _questions.Add(new Question()
            {
                Q = "What is the oldest hiking trail in America that is still used?",
                A = "Crawford Path",
                UserA = "",
            });

            _questions.Add(new Question()
            {
                Q = "What is the oldest hiking trail in europe?",
                A = "Via Francigena",
                UserA = "",
            });

            _questions.Add(new Question()
            {
                Q = "How many visitors does the Appalachian Trail receive annually?",
                A = "2 million",
                UserA = "",
            });

            _questions.Add(new Question()
            {
                Q = "What is the average hiking speed (mph)?",
                A = "2.5 mph",
                UserA = "",
            });

            _questions.Add(new Question()
            {
                Q = "What is the name of the longest trail in the world?",
                A = "Great Trail",
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