using System;
using System.Net.NetworkInformation;

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
}
