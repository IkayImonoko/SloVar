public class Level
{
    public Guid Id { get; private set; }
    
    public int Number { get; private set; }
    
    private readonly List<Card> _cards = [];
    
    public IReadOnlyCollection<Card> Cards => _cards;
}