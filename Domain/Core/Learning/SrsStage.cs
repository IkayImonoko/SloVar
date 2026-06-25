namespace Domain.Core.Learning;

public sealed class SrsStage
{
    public static readonly SrsStage Apprentice = new(0, "Apprentice",5);
    public static readonly SrsStage Guru = new(1, "Guru",4);
    public static readonly SrsStage Master = new(2, "Master",3);
    public static readonly SrsStage Enlightened = new(3, "Enlightened",2);
    public static readonly SrsStage Burned = new(4, "Burned",0);

    private static readonly SrsStage[] Stages =
    {
        Apprentice,
        Guru,
        Master,
        Enlightened,
        Burned
    };

    public int Level { get; }
    public string Name { get; }
    public int RequiredCorrectAnswers { get; }

    private SrsStage(int level, string name, int requiredCorrectAnswers)
    {
        Level = level;
        Name = name;
        RequiredCorrectAnswers = requiredCorrectAnswers;
    }

    public SrsStage Next()
    {
        if (Level == Stages.Length - 1)
            return this;

        return Stages[Level + 1];
    }

    public SrsStage Previous()
    {
        if (Level == 0)
            return this;

        return Stages[Level - 1];
    }
    public DateTime CalculateNextReview(DateTime now)
    {
        return Level switch
        {
            0 => now.AddHours(4),
            1 => now.AddDays(2),
            2 => now.AddDays(7),
            3 => now.AddDays(30),
            _ => DateTime.MaxValue
        };
    }
    public override string ToString() => Name;
}