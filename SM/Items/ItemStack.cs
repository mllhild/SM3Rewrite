namespace SM3Rewrite
{
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
}
