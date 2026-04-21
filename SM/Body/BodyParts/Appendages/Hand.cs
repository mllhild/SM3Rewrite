namespace SM3Rewrite
{
    public class Hand : Appendage
    {
        public int fingers;
        public Hand(Body body) : base(body)
        {
            AppendID("hand");
        }
        public Hand(Body body, string side) : base(body)
        {
            AppendID("hand" + "$" + side);
            name = side;
        }
    }
}
