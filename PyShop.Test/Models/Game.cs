using System;
using System.Collections.Generic;
using System.Linq;

namespace PyShop.Test.Models
{
    public class Game
    {
        private readonly GameStamp[] _gameStamps;

        public Game()
        {
            _gameStamps = Array.Empty<GameStamp>();
        }

        public Game(GameStamp[] gameStamps)
        {
            _gameStamps = gameStamps;
        }
        
        public Score? GetScore(int offset)
        {
            int maxOffset = _gameStamps.Max(stamp => stamp.Offset);

            if (offset > maxOffset)
                return null;
            
            GameStamp stamp = _gameStamps.FirstOrDefault(stamp => stamp.Offset == offset);

            if (stamp.Offset == default)
                return null;

            Score score = stamp.Score;

            return score;
        }
        
        public override string ToString()
        {
            IEnumerable<string> stampStrings = _gameStamps.Select(stamp => stamp.ToString());

            return string.Concat(stampStrings);
        }
    }
}