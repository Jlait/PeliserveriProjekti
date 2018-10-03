using System;
using System.Threading.Tasks;
namespace assignment2
{
    public class PlaythroughProcessor
    {
        IRepository IP;
        public PlaythroughProcessor (IRepository _IP)
        {
            IP = _IP;
        }
        public Task<Playthrough> GetPlaythrough (Guid PlaythroughID)
        {
            return IP.GetPlaythrough (PlaythroughID);
        }
        public Task<PTListObj> GetAllPlaythroughs ()
        {
            return IP.GetAllPlaythroughs ();
        }
        public async Task<Playthrough> CreatePlaythrough (NewPlaythrough Playthrough)
        {
            Playthrough createePlaythrough = new Playthrough ();
            createePlaythrough.id = Guid.NewGuid ();
            createePlaythrough.CreationTime = DateTime.Now;
            Player warrior = new Player(), ranger = new Player(), wizard = new Player();
            warrior.Name = "Warrior";
            warrior.id = Guid.NewGuid();
            ranger.Name = "Ranger";
            ranger.id = Guid.NewGuid();
            wizard.Name = "Wizard";
            wizard.id = Guid.NewGuid();
            createePlaythrough.Players.Add(warrior);
            createePlaythrough.Players.Add(ranger);
            createePlaythrough.Players.Add(wizard);
            return await IP.CreatePlaythrough (createePlaythrough);
        }
        public Task<Playthrough> ModifyPlaythrough (Guid PlaythroughID, Playthrough Playthrough)
        {
            return IP.ModifyPlaythrough (PlaythroughID, Playthrough);
        }
        public Task<Playthrough> DeletePlaythrough (Guid PlaythroughID)
        {
            return IP.DeletePlaythrough (PlaythroughID);
        }
    }
}