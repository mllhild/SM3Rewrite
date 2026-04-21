namespace SM3Rewrite
{
    public class BuffInstance : EntityLvl2
    {
        public BuffDefinition definition;
        public float remainingTime;

        public BuffInstance(BuffDefinition def)
        {
            definition = def;
            remainingTime = def.duration;
        }
    }
}
