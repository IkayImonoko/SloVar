namespace Domain.Core.Review;

public class ReviewSession
{
    public Guid Id { get; private set; }

    public Guid LearnerId { get; private set; }

    public DateTime StartedAt { get; private set; }

    public DateTime? FinishedAt { get; private set; }

    private readonly List<ReviewAnswer> _answers = [];

    public IReadOnlyCollection<ReviewAnswer> Answers => _answers;

    private ReviewSession()
    {
    }

    private ReviewSession(Guid learnerId)
    {
        Id = Guid.NewGuid();
        LearnerId = learnerId;
        StartedAt = DateTime.UtcNow;
    }

    public static ReviewSession Start(Guid learnerId)
    {
        return new ReviewSession(learnerId);
    }
    
    public void AnswerCard(
        Guid cardId,
        bool isCorrect)
    {
        if (FinishedAt is not null)
            throw new InvalidOperationException(
                "Session is finished.");

        _answers.Add(
            new ReviewAnswer(
                cardId,
                isCorrect));
    }
    public void Finish()
    {
        if (!_answers.Any())
            throw new InvalidOperationException(
                "Cannot finish empty session.");

        FinishedAt = DateTime.UtcNow;
    }
}