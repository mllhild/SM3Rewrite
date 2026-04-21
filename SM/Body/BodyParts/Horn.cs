namespace SM3Rewrite
{
    public class Horn : BodyPart
    {
        public Horn(Body body) : base(body)
        {
            AppendID("horn");
        }
        public Horn(Body body, string side) : base(body)
        {
            AppendID("horn" + "$" + side);
            name = side;
        }
    }
}
