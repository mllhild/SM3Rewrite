namespace SM3Rewrite
{
    public class BuffManager
    {
        public void ApplyBuff(BasicUnit unit, BuffDefinition buff)
        {
            BuffInstance instance = new BuffInstance(buff);
            unit.activeBuffs[instance.ID] = instance;

            foreach (StatModifier mod in buff.modifiers)
            {
                if (unit.stats.TryGetValue(mod.statID, out var stat))
                {
                    stat.AddModifier(mod);
                }
            }
        }

        public void RemoveBuff(BasicUnit unit, BuffInstance buff)
        {
            foreach (StatModifier mod in buff.definition.modifiers)
            {
                if (unit.stats.TryGetValue(mod.statID, out var stat))
                {
                    stat.RemoveModifier(mod);
                }
            }
            unit.activeBuffs.Remove(buff.ID);
        }

        public void UpdateBuffs(BasicUnit unit, float deltaTime)
        {
            foreach(var buff in unit.activeBuffs)
            {
                BuffInstance buffInstance = unit.activeBuffs[buff.Key];
                buffInstance.remainingTime -= deltaTime;
                if(buffInstance.remainingTime <= 0)
                    RemoveBuff(unit, buffInstance);
            }
        }
    }
}
