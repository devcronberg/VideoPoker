using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker.Core
{
    public class Game
    {
        private int wallet;

        public Game(int wallet = 25)
        {
            this.wallet = wallet;
        }

        public string Welcome() 
        {
            return File.ReadAllText("welcome.txt");
        }

        public void Start() { 
            
        }

    }
}
