using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighters.Models.FighterClass
{
    internal class Paladin : IFighterClass
    {
        public string _name => "Паладин";
        public int _health => 25;
        public int _damage => 20;
    }
}
