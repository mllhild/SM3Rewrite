namespace SM3Rewrite
{
    public class Leg : Appendage
    {
        public Foot foot;
        public Leg(Body body) : base(body)
        {
            AppendID("leg");
        }
        public Leg(Body body, string side) : base(body)
        {
            AppendID("leg" + "$" + side);
            name = side;
        }
    }
}
