namespace SM3Rewrite
{
    public class Appendage : BodyPart
    {
        public Stat thickness;
        public bool isRestrained = false;
        

        public Appendage(Body body) : base(body)
        {
            AppendID("apend");
        }
    }
}
