using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.FighterClass
{
    public interface IFighterClass
    {
        string _name { get; }
        int _health { get; }
        int _damage { get; }

    }
}
