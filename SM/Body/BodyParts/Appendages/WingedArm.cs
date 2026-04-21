namespace SM3Rewrite
{
    public class WingedArm : Appendage
    {
        public Hand clawedHand;
        public WingedArm(Body body) : base(body)
        {
            AppendID("wingedArm");
        }
        public WingedArm(Body body, string side) : base(body)
        {
            AppendID("wingedArm" + "$" + side);
            name = side;
        }
    }
}
