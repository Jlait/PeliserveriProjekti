using System;
using System.Threading.Tasks;
namespace assignment2 {
    public interface IRepository {
        Task<Player> GetPlayer (Guid id);
        Task<Player[]> GetAllPlayers ();
        Task<Player> CreatePlayer (Player player);
        Task<Player> ModifyPlayer (Guid id, ModifiedPlayer player);
        Task<Player> DeletePlayer (Guid id);

        //Item implementations
        Task<Item> GetItem (Guid id, Guid itemID);
        Task<Item[]> GetAllItems(Guid id);
        Task<Item> CreateItem(Guid id, Item item);
        Task<Item> ModifyItem(Guid id, Guid itemID, ModifiedItem item);
        Task<Item> DeleteItem(Guid id, Guid itemID);
    }
}