namespace SM3Rewrite
{
    public class Testicle : BodyPart
    {
        public Testicle(Body body) : base(body)
        {
            AppendID("testicle");
        }
        public Testicle(Body body, string side) : base(body)
        {
            AppendID("testicle" + "$" + side);
            name = side;
        }
    }
}
