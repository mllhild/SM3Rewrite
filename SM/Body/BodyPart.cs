using System.Collections.Generic;

namespace SM3Rewrite
{
    public class BodyPart : EntityLvl2 { 
        public Body body;
        public string name;
        public Vector2 position = new Vector2();
        public ErogenousZone eroZone = new ErogenousZone();
        public bool isCutOff = false;

        public Stat size = new Stat();

        public List<BodyPart> parts = new List<BodyPart>();
        public BodyPart(Body body)
        {
            this.body = body;
            AppendID("bp");
        }
    }
}
