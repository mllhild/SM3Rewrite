using System.Collections.Generic;

namespace SM3Rewrite
{
    public class BasicUnit
    {
        public Dictionary<string, Stat> stats = new Dictionary<string, Stat>();
        public Dictionary<string, BuffInstance> activeBuffs = new Dictionary<string, BuffInstance>();
    }
}
