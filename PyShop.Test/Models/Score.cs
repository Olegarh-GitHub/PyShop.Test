namespace PyShop.Test.Models
{
    public struct Score
    {
        public int Home { get; set; }
        public int Away { get; set; }

        public Score(int home, int away)
        {
            Home = home;
            Away = away;
        }
    }
}