using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

namespace assignment2
{
    public class MongoDbRepository : IRepository
    {
        private readonly IMongoCollection<Playthrough> _collection;
        private readonly IMongoCollection<BsonDocument> _bsonDocumentCollection;

        public MongoDbRepository ()
        {
            var mongoClient = new MongoClient ("mongodb://localhost:27017");
            IMongoDatabase database = mongoClient.GetDatabase ("Dragonborne");
            _collection = database.GetCollection<Playthrough> ("Playthroughs");
            _bsonDocumentCollection = database.GetCollection<BsonDocument> ("Playthroughs");
        }

        public async Task<Playthrough> CreatePlaythrough (Playthrough Playthrough)
        {
            await _collection.InsertOneAsync (Playthrough);
            return Playthrough;
        }

        public async Task<PTListObj> GetAllPlaythroughs ()
        {
            List<Playthrough> Playthroughs = await _collection.Find (new BsonDocument ()).ToListAsync ();
            PTListObj obj = new PTListObj();
            obj.ptList = Playthroughs;
            return obj;
        }

        public Task<Playthrough> GetPlaythrough (Guid id)
        {
            var filter = Builders<Playthrough>.Filter.Eq ("id", id);
            return _collection.Find (filter).FirstOrDefaultAsync();
        }

        public async Task<Playthrough> ModifyPlaythrough (Guid id, Playthrough Playthrough)
        {
            var filter = Builders<Playthrough>.Filter.Eq ("id", id);
            Playthrough Playthrough1 = await this.GetPlaythrough(id);
            Playthrough1.Players = Playthrough.Players;
            await _collection.ReplaceOneAsync (filter, Playthrough1);
            return Playthrough1;
        }

        public async Task<Playthrough> DeletePlaythrough (Guid PlaythroughId)
        {
            var filter = Builders<Playthrough>.Filter.Eq ("id", PlaythroughId);
            Playthrough Playthrough = await _collection.Find (filter).FirstAsync ();
            _collection.DeleteOneAsync (filter);
            return Playthrough;
        }

        public async Task<Player> CreatePlayer (Guid PlaythroughId, Player Player)
        {
            Playthrough tempPT = new Playthrough();
            tempPT = await this.GetPlaythrough(PlaythroughId);
            tempPT.Players.Add(Player);
            var filter = Builders<Playthrough>.Filter.Eq("id", PlaythroughId);
            await _collection.ReplaceOneAsync (filter, tempPT);
           /*  var filter = Builders<Playthrough>.Filter.Eq("id", PlaythroughId);
            var update =  Builders<Playthrough>.Update.Push("Players", Player);
            await _collection.FindOneAndUpdateAsync(filter, update); */
            return Player;
        }

        public async Task<Player> GetPlayer (Guid PlaythroughId, Guid Playerid)
        {
            var filter = Builders<Playthrough>.Filter.Eq ("id", PlaythroughId);
            Playthrough Playthrough = await _collection.Find (filter).FirstAsync();
            //Playthrough Playthrough = await this.GetPlaythrough(PlaythroughId);
            Player[] PlayerList = Playthrough.Players.ToArray();
            foreach (var Player in PlayerList)
            {
                if(Player.id == Playerid){
                    return Player;
                }
            }
            return (Player)null; 
        }

        public async Task<Player[]> GetAllPlayers (Guid PlaythroughId)
        {
            /* var filter = Builders<Playthrough>.Filter.Eq ("id", PlaythroughId);
            Playthrough Playthrough1 = (PlayThrough)_collection.Find (filter); */
            Playthrough Playthrough1 = await this.GetPlaythrough(PlaythroughId);
            return Playthrough1.Players.ToArray();
        }

        public async Task<Player> ModifyPlayer (Guid PlaythroughId, Guid Playerid, ModifiedPlayer Player)
        {
            Playthrough Playthrough = await this.GetPlaythrough(PlaythroughId);

            Player newPlayer = new Player();
            newPlayer.kills = Player.kills;
            newPlayer.deaths = Player.deaths;
            
            Player[] PlayerList = Playthrough.Players.ToArray();
            for (int i = 0; i < PlayerList.Count(); i++)
            {
                if(PlayerList[i].id == Playerid){
                    newPlayer.id = PlayerList[i].id;
                    newPlayer.Name = PlayerList[i].Name;
                    PlayerList[i] = newPlayer;
                }
            }
            Playthrough.Players = PlayerList.ToList();

            await _collection.ReplaceOneAsync(Builders<Playthrough>
            .Filter.Eq("id", PlaythroughId), Playthrough);
            return newPlayer;
        }

        public async Task<Player> DeletePlayer (Guid PlaythroughId, Guid Playerid)
        {
            Playthrough Playthrough = await this.GetPlaythrough(PlaythroughId);
            List<Player> PlayerList = Playthrough.Players;
            Player temp = null;

            for (int i = 0; i < PlayerList.Count(); i++)
            {
                if(PlayerList[i].id == Playerid){
                    temp = PlayerList[i];
                    PlayerList.Remove(PlayerList[i]);
                }
            }
            Playthrough.Players = PlayerList;
            await _collection.ReplaceOneAsync(Builders<Playthrough>
            .Filter.Eq("id", PlaythroughId), Playthrough);
            return temp;
        }
    }
}