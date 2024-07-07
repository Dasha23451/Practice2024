using System.Text;

class Program
{

    static Dictionary<string, string> GetDict()
    {
        string filePath = "Dict.txt";
        Dictionary<string, string> dict = new Dictionary<string, string>();
        if ( File.Exists( filePath ) )
        {
            using ( StreamReader reader = new StreamReader( filePath ) )
            {
                while ( !reader.EndOfStream )
                {
                    string s = reader.ReadLine();
                    var str = s.Split( ':' );
                    dict[ str[ 0 ] ] = str[ 1 ];
                }
                reader.Close();
            }
        }
        return dict;
    }

    static void AddTranslate( Dictionary<string, string> dict, string word )
    {
        Console.WriteLine( "Напишите перевод данного слова:" );
        string translate = Console.ReadLine();
        dict[ word ] = translate;
        Console.WriteLine( "Перевод сохранен" );
    }

    static void GetTranslate( Dictionary<string, string> dict )
    {
        string word = Console.ReadLine();
        bool isFound = false;
        foreach ( var key in dict.Keys )
        {
            var value = dict[ key ];
            if ( key == word )
            {
                Console.WriteLine( value );
                isFound = true;
                break;
            }
            else if ( value == word )
            {
                Console.WriteLine( key );
                isFound = true;
                break;
            }
        }

        if ( !isFound )
        {
            Console.WriteLine( "Данное слово отсутствует в словаре. Хотите его добавить? (y/n)" );
            string res = Console.ReadLine();
            if ( res == "y" )
            {
                AddTranslate( dict, word );
            }
            else
            {
                Console.WriteLine( $"Слово {word} было проигнорировано." );
            }
        }


    }

    static void SaveNewDict( Dictionary<string, string> dict )
    {
        string path = "Dict.txt";

        using ( StreamWriter writer = new StreamWriter( path, false ) )
        {
            var sb = new StringBuilder();
            foreach ( var kv in dict )
            {
                sb.AppendLine( $"{kv.Key}:{kv.Value}" );
            }
            string text = sb.ToString();
            writer.Write( text );
        }
    }

    static void PrintMenu()
    {
        Console.WriteLine( "1. Получить перевод слова" );
        Console.WriteLine( "2. Записать перевод слова" );
        Console.WriteLine( "3. Завершить работу с переводчиком" );
    }

    static void Main()
    {
        var dict = GetDict();

        bool isExit = true;
        while ( isExit )
        {
            PrintMenu();
            string res = Console.ReadLine();
            switch ( res )
            {
                case "1":
                    GetTranslate( dict );
                    break;
                case "2":
                    string word = Console.ReadLine();
                    AddTranslate( dict, word );
                    break;
                case "3":
                    isExit = false;
                    SaveNewDict( dict );
                    break;
                default:
                    Console.WriteLine( "Invalid command" );
                    break;
            }
        }

    }

}