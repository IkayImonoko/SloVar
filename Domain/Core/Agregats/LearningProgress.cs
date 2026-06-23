namespace Domain.Core.Agregats;

public class LearningProgress
{
    public Guid LearnerId { get; private set; }
    public Guid CardId { get; private set; }

    public SrsStage SrsStage { get; private set; }

    public DateTime NextReviewDate { get; private set; }

    public int Streak { get; private set; }
    public int CorrectCount { get; private set; }
    public int WrongCount { get; private set; }

    public void RegisterCorrectAnswer(DateTime nextReviewDate)
    {
        CorrectCount++;
        Streak++;

        SrsStage = SrsStage.Next();
        NextReviewDate = nextReviewDate;
    }

    public void RegisterWrongAnswer(DateTime nextReviewDate)
    {
        WrongCount++;
        Streak = 0;

        SrsStage = SrsStage.Previous();
        NextReviewDate = nextReviewDate;
    }
}