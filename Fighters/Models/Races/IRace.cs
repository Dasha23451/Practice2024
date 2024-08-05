namespace Fighters.Models.Races;

public interface IRace
{
    string _name { get; }
    public int _damage { get; }
    public int _health { get; }
    public int _armor { get; }
}
