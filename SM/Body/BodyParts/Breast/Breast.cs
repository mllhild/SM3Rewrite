namespace SM3Rewrite
{
    public class Breast : BodyPart
    {
        public BreastShape shape;
        public BreastSagLevel sagLevel;
        public Areola areola;
        public Nipple nipple;

        public Breast(Body body) : base(body)
        {
            AppendID("breast");
            Initialize(body);
        }
        public Breast(Body body, string side) : base(body)
        {
            AppendID("breast" + "$" + side);
            name = side;
            Initialize(body);
        }

        private void Initialize(Body body)
        {
            areola = new Areola(body);
            areola.size.BaseValue = body.defautGenitalSizeFactor * areola.size.max;
            parts.Add(areola);
            nipple = new Nipple(body);
            nipple.size.BaseValue = body.defautGenitalSizeFactor * nipple.size.max;
            parts.Add(nipple);
        }

        public string GetCupSize()
        {
            if (!body.bodyParts.TryGetValue("underbust", out BodyPart part))
                return "error";
            Underbust underbust = part as Underbust;
            float diff = size.CurrentValue - underbust.size.CurrentValue;

            if (diff < 1f) return "AAA";
            if (diff < 2.5f) return "AA";
            if (diff < 5f) return "A";
            if (diff < 7.5f) return "B";
            if (diff < 10f) return "C";
            if (diff < 12.5f) return "D";
            if (diff < 15f) return "DD";
            if (diff < 17.5f) return "F";
            if (diff < 20f) return "G";
            return "H+";
            
        }
        public string GetDescriptionSize()
        {
            {
                if (!body.bodyParts.TryGetValue("underbust", out BodyPart part))
                    return "error";
                Underbust underbust = part as Underbust;
                float diff = size.CurrentValue - underbust.size.CurrentValue;

                if (diff < 1f) return "non-existent";
                if (diff < 2.5f) return "tiny";
                if (diff < 5f) return "very small";
                if (diff < 7.5f) return "small";
                if (diff < 10f) return "moderate";
                if (diff < 12.5f) return "full";
                if (diff < 15f) return "large";
                if (diff < 17.5f) return "very large";
                if (diff < 20f) return "huge";
                return "gigantic";

            }
        }
        public string GetDescriptionShape() => shape.ToString();
        public string GetDescriptionSagLevel() => sagLevel.ToString();
        
        public void ChangeBreastSize(float change) => size.ChangeValue(change);
        public void SetBreastSize(float value) => size.SetValue(value);
    }
}
