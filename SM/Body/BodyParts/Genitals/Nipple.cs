namespace SM3Rewrite
{
    public class Nipple : BodyPart
    {
        public ColorRGB color;
        public Nipple(Body body) : base(body)
        {
            AppendID("nipple");
        }
        public Nipple(Body body, string side) : base(body)
        {
            AppendID("nipple" + "$" + side);
            name = side;
        }
    }
}
