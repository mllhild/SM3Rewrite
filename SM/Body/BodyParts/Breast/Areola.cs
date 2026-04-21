namespace SM3Rewrite
{
    public class Areola : BodyPart
    {
        public ColorRGB color;
        public Areola(Body body) : base(body)
        {
            AppendID("areola");
        }
        public Areola(Body body, string side) : base(body)
        {
            AppendID("areola" + "$" + side);
            name = side;
        }
    }
}
