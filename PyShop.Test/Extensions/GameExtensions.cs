using System;
using PyShop.Test.Constants;
using PyShop.Test.Models;

namespace PyShop.Test.Extensions
{
    public static class GameExtensions
    {
        private static readonly Random _random = new Random();
        
        public static GameStamp GenerateGameStamp(GameStamp previous)
        {
            bool scoreChanged = _random.NextDouble() > 1d - GameConstants.PROBABILITY_SCORE_CHANGED;
            
            int homeScoreChange = scoreChanged && _random.NextDouble() > 1d - GameConstants.PROBABILITY_HOME_SCORE 
                ? 1
                : 0;
            
            int awayScoreChange = scoreChanged && homeScoreChange == 0 
                ? 1 
                : 0;
            
            int offsetChange = (int)(Math.Floor(_random.NextDouble() * GameConstants.OFFSET_MAX_STEP)) + 1;

            int generatedOffset = previous.Offset + offsetChange;
            int generatedHomeScore = previous.Score.Home + homeScoreChange;
            int generatedAwayScore = previous.Score.Away + awayScoreChange;
            
            return new GameStamp
            (
                generatedOffset,
                generatedHomeScore,
                generatedAwayScore
            );
        }
        
        public static Game GenerateGame()
        {
            int stampsCount = GameConstants.TIMESTAMPS_COUNT;
            
            GameStamp[] stamps = new GameStamp[stampsCount];

            GameStamp currentStamp = new GameStamp(0, 0, 0);
            for (int i = 0; i < GameConstants.TIMESTAMPS_COUNT; i++)
            {
                stamps[i] = currentStamp;
                currentStamp = GenerateGameStamp(currentStamp);
            }

            return new Game(stamps);
        }
    }
}