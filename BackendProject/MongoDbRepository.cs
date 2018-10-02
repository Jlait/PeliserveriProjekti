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
        private readonly IMongoCollection<Player> _collection;
        private readonly IMongoCollection<BsonDocument> _bsonDocumentCollection;

        public MongoDbRepository ()
        {
            var mongoClient = new MongoClient ("mongodb://localhost:27017");
            IMongoDatabase database = mongoClient.GetDatabase ("Game");
            _collection = database.GetCollection<Player> ("players");
            _bsonDocumentCollection = database.GetCollection<BsonDocument> ("players");
        }

        public async Task<Player> CreatePlayer (Player player)
        {
            await _collection.InsertOneAsync (player);
            return player;
        }

        public async Task<Player[]> GetAllPlayers ()
        {
            List<Player> players = await _collection.Find (new BsonDocument ()).ToListAsync ();
            return players.ToArray ();
        }

        public Task<Player> GetPlayer (Guid id)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq ("Id", id);
            return _collection.Find (filter).FirstAsync ();
        }

        public async Task<Player> ModifyPlayer (Guid id, ModifiedPlayer player)
        {
            var filter = Builders<Player>.Filter.Eq ("Id", id);
            Player player1 = await this.GetPlayer(id);
            player1.Score = player.Score;
            await _collection.ReplaceOneAsync (filter, player1);
            return player1;
        }

        public async Task<Player> DeletePlayer (Guid playerId)
        {
            var filter = Builders<Player>.Filter.Eq ("Id", playerId);
            Player player = await _collection.Find (filter).FirstAsync ();
            _collection.DeleteOneAsync (filter);
            return player;
        }

        public async Task<Item> CreateItem (Guid playerId, Item item)
        {
            var filter = Builders<Player>.Filter.Eq("Id", playerId);
            var update =  Builders<Player>.Update.Push("Items", item);
            await _collection.FindOneAndUpdateAsync(filter, update);
            return item;
        }

        public async Task<Item> GetItem (Guid playerId, Guid itemid)
        {
            Player player = await this.GetPlayer(playerId);
            Item[] itemList = player.Items.ToArray();
            foreach (var item in itemList)
            {
                if(item.id == itemid){
                    return item;
                }
            }
            return (Item)null; 
        }

        public async Task<Item[]> GetAllItems (Guid playerId)
        {
            Player player = await this.GetPlayer(playerId);
            return player.Items.ToArray();
        }

        public async Task<Item> ModifyItem (Guid playerId, Guid itemid, ModifiedItem item)
        {
            Player player = await this.GetPlayer(playerId);

            Item newItem = new Item();

            newItem.Level = item.Level;
            newItem.Type = item.Type;
            
            Item[] itemList = player.Items.ToArray();
            for (int i = 0; i < itemList.Count(); i++)
            {
                if(itemList[i].id == itemid){
                    newItem.id = itemList[i].id;
                    newItem.CreationTime = itemList[i].CreationTime;
                    itemList[i] = newItem;
                }
            }
            player.Items = itemList.ToList();

            await _collection.ReplaceOneAsync(Builders<Player>
            .Filter.Eq("Id", playerId), player);
            return newItem;
        }

        public async Task<Item> DeleteItem (Guid playerId, Guid itemid)
        {
            Player player = await this.GetPlayer(playerId);
            List<Item> itemList = player.Items;
            Item temp = null;

            for (int i = 0; i < itemList.Count(); i++)
            {
                if(itemList[i].id == itemid){
                    temp = itemList[i];
                    itemList.Remove(itemList[i]);
                }
            }
            player.Items = itemList;
            await _collection.ReplaceOneAsync(Builders<Player>
            .Filter.Eq("Id", playerId), player);
            return temp;
        }
    }
}