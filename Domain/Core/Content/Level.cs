namespace Domain.Core.Content;

public class Level
{
    public Guid Id { get; private set; }
    
    public int Number { get; private set; }
    
    private readonly List<Card> _cards = [];
    private Level(int number)
    {
        Id = Guid.NewGuid();
        Number = number;
    }

    public static Level Create(int number)
    {
        return new(number);
    }

    public void AddCard(
        string norwegian,
        string russian)
    {
        _cards.Add(
            Card.Create(
                norwegian,
                russian));
    }
    public IReadOnlyCollection<Card> Cards => _cards;
}