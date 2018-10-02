using System;
using System.Threading.Tasks;
namespace assignment2
{
    public class ItemProcessor
    {
        IRepository IP;
        public ItemProcessor (IRepository _IP)
        {
            IP = _IP;
        }
        public Task<Item> GetItem (Guid id, Guid itemID)
        {
            return IP.GetItem (id, itemID);
        }
        public Task<Item[]> GetAllItems (Guid id)
        {
            return IP.GetAllItems (id);
        }
        public async Task<Item> CreateItem (Guid id, NewItem item)
        {
            Player player = await IP.GetPlayer(id);
            if(item.Type == 0 && player.level<3){
                throw new LevelUnderThree("Sword, Type 0 weapon, requires player level 3 or above!");
            }
            Item createeItem = new Item ();
            createeItem.id = Guid.NewGuid ();
            createeItem.Level = item.Level;
            createeItem.Type = item.Type;
            createeItem.CreationTime = DateTime.Now;
            
            return await IP.CreateItem (id, createeItem);
        }
        public Task<Item> ModifyItem (Guid id, Guid itemID, ModifiedItem item)
        {
            return IP.ModifyItem (id, itemID, item);
        }
        public Task<Item> DeleteItem (Guid id, Guid itemID)
        {
            return IP.DeleteItem (id, itemID);
        }
    }
}