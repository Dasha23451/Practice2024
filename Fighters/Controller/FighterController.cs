using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using Fighters.Models.FighterClass;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Fighters.Controller
{
    public class FighterController : IFighterController
    {
        private readonly List<IFighter> _fighters = new List<IFighter>();

        public void CreateFighter()
        {
            Console.Write( "Введите имя бойца: " );
            string name = CheckTheValue( "Имя не может быть пустым. Введите имя:" );
            IFighterClass fighterType = ChooseFighterClass();
            IRace race = ChooseRace();
            IWeapon weapon = ChooseWeapon();
            IArmor armor = ChooseArmor();
            IFighter fighter = new Fighter( name, fighterType, race, weapon, armor );
            _fighters.Add( fighter );
        }

        public List<IFighter> GetFighters()
        {
            return _fighters.ToList();
        }

        private IFighterClass ChooseFighterClass()
        {
            bool isValidChoise = false;
            IFighterClass fighterClass = null;
            while ( !isValidChoise )
            {
                isValidChoise = true;
                string message = "Выберите класс:\n" +
                    "1 - Варвар\n" +
                    "2 - Паладин\n" +
                    "3 - Воин\n" +
                    "4 - Маг\n" +
                    "Ввод: ";
                Console.WriteLine( message );
                string value = CheckTheValue( "Боец не может не иметь класс. Выберите класс бойца:" );
                switch ( value )
                {
                    case "1":
                        fighterClass = new Barbarian();
                        break;
                    case "2":
                        fighterClass = new Paladin();
                        break;
                    case "3":
                        fighterClass = new Warrior();
                        break;
                    case "4":
                        fighterClass = new Wizard();
                        break;
                    default:
                        Console.WriteLine( "Неверный ввод. Попробуйте снова." );
                        isValidChoise = false;
                        break;
                };
            }

            return fighterClass;
        }

        private string CheckTheValue( string message )
        {
            string value = Console.ReadLine();
            while ( string.IsNullOrEmpty( value ) )
            {
                Console.WriteLine( message );
                value = Console.ReadLine();
            }
            return value;
        }

        private IRace ChooseRace()
        {
            IRace race = null;
            bool isValidChoise = false;
            while ( !isValidChoise )
            {
                isValidChoise = true;
                string message = "Выберите расу:\n" +
                    "1 - Драконид\n" +
                    "2 - Эльф\n" +
                    "3 - Человек\n" +
                    "4 - Полуорк\n" +
                    "5 - Тифлинг\n" +
                    "Ввод: ";
                Console.WriteLine( message );
                string value = CheckTheValue( "Боец не может не иметь расу. Выберите расу бойца:" );
                switch ( value )
                {
                    case "1":
                        race = new Draconid();
                        break;
                    case "2":
                        race = new Elf();
                        break;
                    case "3":
                        race = new Human();
                        break;
                    case "4":
                        race = new SemiOrk();
                        break;
                    case "5":
                        race = new Tiefling();
                        break;
                    default:
                        Console.WriteLine( "Неверный ввод. Попробуйте снова." );
                        isValidChoise = false;
                        break;
                };
            }

            return race;
        }

        private IWeapon ChooseWeapon()
        {
            IWeapon weapone = null;
            bool isValidChoise = false;
            while ( !isValidChoise )
            {
                isValidChoise = true;
                string message = "Выберите оружие:\n" +
                    "1 - Топор\n" +
                    "2 - Кулаки\n" +
                    "3 - Гримуар\n" +
                    "4 - Булава\n" +
                    "5 - Копьё\n" +
                    "6 - Меч\n" +
                    "Ввод: ";
                Console.WriteLine( message );
                string value = CheckTheValue( "Обязательно выберите оружие для бойца:" );
                switch ( value )
                {
                    case "1":
                        weapone = new Axe();
                        break;
                    case "2":
                        weapone = new Firsts();
                        break;
                    case "3":
                        weapone = new Grimoire();
                        break;
                    case "4":
                        weapone = new Mace();
                        break;
                    case "5":
                        weapone = new Spear();
                        break;
                    case "6":
                        weapone = new Sword();
                        break;
                    default:
                        Console.WriteLine( "Неверный ввод. Попробуйте снова." );
                        isValidChoise = false;
                        break;
                };
            }

            return weapone;
        }

        public IArmor ChooseArmor()
        {
            IArmor armor = null;
            bool isValidChoise = false;
            while ( !isValidChoise )
            {
                isValidChoise = true;
                string message = "Выберите броню:\n" +
                    "1 - Без брони\n" +
                    "2 - Кожаные доспехи\n" +
                    "3 - Кольчужные доспехи\n" +
                    "4 - Латные доспехи\n" +
                    "Ввод: ";
                Console.WriteLine( message );
                string value = CheckTheValue( "Обязательно выберите броню для бойца:" );
                switch ( value )
                {
                    case "1":
                        armor = new NoArmor();
                        break;
                    case "2":
                        armor = new LeatherArmor();
                        break;
                    case "3":
                        armor = new ChainMailArmor();
                        break;
                    case "4":
                        armor = new PlateArmor();
                        break;
                    default:
                        Console.WriteLine( "Неверный ввод. Попробуйте снова." );
                        isValidChoise = false;
                        break;
                };
            }

            return armor;
        }

    }
}
