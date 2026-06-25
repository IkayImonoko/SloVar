namespace Domain.Core.Learning;

public class LevelProgress
{
    public Guid Id { get; private set; }

    public Guid LearnerId { get; private set; }

    public Guid LevelId { get; private set; }

    public int UnlockedCardsCount { get; private set; }

    public bool IsCompleted { get; private set; }

    private LevelProgress()
    {
    }

    private LevelProgress(
        Guid learnerId,
        Guid levelId,
        int initialUnlockedCards)
    {
        Id = Guid.NewGuid();
        LearnerId = learnerId;
        LevelId = levelId;
        UnlockedCardsCount = initialUnlockedCards;
    }

    public static LevelProgress Create(
        Guid learnerId,
        Guid levelId,
        int initialUnlockedCards)
    {
        return new LevelProgress(
            learnerId,
            levelId,
            initialUnlockedCards);
    }
    
    public void UnlockNextCard(int totalCards)
    {
        if (IsCompleted)
            return;

        if (UnlockedCardsCount < totalCards)
        {
            UnlockedCardsCount++;
        }
    }
    
    public void Complete()
    {
        IsCompleted = true;
    }
}