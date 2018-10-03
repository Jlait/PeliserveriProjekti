using System;
using System.Threading.Tasks;
namespace assignment2
{
    public class PlayersProcessor
    {
        public IRepository IMR;

        public PlayersProcessor (IRepository ir)
        {
            IMR = ir;
        }
        public Task<Player> GetPlayer (Guid PlaythroughID, Guid id)
        {
            return IMR.GetPlayer (PlaythroughID, id);
        }
        public Task<Player[]> GetAllPlayers (Guid PlaythroughID)
        {
            return IMR.GetAllPlayers (PlaythroughID);
        }
        public Task<Player> CreatePlayer (Guid PlaythroughID, NewPlayer player)
        {
            Player createePlayer = new Player ();
            createePlayer.id = Guid.NewGuid ();
            createePlayer.Name = player.Name;
            createePlayer.kills = 0;
            createePlayer.deaths = 0;
            return IMR.CreatePlayer (PlaythroughID, createePlayer);
        }
        public Task<Player> ModifyPlayer (Guid PlaythroughID, Guid id, ModifiedPlayer player)
        {
            return IMR.ModifyPlayer (PlaythroughID, id, player);
        }
        public Task<Player> DeletePlayer (Guid PlaythroughID, Guid id)
        {
            return IMR.DeletePlayer (PlaythroughID, id);
        }
    }
}