using System.Collections.Generic;
using Fighters.Controller;
using Fighters.Models.Fighters;
namespace Fighters.Manager;

public class GameManager : IGameManager
{
    private readonly IFighterController _fighterController = new FighterController();
    public void Play()
    {
        bool isExit = false;
        while ( !isExit )
        {
            PrintMenu();
            string command = Console.ReadLine();
            switch ( command )
            {
                case "1":
                    _fighterController.CreateFighter();
                    break;
                case "2":
                    Fight();
                    break;
                case "3":
                    GetFighters();
                    break;
                case "4":
                    isExit = true;
                    break;
                default:
                    Console.WriteLine( $"Команда '{command}' не найдена." );
                    break;
            }
        }
    }

    public void PrintMenu()
    {
        Console.WriteLine( "Введите номер команды:" );
        Console.WriteLine( "1. add-fighter - Добавить нового бойца на арену" );
        Console.WriteLine( "2. play - Начать битву" );
        Console.WriteLine( "3. get fighters - Вывести список бойцов" );
        Console.WriteLine( "4. exit - выход из программы" );
    }

    public void GetFighters()
    {
        if ( _fighterController.GetFighters().Count() > 0 )
        {
            foreach ( IFighter fighter in _fighterController.GetFighters() )
            {
                Console.WriteLine( fighter.ToString() );
            }
        }
        else
        {
            Console.WriteLine( "Бойцы еще не созданы" );
        }
    }

    public void Fight()
    {
        List<IFighter> fighters = _fighterController.GetFighters();
        int round = 0;
        if ( fighters.Count < 2 )
        {
            Console.WriteLine( $"Для начала сражения необходимо добавить двух бойцов. Сейчас всего: {fighters.Count}" );
            return;
        }

        Console.WriteLine( "Выберите двух бойцов для сражения (введите их номера):" );
        IFighter fighter1 = ChooseFighters( "Введите номер первого бойца:" );
        IFighter fighter2 = ChooseFighters( "Введите номер второго бойца:" );

        while ( fighter1._isAlive && fighter2._isAlive )
        {
            Console.WriteLine( $"Раунд {++round}" );

            Battle( fighter1, fighter2 );
        }

        Console.WriteLine( "Состояние бойцов:" );
        GetFighters();
    }

    private IFighter ChooseFighters( string str )
    {
        int num = CheckTheValue( str );
        List<IFighter> list = _fighterController.GetFighters();
        return list[ num ];
    }

    private int CheckTheValue( string str )
    {
        Console.WriteLine( str );
        string value = Console.ReadLine();
        int num;
        while ( !int.TryParse( value, out num ) && ( ( num <= 0 ) || ( num > _fighterController.GetFighters().Count() ) ) )
        {
            Console.WriteLine( str );
            value = Console.ReadLine();
        }
        num--;
        return num;
    }

    public void Battle( IFighter fighter1, IFighter fighter2 )
    {
        int temp = new Random().Next( 2 );
        IFighter fighter = temp == 0 ? fighter1 : fighter2;
        IFighter opponent = temp == 1 ? fighter1 : fighter2;

        int damage = fighter.CalculateDamage();
        int damageTaken = opponent.TakeDamage( damage );
        Console.WriteLine( $"{fighter._name} наносит {damage} урона." );
        Console.WriteLine( $"{opponent._name} получает {damageTaken} урона и {( opponent._isAlive ? "выживает" : "погибает" )}." );

    }
}
