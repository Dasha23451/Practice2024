using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Manager;
using Fighters.Controller;

namespace Fighters
{
    public class Program
    {
        static void Main( string[] args )
        {
            IGameManager gameManager = new GameManager();
            gameManager.Play();

        }
    }
}
