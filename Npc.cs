using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace SM3Rewrite
{
    public class Npc : BasicUnit
    {
        public Name name;
        public Gender gender;
        public Rank rank;
        public Body body;

        public ItemContainer inventory;
        public ItemContainer equippedItems;

        #region Name

        public string FormalRankSurname() => String.Join(" ", new[] { RankOf(), name.surename });
        public string FormalRankSurnameWithMiddle() => String.Join(" ", new[] { RankOf(), name.GetMiddleNameSurname() });
        public string FormalRankNameFull() => String.Join(" ", new[] { RankOf(), name.GetFullName() });

        #endregion

        #region Gender

        public string HeShe()
        {
            switch (gender)
            {
                case Gender.Unknown:    return "they";  
                case Gender.Neutral:    return "it";    
                case Gender.Male:       return "he";    
                case Gender.Female:     return "she";   
                case Gender.Futa:       return "she";   
                default:                return "error, gender out of bounds: " + gender.ToString();
            }
        }

        public string WasWere()
        {
            switch (gender)
            {
                case Gender.Unknown:    return "were";
                default:                return "was";
            }
        }

        public string HimHer()
        {
            switch (gender)
            {
                case Gender.Unknown: return "them";
                case Gender.Neutral: return "it";
                case Gender.Male: return "him";
                case Gender.Female: return "her";
                case Gender.Futa: return "her";
                default: return "error, gender out of bounds: " + gender.ToString();
            }
        }
        
        public string HisHer()
        {
            switch (gender)
            {
                case Gender.Unknown: return "their";
                case Gender.Neutral: return "its";
                case Gender.Male: return "his";
                case Gender.Female: return "her";
                case Gender.Futa: return "her";
                default: return "error, gender out of bounds: " + gender.ToString();
            }
        }

        public string MrMs()
        {
            switch (gender)
            {
                case Gender.Unknown: return "Mr";
                case Gender.Neutral: return "Mr";
                case Gender.Male: return "Mr";
                case Gender.Female: return "Ms";
                case Gender.Futa: return "Ms";
                default: return "error, gender out of bounds: " + gender.ToString();
            }
        }

        public string MrMrs()
        {
            switch (gender)
            {
                case Gender.Unknown: return "Mr";
                case Gender.Neutral: return "Mr";
                case Gender.Male: return "Mr";
                case Gender.Female: return "Mrs";
                case Gender.Futa: return "Mrs";
                default: return "error, gender out of bounds: " + gender.ToString();
            }
        }

        public string SirDame()
        {
            switch (gender)
            {
                case Gender.Unknown: return "Sir";
                case Gender.Neutral: return "Sir";
                case Gender.Male: return "Sir";
                case Gender.Female: return "Dame";
                case Gender.Futa: return "Dame";
                default: return "error, gender out of bounds: " + gender.ToString();
            }
        }

        public string LordLady()
        {
            switch (gender)
            {
                case Gender.Unknown: return "Lord";
                case Gender.Neutral: return "Lord";
                case Gender.Male: return "Lord";
                case Gender.Female: return "Lady";
                case Gender.Futa: return "Lady";
                default: return "error, gender out of bounds: " + gender.ToString();
            }
        }

        public string ClericalPriest()
        {
            switch (gender)
            {
                case Gender.Unknown: return "Priest";
                case Gender.Neutral: return "Priest";
                case Gender.Male: return "Priest";
                case Gender.Female: return "Priestess";
                case Gender.Futa: return "Priestess";
                default: return "error, gender out of bounds: " + gender.ToString();
            }
        }

        public string ClericalSister()
        {
            switch (gender)
            {
                case Gender.Unknown: return "Brother";
                case Gender.Neutral: return "Brother";
                case Gender.Male: return "Brother";
                case Gender.Female: return "Sister";
                case Gender.Futa: return "Sister";
                default: return "error, gender out of bounds: " + gender.ToString();
            }
        }

        public string RankOf()
        {
            switch (rank)
            {
                case SM3Rewrite.Rank.Commoner:
                        return MrMs();
                case SM3Rewrite.Rank.Noble:
                    return LordLady();
                case SM3Rewrite.Rank.Knight:
                    return SirDame();
                case SM3Rewrite.Rank.Clergy:
                    return ClericalSister();
                default: return "error, rank out of bounds: " + gender.ToString();
            }

            
        }

        #endregion

        #region Body



        #endregion

        #region Inventory and Equipment



        #endregion

    }

    public class Name
    {
        public string surename;
        public string name;
        public string middleName;
        public string title;
        public string nickName;
        public void SetName(string name = "", string surename = "", string middleName = "", string nickName = "")
        {
            this.name = name;
            this.surename = surename;
            this.middleName = middleName;   
            this.nickName = nickName;
        }
        public void SetTitle(string title)
        {
            this.title = title;
        }
        public string GetName() => this.name;
        public string GetSurname() => this.surename;
        public string GetMiddleName() => this.middleName;
        public string GetMiddleNameSurname() => 
            RemoveDuplicateWhitespace(String.Join(" ", new[] { middleName, surename }));
        public string GetFullName() => 
            RemoveDuplicateWhitespace(String.Join(" ", new[] { name, middleName, surename }));
        public string GetFullNameWithShortMiddle() =>
            RemoveDuplicateWhitespace(String.Join(" ", new[] { name, middleName.Length > 0 ? middleName.Substring(0, 1) + "." : "", surename }));
        public string GetFullNameJP() => 
            RemoveDuplicateWhitespace(String.Join(" ", new[] {  middleName, surename, name })); 
        public string GetFullNameWithTitle() => 
            RemoveDuplicateWhitespace(String.Join(" ", new[] { title, name, middleName, surename}));
        public string GetNameWithTitle() => 
            RemoveDuplicateWhitespace(String.Join(" ", new[] { title, middleName, surename }));
        public string GetNameWithTitleWithoutMiddleName() => 
            RemoveDuplicateWhitespace(String.Join(" ", new[] { title, surename }));
        public string GetInnitials() => 
            RemoveDuplicateWhitespace(String.Join(" ", new[] { 
            name.Length > 0 ? name.Substring(0,1)+"." : "",
            middleName.Length > 0 ? middleName.Substring(0,1)+"." : "",
            surename.Length > 0 ? surename.Substring(0,1)+"." : "",  }));

        public string RemoveDuplicateWhitespace(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            return Regex.Replace(text.Trim(), @"\s+", " ");
        }
    }

    public enum Gender
    {
        Unknown = -1,
        Neutral = 0,
        Male = 1,
        Female = 2,
        Futa = 3,
    }

    public enum Rank
    {
        Commoner,
        Noble,
        Knight,
        Clergy
    }



    public class BasicUnit
    {
        public Dictionary<string, Stat> stats = new Dictionary<string, Stat>();
        public Dictionary<string, BuffInstance> activeBuffs = new Dictionary<string, BuffInstance>();
    }

    public class Stat
    {
        public float BaseValue;
        public float CurrentValue;

        public float modFlatAdd;
        public float modPercentAdd;
        public float modMultiply;

        private readonly List<StatModifier> modifiers = new List<StatModifier>();

        public void Recalculate()
        {
            CurrentValue = (BaseValue * (1+modPercentAdd) + modFlatAdd) * modMultiply;
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

    public enum ModifierType
    {
        FlatAdd,
        PercentAdd,
        Multiply
    }

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

    public class BuffDefinition : EntityLvl2
    {
        public float duration;
        public List<StatModifier> modifiers;
    }

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

    public class Body
    {
        public float height;
        public float weight;
        public Bloodtype type;
        public BloodRhFactor rhFactor;

        public Dictionary<string, BodyPart> bodyParts = new Dictionary<string, BodyPart>();
    }

    public enum Bloodtype
    {
        None = 0,
        A = 1,
        B = 2,
        AB = 3,
        O = 4
    }
    public enum BloodRhFactor
    {
        None = 0,
        plus = 1,
        minus = 2
    }


    public class ErogenousZone
    {
        public bool isErogenous = false;
        public float senitivity;
        public ErogenousZone()
        {
        }
    }
    public class BodyPart : EntityLvl2 { 
        public string name;
        public Vector2 position = new Vector2();
        public ErogenousZone eroZone = new ErogenousZone();
        public BodyPart(string name)
        {
            this.name = name;
        }
    }
    public class Hair : BodyPart
    {
        public ColorRGB color;
        public float length;
        public string hairstyleID;
        public Hair(string name) : base(name)
        {
        }
    }
    public class Ear : BodyPart
    {
        public Ear(string name) : base(name)
        {
        }
    }
    public class Eye : BodyPart
    {
        public ColorRGB color;
        public Eye(string name) : base(name)
        {
        }
    }
    public class Nose : BodyPart
    {
        public Nose(string name) : base(name)
        {
        }
    }
    public class Mouth : BodyPart
    {
        public Mouth(string name) : base(name)
        {
        }
    }
    public class Bust : BodyPart
    {
        public float size;
        public Bust(string name) : base(name)
        {
        }
    }
    public class Waist : BodyPart
    {
        public float size;
        public Waist(string name) : base(name)
        {
        }
    }
    public class Hip : BodyPart
    {
        public float size;
        public Hip(string name) : base(name)
        {
        }
    }

    public class Appendage : BodyPart
    {
        public float lenght;
        public float thickness;
        public bool isRestrained = false;
        public Appendage(string name) : base(name)
        {
        }
    }
    public class Arm : Appendage
    {
        public Hand hand;
        public Arm(string name) : base(name)
        {
        }
    }
    public class Leg : Appendage
    {
        public Foot foot;
        public Leg(string name) : base(name)
        {
        }
    }
    public class Tail : Appendage
    {
        public Tail(string name) : base(name)
        {
        }
    }
    public class Hand : Appendage
    {
        public int fingers;
        public Hand(string name) : base(name)
        {
        }
    }
    public class Foot : Appendage
    {
        public int toes;
        public Foot(string name) : base(name)
        {
        }
    }
    public class Tentacle : Appendage
    {
        public TentacleType type;
        public float length;
        public float width;
        public Tentacle(string name) : base(name)
        {
        }
    }

    public enum TentacleType
    {

    }

    
    public class Lips : BodyPart
    {
        public float width;
        public float fullness;
        public ColorRGB color;
        public Lips(string name = "lips") : base(name)
        {
        }
    }
    public class Tongue : BodyPart
    {
        public float lenght;
        public Tongue(string name = "tongue") : base(name)
        {
        }
    }
    public class Breast : BodyPart
    {
        public float size;
        public BreastShape shape;
        public BreastSagLevel sagLevel;

        public Breast(string name) : base(name)
        {
        }
    }
    public enum BreastShape
    {
        Round,          // evenly full, symmetrical
        Teardrop,       // fuller at bottom, natural slope
        EastWest,       // nipples point outward
        SideSet,        // wider gap between breasts
        CloseSet,       // minimal gap
        Athletic,       // less fatty tissue, firmer
        Bell,           // narrow top, fuller lower portion
        Relaxed,        // mild natural sag
        Ptotic,         // pronounced sagging
        Tubular,        // elongated, narrow base
        Asymmetrical    // noticeable size/shape difference
    }

    public enum BreastSagLevel
    {
        None,
        Mild,
        Moderate,
        Severe
    }

    public class Areola : BodyPart
    {
        public float size;
        public ColorRGB color;
        public Areola(string name) : base(name)
        {
        }
    }

    public class Nipple : BodyPart
    {
        public float size;
        public ColorRGB color;
        public Nipple(string name) : base(name)
        {
        }
    }
    public class Ass : BodyPart
    {
        public float size;
        public Ass(string name) : base(name)
        {
        }
    }
    public class Dick : BodyPart
    {
        public float length;
        public float diameter;
        public Dick(string name) : base(name)
        {
        }
    }
    public class Balls : BodyPart
    {
        public float size;
        public int count;
        public Balls(string name) : base(name)
        {
        }
    }
    public class Vagina : BodyPart
    {
        public float length;
        public float diameter;
        public Vagina(string name) : base(name)
        {
        }
    }
    public class Clitoris : BodyPart
    {
        public float size;
        public Clitoris(string name) : base(name)
        {
        }
    }

    public class Item : EntityLvl2
    {
        public string itemType;
        
    }
    public class Equipment : Item
    {
        public string name;
        public int difficultyToUnequip;
    }
    public class EquipmentSlot : EntityLvl2
    {
        public string slotType;
        public string slotName;
        
        public string equipmentID = null;

        public bool isDisabled;
        public bool isVisible;

        public bool isOccupied() { 
            if (equipmentID == null) return false;
            if (equipmentID == "") return false;
            return true;
        }

        public void AddEquipment(Equipment equipment)
        {
            if (isDisabled) 
                return;
            if(isOccupied())
            {
                if(!RemoveEquipment(equipmentID))
                    return;
            }
            equipmentID = equipment.ID;
        }
        public bool RemoveEquipment(string newEquipmentID, int removalPower = 0)
        {
            if (World.equipment[newEquipmentID].difficultyToUnequip > removalPower)
                return false;
            equipmentID = newEquipmentID;
            return true;
        }
    }
    public class ItemStack : Item
    {
        public int count;
        public void AddItemToStack(Item item)
        {
            if (item == null) return;
            if (item.itemType != this.itemType) return;
            count++;
        }
        public bool RemoveItemFromStack(int quantity) { 
            if(quantity > count) 
                return false;
            return true;
        }
    }

    public class ItemContainer : EntityLvl2
    {
        public Dictionary<string, ItemStack> itemStacks = new Dictionary<string, ItemStack>();
        public Dictionary<string, Equipment> equipments = new Dictionary<string, Equipment>();
        public void AddItemstack(ItemStack stack) { itemStacks[stack.ID] = stack; }
        public void RemoveItemstack(ItemStack stack) { itemStacks.Remove(stack.ID); }
        public void MergeItemStacks()
        {
            var merged = new Dictionary<string, ItemStack>();

            foreach (var stack in itemStacks.Values)
            {
                if (merged.TryGetValue(stack.itemType, out var existing))
                {
                    existing.count += stack.count;
                }
                else
                {
                    merged[stack.itemType] = new ItemStack
                    {
                        itemType = stack.itemType,
                        count = stack.count
                    };
                }
            }

            itemStacks = merged;
        }
        public IOrderedEnumerable<KeyValuePair<string, Equipment>> SortEquipment() {
            var sorted = equipments.OrderBy(e => e.Value.name);
            return sorted; 
        }
        public IOrderedEnumerable<KeyValuePair<string, ItemStack>> SortItems()
        {
            MergeItemStacks();
            var sorted = itemStacks.OrderBy(e => e.Value.itemType);
            return sorted;
        }

    }

    public class ItemContainerDisplay : EntityLvl2
    {
        public Vector2Int gridSize;
        // this way resizing the inventory screen doesnt make problems
        public Dictionary<int, string> slotsWithItems = new Dictionary<int, string>();
        public ItemContainer itemContainer = new ItemContainer();

        public void SortItems()
        {
            slotsWithItems.Clear();
            int count = 0;
            var sortedEquipment = itemContainer.SortEquipment();
            foreach (var equip in sortedEquipment)
            {
                slotsWithItems[count] = equip.Key;
                count++;
            }
            var sortedItems = itemContainer.SortItems();
            foreach (var item in sortedItems)
            {
                slotsWithItems[count] = item.Key;
                count++;
            }
        }
    }


    public static class World
    {
        public static Dictionary<string, Equipment> equipment = new Dictionary<string, Equipment>();
    }

    public class  Vector2
    {
        public float x, y;
    }
    public class Vector2Int
    {
        public int x, y;
    }
    public class ColorRGB
    {
        float r, g, b;
    }

    public enum Size
    {
        tiny,
        small,
        average,
        large,
        huge,
        gigantic,
    }
    public class SizeToSize
    {
        private List<float> sizes;

        public SizeToSize(float[] limits = null)
        {
            if (limits == null)
                limits = new float[] { 10, 20, 30, 40, 50 };

            sizes = limits.ToList();

            // Safety: ensure correct length
            if (sizes.Count != Enum.GetValues(typeof(Size)).Length - 1)
                throw new ArgumentException("Limits must be one less than enum count.");
        }

        public Size GetSizeFromNumber(float value)
        {
            for (int i = 0; i < sizes.Count; i++)
            {
                if (value < sizes[i])
                    return (Size)i;
            }

            return Size.gigantic; // last category
        }
    }
}
