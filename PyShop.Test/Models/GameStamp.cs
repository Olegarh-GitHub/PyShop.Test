using System;

namespace PyShop.Test.Models
{
    public struct GameStamp
    {
        public int Offset { get; set; }
        public Score Score { get; set; }

        public GameStamp(int offset, int home, int away)
        {
            Offset = offset;
            Score = new Score(home, away);
        }

        public override string ToString()
        {
            return $"{Offset}: {Score.Home}-{Score.Away}{Environment.NewLine}";
        }
    }
}