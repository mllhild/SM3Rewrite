namespace SM3Rewrite
{
    public class Uterus : BodyPart
    {

        public Ovary ovaryL;
        public Ovary ovaryR;

        public Uterus(Body body) : base(body)
        {
            AppendID("uterus");
            ovaryL = new Ovary(body);
            ovaryR = new Ovary(body);
        }
    }
}
