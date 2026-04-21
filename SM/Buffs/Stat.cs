using System.Collections.Generic;

namespace SM3Rewrite
{
    public class Stat
    {
        public float BaseValue;
        public float CurrentValue;

        public float modFlatAdd;
        public float modPercentAdd;
        public float modMultiply;

        public float max;
        public float min;

        private readonly List<StatModifier> modifiers = new List<StatModifier>();


        public Stat(float initialValue = 0, float min = 0, float max = 100) { 
            BaseValue = initialValue;
            this.min = min;
            this.max = max;
        }

        public void ChangeValue(float change) { BaseValue += change; }
        public void SetValue(float value) { BaseValue = value; }
        public void Recalculate()
        {
            CurrentValue = (BaseValue * (1+modPercentAdd) + modFlatAdd) * modMultiply;
            if(CurrentValue > max) CurrentValue = max;
                else if (CurrentValue < min) CurrentValue = min;

        }

        public void AddModifiers(List<StatModifier> modifier)
        {
            foreach (var mod in modifiers)
                AddModifier(mod);
        }
        public void RemoveModifiers(List<StatModifier> modifier)
        {
            foreach (var mod in modifiers)
                RemoveModifier(mod);
        }

        public void AddModifier(StatModifier mod)
        {
            modifiers.Add(mod);
            switch (mod.type)
            {
                case ModifierType.FlatAdd: modFlatAdd += mod.value; break;
                case ModifierType.PercentAdd: modPercentAdd += mod.value; break;
                case ModifierType.Multiply: modMultiply += mod.value; break;
            }
            Recalculate();
        }

        public void RemoveModifier(StatModifier mod)
        {
            switch (mod.type)
            {
                case ModifierType.FlatAdd: modFlatAdd -= mod.value; break;
                case ModifierType.PercentAdd: modPercentAdd -= mod.value; break;
                case ModifierType.Multiply: modMultiply -= mod.value; break;
            }
            Recalculate();
        }
    }
}
