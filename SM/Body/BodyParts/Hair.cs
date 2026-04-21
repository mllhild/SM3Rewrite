namespace SM3Rewrite
{
    public class Hair : BodyPart
    {
        public ColorRGB color;
        public Stat length;
        public string hairstyleID;

        public Hair(Body body) : base(body)
        {
            AppendID("hair");
        }
    }
}
