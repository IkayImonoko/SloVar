namespace Domain.Core.Content;

public class Card
{
    public Guid Id { get; private set; }
    
    public string Norwegian { get; private set; }

    public string Russian { get; private set; }

    public string? Example { get; private set; }

    public string? ExampleTranslation { get; private set; }

    private Card() { }

    private Card(
        string norwegian,
        string russian)
    {
        Id = Guid.NewGuid();
        Norwegian = norwegian;
        Russian = russian;
    }

    public static Card Create(
        string norwegian,
        string russian)
    {
        return new Card(
            norwegian,
            russian);
    }
}