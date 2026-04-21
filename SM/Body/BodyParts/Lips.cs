namespace SM3Rewrite
{
    public class Lips : BodyPart
    {
        public float fullness;
        public ColorRGB color;
        public Lips(Body body) : base(body)
        {
            AppendID("lips");
        }
    }
}
