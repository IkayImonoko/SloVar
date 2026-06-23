namespace Domain.Core;

public sealed class SrsStage
{
    public static readonly SrsStage Apprentice = new(0, "Apprentice");
    public static readonly SrsStage Guru = new(1, "Guru");
    public static readonly SrsStage Master = new(2, "Master");
    public static readonly SrsStage Enlightened = new(3, "Enlightened");
    public static readonly SrsStage Burned = new(4, "Burned");

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

    private SrsStage(int level, string name)
    {
        Level = level;
        Name = name;
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

    public override string ToString() => Name;
}