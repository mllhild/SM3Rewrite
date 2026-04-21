namespace SM3Rewrite
{
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
}
