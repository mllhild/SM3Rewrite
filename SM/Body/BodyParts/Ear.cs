namespace SM3Rewrite
{
    public class Ear : BodyPart
    {
        public Ear(Body body) : base(body)
        {
            AppendID("ear");
        }
        public Ear(Body body, string side) : base(body)
        {
            AppendID("ear" + "$" + side);
            name = side;
        }
    }
}
