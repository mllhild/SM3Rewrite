namespace SM3Rewrite
{
    public class Tentacle : Appendage
    {
        public TentacleType type;
        public Stat width;
        public Tentacle(Body body) : base(body)
        {
            AppendID("tentacle");
        }
    }
}
