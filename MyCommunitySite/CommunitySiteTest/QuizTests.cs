using MyCommunitySite.Models.Quizz;

namespace CommunitySiteTest;

public class QuizTests
{
    private Quiz _quiz = new Quiz();

    [Fact]
    public void CheckCorrectAnswer()
    {
        Question q1 = new Question()
        {
            Q = "Who is the author of Pet Semetary?",
            A = "Stephen King",
            UserA = "stephen king"
        };
        _quiz.Questions.Add(q1);

        bool isCorrect = _quiz.CheckAnswer(_quiz.Questions.Last());
        Assert.True(isCorrect);
    }

    [Fact]
    public void CheckIncorrectAnswer()
    {
        Question q2 = new Question()
        {
            Q = "Who is the author of the short story Moxon's Master?",
            A = "Ambrose Bierce",
            UserA = "Algernon Blackwood"
        };
        _quiz.Questions.Add(q2);

        bool isCorrect = _quiz.CheckAnswer(_quiz.Questions.Last());
        Assert.False(isCorrect);
    }
}