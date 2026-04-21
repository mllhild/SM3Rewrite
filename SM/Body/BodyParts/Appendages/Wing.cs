namespace SM3Rewrite
{
    public class Wing : Appendage
    {
        public Wing(Body body) : base(body)
        {
            AppendID("wing");
        }
        public Wing(Body body, string side) : base(body)
        {
            AppendID("wing" + "$" + side);
            name = side;
        }
    }
}
