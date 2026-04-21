using System.Collections.Generic;

namespace SM3Rewrite
{
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
}
