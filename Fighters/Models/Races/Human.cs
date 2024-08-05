namespace Fighters.Models.Races;

public class Human : IRace
{
    public string _name => "Человек";
    public int _damage => 1;
    public int _health => 25;
    public int _armor => 0;
}
