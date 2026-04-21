namespace SM3Rewrite
{
    public class Foot : Appendage
    {
        public int toes;
        public Foot(Body body) : base(body)
        {
            AppendID("foot");
        }
        public Foot(Body body, string side) : base(body)
        {
            AppendID("foot" + "$" + side);
            name = side;
        }
    }
}
