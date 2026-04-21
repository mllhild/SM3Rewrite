namespace SM3Rewrite
{
    public class Eye : BodyPart
    {
        public ColorRGB irisColor;
        public ColorRGB sclaraColor;
        public PupilType pupilType = PupilType.human;

        public Eye(Body body) : base(body)
        {
            AppendID("eye");
        }
        public Eye(Body body, string side) : base(body)
        {
            AppendID("eye" + "$" + side);
            name = side;
        }
    }


}
