using Fighters.Models.Armors;
using Fighters.Models.FighterClass;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters;

public interface IFighter
{
    IRace _race { get; }
    IFighterClass _fighterClass { get; }
    IWeapon _weapon { get; }
    IArmor _armor { get; }
    string _name { get; }
    int _currentHealth { get; }
    int _calculateArmor { get; }
    int _maxHealth { get; }
    bool _isAlive { get; }
    int CalculateDamage();
    int TakeDamage( int damage );
    void SetWeapon( IWeapon weapon );
    void SetArmor( IArmor armor );
}
