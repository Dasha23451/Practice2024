using System.Diagnostics;
using System.Xml.Linq;
using Fighters.Models.Armors;
using Fighters.Models.FighterClass;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters
{
    public class Fighter : IFighter
    {
        public IRace _race { get; }
        public IWeapon _weapon { get; set; }
        public IArmor _armor { get; set; }
        public string _name { get; }
        public IFighterClass _fighterClass { get; }
        public int _currentHealth { get; set; }
        public int _calculateArmor { get; set; }
        public int _maxHealth => _race._health + _fighterClass._health;
        public bool _isAlive => _currentHealth > 0;
        public int Damage => _race._damage + _weapon._damage + _fighterClass._damage;

        public Fighter(
            string name,
            IFighterClass fighterClass,
            IRace race,
            IWeapon weapon,
            IArmor armor )
        {
            _name = name;
            _fighterClass = fighterClass;
            _race = race;
            _weapon = weapon;
            _armor = armor;
            _calculateArmor = race._armor + armor._armor;
            _currentHealth = _maxHealth;
        }

        public int CalculateDamage()
        {
            const int minDamageChange = 80;
            const int maxDamageChange = 110;
            const int criticalPercentChance = 20;

            int fighterDamage = Damage * Random.Shared.Next( minDamageChange, maxDamageChange + 1 ) / 100;

            bool isCriticalAttack = Random.Shared.Next( 1, 101 ) < criticalPercentChance;

            if ( isCriticalAttack )
            {
                fighterDamage *= 2;
            }

            return fighterDamage;
        }

        public int TakeDamage( int damage )
        {
            int gainedDamage;
            if ( _currentHealth < 0 )
            {
                return 0;
            }
            if ( _calculateArmor > damage )
            {
                gainedDamage = 8;
                _calculateArmor -= gainedDamage;
            }
            else
            {
                gainedDamage = damage - _calculateArmor;
                _calculateArmor -= 5;
            }

            if ( gainedDamage > _currentHealth )
            {
                gainedDamage = _currentHealth;
                _currentHealth = 0;
                return gainedDamage;
            }

            _currentHealth -= gainedDamage;
            return gainedDamage;
        }

        public void SetWeapon( IWeapon weapon )
        {
            _weapon = weapon;
        }

        public void SetArmor( IArmor armor )
        {
            _armor = armor;
        }

        public override string ToString()
        {
            return $"Имя бойца: {_name}\n Класс: {_fighterClass._name}\n Раса: {_race._name}\n Оружие: {_weapon._name}\n Броня: {_armor._name}\n Состояние здоровья: {( _isAlive ? "Жив" : "Мертв" )}\n Максимальное здоровье: {_maxHealth}\n Текущее здоровье: {_currentHealth}\n Броня: {_calculateArmor}\n";
        }
    }
}
