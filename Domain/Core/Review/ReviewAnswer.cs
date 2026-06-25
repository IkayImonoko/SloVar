namespace Domain.Core.Review;

public class ReviewAnswer(Guid cardId, bool isCorrect)
{
    public Guid CardId { get; }

    public bool IsCorrect { get; }

    public DateTime AnsweredAt { get; }
}