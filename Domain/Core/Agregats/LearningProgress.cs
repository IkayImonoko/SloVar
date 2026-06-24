namespace Domain.Core.Agregats;

public class LearningProgress 
{
    public Guid Id { get; private set; }
    public Guid LearnerId { get; private set; }
    public Guid CardId { get; private set; }

    public SrsStage SrsStage { get; private set; }

    public DateTime NextReviewDate { get; private set; }

    public int Streak { get; private set; }
    public int CorrectCount { get; private set; }
    public int WrongCount { get; private set; }
    
    private LearningProgress(Guid learnerId, Guid cardId)
    {
        Id = Guid.NewGuid();
        LearnerId = learnerId;
        CardId = cardId;
        SrsStage = SrsStage.Apprentice;
        NextReviewDate = DateTime.UtcNow;
        Streak = 0;
        CorrectCount = 0;
        WrongCount = 0;
    }
    
    public static LearningProgress Create(Guid learnerId, Guid cardId)
    {
        return new LearningProgress(learnerId, cardId);
    }

    public void RegisterCorrectAnswer()
    {
        CorrectCount++;
        Streak++;

        SrsStage = SrsStage.Next();
        NextReviewDate = SrsStage.CalculateNextReview(DateTime.UtcNow);
    }

    public void RegisterWrongAnswer()
    {
        WrongCount++;
        Streak = 0;

        SrsStage = SrsStage.Previous();
        NextReviewDate = SrsStage.CalculateNextReview(DateTime.UtcNow);
    }
}