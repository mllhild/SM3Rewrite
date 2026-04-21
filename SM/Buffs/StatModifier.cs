namespace SM3Rewrite
{
    public class StatModifier
    {
        public string statID;
        public ModifierType type;
        public float value;

        public float Apply(float input)
        {
            switch (type)
            {
                case ModifierType.FlatAdd:      return input + value;
                case ModifierType.PercentAdd:   return input * (1 + value);
                case ModifierType.Multiply:     return input * value;
                default: return input;
            }
        }
    }
}
