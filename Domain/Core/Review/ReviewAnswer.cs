namespace Domain.Core.Review;

public class ReviewAnswer
{
    public Guid CardId { get; }

    public bool IsCorrect { get; }

    public DateTime AnsweredAt { get; }

    public ReviewAnswer(
        Guid cardId,
        bool isCorrect)
    {
        CardId = cardId;
        IsCorrect = isCorrect;
        AnsweredAt = DateTime.UtcNow;
    }
}