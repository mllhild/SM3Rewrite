using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace SM3Rewrite
{
    public class Body
    {
        public float height;
        public float weight;
        public Bloodtype type;
        public BloodRhFactor rhFactor;
        public Gender gender;
        public float defautGenitalSizeFactor = 0.25f;

        public Dictionary<string, BodyPart> bodyParts = new Dictionary<string, BodyPart>();

        public int GetCountOfType<T>() where T : BodyPart => bodyParts.Values.Count(part => part is T);
        public IEnumerable<T> GetBodyPartsOfType<T>() where T : BodyPart => bodyParts.Values.OfType<T>();

        public int GetBodyPartsOfType(string typeName)
        {
            switch (typeName)
            {
                case "appendage": return GetCountOfType<Appendage>();
                case "leg": return GetCountOfType<Leg>();
                case "arm": return GetCountOfType<Arm>();
                case "tail": return GetCountOfType<Tail>();
                case "tentacle": return GetCountOfType<Tentacle>();
                case "eye": return GetCountOfType<Eye>();
                case "dick": return GetCountOfType<Dick>();
                case "ball": return GetCountOfType<Testicle>();
                case "breast": return GetCountOfType<Breast>();

                default: return 0;
            }
        }
        public void RemovePartOfType<T>(bool all = true)
        {
            var keysToRemove = new List<string>();
            foreach (var kvp in bodyParts)
                if (kvp.Value is T)
                    keysToRemove.Add(kvp.Key);
            if (all)
                foreach (var key in keysToRemove)
                    bodyParts.Remove(key);
            else
                if(keysToRemove.Count > 0)
                    bodyParts.Remove(keysToRemove[0]);
        }
        public void AddPart(string partType)
        {
            if (string.IsNullOrWhiteSpace(partType))
                return;

            switch (partType.ToLower())
            {
                // Without sides
                case "ass":
                    var ass = new Ass(this);
                    bodyParts.Add(ass.ID, ass);
                    break;

                case "hair":
                    var hair = new Hair(this);
                    bodyParts.Add(hair.ID, hair);
                    break;

                case "hip":
                    var hip = new Hip(this);
                    bodyParts.Add(hip.ID, hip);
                    break;

                case "lips":
                    var lips = new Lips(this);
                    bodyParts.Add(lips.ID, lips);
                    break;

                case "mouth":
                    var mouth = new Mouth(this);
                    bodyParts.Add(mouth.ID, mouth);
                    break;

                case "nose":
                    var nose = new Nose(this);
                    bodyParts.Add(nose.ID, nose);
                    break;

                case "tongue":
                    var tongue = new Tongue(this);
                    bodyParts.Add(tongue.ID, tongue);
                    break;

                case "underbust":
                    var underbust = new Underbust(this);
                    bodyParts.Add(underbust.ID, underbust);
                    break;

                case "weist":
                    var weist = new Waist(this);
                    bodyParts.Add(weist.ID, weist);
                    break;

                case "head":
                    var head = new Head(this);
                    bodyParts.Add(head.ID, head);
                    break;

                case "tail":
                    var tail = new Tail(this);
                    bodyParts.Add(tail.ID, tail);
                    break;

                case "tentacle":
                    var tentacle = new Tentacle(this);
                    bodyParts.Add(tentacle.ID, tentacle);
                    break;

                default:
                    throw new ArgumentException($"Unknown part type: {partType}");
            }
        }
        public void AddPart(string partType, string side)
        {
            if (string.IsNullOrWhiteSpace(partType))
                return;

            switch (partType.ToLower())
            {
                case "arm":
                    var arm = new Arm(this, side);
                    bodyParts.Add(arm.ID, arm);
                    break;

                case "foot":
                    var foot = new Foot(this, side);
                    bodyParts.Add(foot.ID, foot);
                    break;

                case "hand":
                    var hand = new Hand(this, side);
                    bodyParts.Add(hand.ID, hand);
                    break;

                case "leg":
                    var leg = new Leg(this, side);
                    bodyParts.Add(leg.ID, leg);
                    break;

                case "breast":
                    var breast = new Breast(this, side);
                    bodyParts.Add(breast.ID, breast);
                    break;

                case "horn":
                    var horn = new Horn(this, side);
                    bodyParts.Add(horn.ID, horn);
                    break;

                case "ear":
                    var ear = new Ear(this, side);
                    bodyParts.Add(ear.ID, ear);
                    break;

                case "eye":
                    var eye = new Eye(this, side);
                    bodyParts.Add(eye.ID, eye);
                    break;

                default:
                    throw new ArgumentException($"Unknown part type: {partType}");
            }
        }

        #region Templates
        public void UseTemplateHuman(Gender gender)
        {
            bodyParts.Clear();

            Head head = new Head(this);
            bodyParts.Add(head.ID, head);

            Hair hair = new Hair(this);
            bodyParts.Add(hair.ID, hair);

            Ass ass = new Ass(this);
            bodyParts.Add(ass.ID, ass);

            Hip hip = new Hip(this);
            bodyParts.Add(hip.ID, hip);

            Lips lips = new Lips(this);
            bodyParts.Add(lips.ID, lips);

            Mouth mouth = new Mouth(this);
            bodyParts.Add(mouth.ID, mouth);

            Nose nose = new Nose(this);
            bodyParts.Add(nose.ID, nose);

            Tongue tongue = new Tongue(this);
            bodyParts.Add(tongue.ID, tongue);

            Underbust underbust = new Underbust(this);
            bodyParts.Add(underbust.ID, underbust);

            Waist waist = new Waist(this);
            bodyParts.Add(waist.ID, waist);


            switch (gender)
            {
                case Gender.Unknown:
                    break;
                case Gender.Neutral:
                    break;
                case Gender.Male:
                    AddDick();
                    AddTesticles();
                    break;
                case Gender.Female:
                    AddBreasts();
                    AddClit();
                    AddVagina();
                    AddUterus();
                    break;
                case Gender.Futa:
                    AddBreasts();
                    AddDick();
                    AddTesticles();
                    AddVagina();
                    AddUterus();
                    break;
            }
            
            string[] sides = { "L", "R" };

            foreach (string side in sides)
            {
                Arm arm = new Arm(this, side);
                bodyParts.Add(arm.ID, arm);

                Foot foot = new Foot(this, side);
                bodyParts.Add(foot.ID, foot);

                Hand hand = new Hand(this, side);
                bodyParts.Add(hand.ID, hand);

                Eye eye = new Eye(this, side);
                bodyParts.Add(eye.ID, eye);

                Ear ear = new Ear(this, side);
                bodyParts.Add(ear.ID, ear);

                Leg leg = new Leg(this, side);
                bodyParts.Add(leg.ID, leg);
            }

        }
        public void UseTemplateCatgirl(Gender gender, int tailCount = 1)
        {
            UseTemplateHuman(gender);
            for (int i = 0; i < tailCount; i++)
            {
                var part = new Tail(this);
                bodyParts.Add(part.ID, part);
            }
        }
        public void UseTemplateWingedHumanoid(Gender gender, int wingPairs)
        {
            UseTemplateHuman(gender);
            for (int i = 0; i < wingPairs; i++)
            {
                string[] sides = { "L", "R" };
                foreach (string side in sides)
                {
                    var part = new Wing(this, side);
                    bodyParts.Add(part.ID, part);
                }
            }
        }
        public void UseTemplateHarpy(Gender gender)
        {
            RemovePartOfType<Arm>();
            string[] sides = { "L", "R" };
            foreach (string side in sides)
            {
                var part = new WingedArm(this, side);
                bodyParts.Add(part.ID, part);
            }
        }
        public void UseTemplateCentaur(Gender gender)
        {
            UseTemplateHuman(gender);
            string[] sides = { "L", "R" };
            foreach (string side in sides)
            {
                var part = new Leg(this, side);
                bodyParts.Add(part.ID, part);
            }
        }

        public void LoadFromTemplate(string templateID)
        {
            if (!World.data.TryGetValue(templateID, out object entity))
                return;
            BodyTemplateSimple template = entity as BodyTemplateSimple;
            if (template == null) 
                return;
            foreach (var line in template.parts)
            {
                string[] lineParts = line.Trim().Split(',');
                if (lineParts.Length == 1)
                    AddPart(lineParts[0]);
                if(lineParts.Length == 2)
                    AddPart(lineParts[0], lineParts[1]);
            }

        }
        


        #endregion

        #region Gender

        public void AddBreasts()
        {
            if(bodyParts.Values.Count(part => part is Breast) > 0)
                return;
            string[] sides = { "L", "R" };
            foreach (string side in sides)
            {
                var breast = new Breast(this, side);
                breast.size.BaseValue = defautGenitalSizeFactor * breast.size.max;
                bodyParts.Add(breast.ID, breast);
            }
        }
        public void RemoveBreast() => RemovePartOfType<Breast>();
        public void AddDick()
        {
            if (bodyParts.Values.Count(part => part is Dick) > 0)
                return;

            float sizeFactor = defautGenitalSizeFactor;
            if (bodyParts.Values.Count(part => part is Clitoris) > 0)
            {
                var bodyPart = bodyParts.Values.First(part => part is Clitoris) as Clitoris;
                sizeFactor = bodyPart.size.BaseValue / bodyPart.size.max;
            }

            var dick = new Dick(this);
            dick.size.BaseValue = sizeFactor * dick.size.max;
            bodyParts.Add(dick.ID, dick);

        }
        public void RemoveDick() => RemovePartOfType<Dick>();
        public void AddTesticles()
        {
            if (bodyParts.Values.Count(part => part is Testicle) > 0)
                return;

            float sizeFactor = defautGenitalSizeFactor;
            if (bodyParts.Values.Count(part => part is Clitoris) > 0)
            {
                var bodyPart = bodyParts.Values.First(part => part is Clitoris) as Clitoris;
                sizeFactor = bodyPart.size.BaseValue / bodyPart.size.max;
            }

            string[] sides = { "L", "R" };
            foreach (string side in sides)
            {
                var part = new Testicle(this, side);
                part.size.BaseValue = sizeFactor * part.size.max;
                bodyParts.Add(part.ID, part);
            }
        }
        public void RemoveTesticles() => RemovePartOfType<Testicle>();
        public void AddClit() {
            if (bodyParts.Values.Count(part => part is Clitoris) > 0)
                return;

            float sizeFactor = defautGenitalSizeFactor;
            if (bodyParts.Values.Count(part => part is Dick) > 0)
            {
                var bodyPart = bodyParts.Values.First(part => part is Dick) as Dick;
                sizeFactor = bodyPart.size.BaseValue / bodyPart.size.max;
            }

            var clit = new Clitoris(this);
            clit.size.BaseValue = sizeFactor * clit.size.max;
            bodyParts.Add(clit.ID, clit);
        }
        public void RemoveClit() => RemovePartOfType<Clitoris>();
        public void AddVagina() {
            if (bodyParts.Values.Count(part => part is Vagina) > 0)
                return;
            var vagina = new Vagina(this);
            vagina.size.BaseValue = defautGenitalSizeFactor * vagina.size.max;
        }
        public void RemoveVagina() => RemovePartOfType<Vagina>();
        public void AddUterus() {
            if (bodyParts.Values.Count(part => part is Uterus) > 0)
                return;
        }
        public void RemoveUterus() => RemovePartOfType<Uterus>();

        public void ChangeGenderTo(Gender genderNew)
        {
            switch (genderNew)
            {
                case Gender.Unknown:
                    break;
                case Gender.Neutral:
                    RemoveBreast();
                    RemoveDick();
                    RemoveTesticles();
                    RemoveClit();
                    RemoveVagina();
                    break;
                case Gender.Male:
                    AddDick();
                    AddTesticles();
                    
                    RemoveBreast();
                    RemoveClit();
                    RemoveVagina();
                    RemoveUterus();
                    break;
                case Gender.Female:
                    AddBreasts();
                    AddVagina();
                    AddUterus();
                    AddClit();

                    RemoveDick();
                    RemoveTesticles();
                    break;
                case Gender.Futa:
                    AddBreasts();
                    AddDick();
                    AddTesticles();
                    
                    RemoveClit();
                    break;
            }
        }

        #endregion

    }
}
