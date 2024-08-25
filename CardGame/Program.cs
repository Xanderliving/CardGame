using CardGame.Backend;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {            
            //Reference input class
            var input = new Inputs();
            bool GameRunning = true;
            Console.WriteLine("Welcome to Number Cards. \nPlease enter your list of cards. \nE.g. '2C' or '2C, 3C' \nIf you would like to see your score just type 'Score'\nIf you would like the game to stop type 'Stop'");
            while (GameRunning)
            {
                String response = input.Checker(Console.ReadLine());
                if (response.ToLower() == "stop"){
                    GameRunning = false;
                }
            }
        }
    }
}
