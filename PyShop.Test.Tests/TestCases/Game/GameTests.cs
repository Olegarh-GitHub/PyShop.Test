using System;
using PyShop.Test.Extensions;
using Xunit;
using PyShop.Test.Models;
using Xunit.Abstractions;

namespace PyShop.Test.Tests.TestCases.Game
{
    public class GameTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(94550)]
        [InlineData(23400)]
        [InlineData(99234)]
        [InlineData(234)]
        [InlineData(5596)]
        [InlineData(356)]
        [InlineData(4354)]
        [InlineData(0)]
        public void GetScore_ForRandomGeneratedGame_Test(int offset)
        {
            Models.Game game = GameExtensions.GenerateGame();

            Exception exception = Record.Exception(() => game.GetScore(offset));
            
            Assert.Null(exception);
        }

        [Fact]
        public void GetHalfQuarterHomeScore_ForHandGeneratedGame_Test()
        {
            Models.Game game = HandGeneratedGame();

            Score? scoreByOffset = game.GetScore(75);
            
            Assert.NotNull(scoreByOffset);

            int homeScoreFact = scoreByOffset.Value.Home;
            
            Assert.Equal(3, homeScoreFact);
        }
        
        [Fact]
        public void GetQuarterAwayScore_ForHandGeneratedGame_Test()
        {
            Models.Game game = HandGeneratedGame();

            Score? scoreByOffset = game.GetScore(25);
            
            Assert.NotNull(scoreByOffset);

            int awayScoreFact = scoreByOffset.Value.Away;
            
            Assert.Equal(0, awayScoreFact);
        }
        
        [Fact]
        public void GetNullScore_ForHandGeneratedGame_Test()
        {
            Models.Game game = HandGeneratedGame();

            Score? scoreByOffset = game.GetScore(int.MaxValue);
            
            Assert.Null(scoreByOffset);
        }

        #region Mock data

        private Models.Game HandGeneratedGame()
        {
            GameStamp gameStamp = new GameStamp(0, 0, 0);
            GameStamp gameStampQuarter = new GameStamp(25, 1, 0);
            GameStamp gameStampHalf = new GameStamp(45, 2, 2);
            GameStamp gameStampHalfQuarter = new GameStamp(75, 3, 4);
            GameStamp gameStampFull = new GameStamp(90, 4, 5);

            GameStamp[] stamps = new[]
            {
                gameStamp,
                gameStampQuarter,
                gameStampHalf,
                gameStampHalfQuarter,
                gameStampFull
            };
            
            Models.Game game = new Models.Game(stamps);

            return game;
        }

        #endregion
    }
}