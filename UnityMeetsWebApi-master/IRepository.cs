using System;
using System.Threading.Tasks;
namespace assignment2 {
    public interface IRepository {
        Task<Player> GetPlayer (Guid id, Guid PlaythroughID);
        Task<Player[]> GetAllPlayers (Guid PlaythroughID);
        Task<Player> CreatePlayer (Guid PlaythroughID, Player player);
        Task<Player> ModifyPlayer (Guid PlaythroughID, Guid id, ModifiedPlayer player);
        Task<Player> DeletePlayer (Guid PlaythroughID, Guid id);

        //Playthrough implementations
        Task<Playthrough> GetPlaythrough (Guid PlaythroughID);
        Task<PTListObj> GetAllPlaythroughs();
        Task<Playthrough> CreatePlaythrough(Playthrough Playthrough);
        Task<Playthrough> ModifyPlaythrough(Guid PlaythroughID, Playthrough Playthrough);
        Task<Playthrough> DeletePlaythrough(Guid PlaythroughID);
    }
}