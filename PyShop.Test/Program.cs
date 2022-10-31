using System;
using PyShop.Test.Constants;
using PyShop.Test.Extensions;
using PyShop.Test.Models;

namespace PyShop.Test
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Game game = GameExtensions.GenerateGame();

            Console.WriteLine(game);
        }
    }
}
