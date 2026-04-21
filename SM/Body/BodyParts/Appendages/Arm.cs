namespace SM3Rewrite
{
    public class Arm : Appendage
    {
        public Hand hand;
        public Arm(Body body) : base(body)
        {
            AppendID("arm");
        }
        public Arm(Body body, string side) : base(body)
        {
            AppendID("arm"+"$"+side);
            name = side;
        }
    }
}
