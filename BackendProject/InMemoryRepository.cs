using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace assignment2
{
    public class InMemoryRepository : IRepository
    {
        
        public List<Player> playerList = new List<Player> ();
        public InMemoryRepository ()
        {
            Player p = new Player ();
            p.Name = "Zimbo";
            p.Id = Guid.NewGuid ();
            p.level = 2;
            p.Score = 100;
            p.CreationTime = DateTime.UtcNow;
            Item i = new Item();
            i.id = Guid.NewGuid();
            i.Level = 5;
            i.Type = 0;
            i.CreationTime = DateTime.Now;

            p.Items.Add(i);

            playerList.Add (p);
        }
        public Task<Player> GetPlayer (Guid id)
        {
            foreach (var item in playerList)
            {
                if (item.Id == id)
                {
                    return Task.FromResult (item);
                }
            }
            return Task.FromResult((Player)null);
        }
        public Task<Player[]> GetAllPlayers ()
        {
            return Task.FromResult (playerList.ToArray ());
        }
        public Task<Player> CreatePlayer (Player player)
        {
            playerList.Add (player);
            return Task.FromResult (player);
        }
        public Task<Player> ModifyPlayer (Guid id, ModifiedPlayer player)
        {
            foreach (var item in playerList)
            {
                if (item.Id == id)
                {
                    item.level = player.level;
                    item.Score = player.Score;
                    return Task.FromResult (item);
                }
            }
            return Task.FromResult((Player)null);
        }
        public Task<Player> DeletePlayer (Guid id)
        {
            foreach (var item in playerList)
            {
                if (item.Id == id)
                {
                    playerList.Remove (item);
                    return Task.FromResult (item);
                }
            }
            return Task.FromResult((Player)null);
        }

        //Items implementation
        public Task<Item> GetItem (Guid id, Guid itemID)
        {
            foreach (var item in playerList)
            {
                if (item.Id == id)
                {
                    foreach (var item1 in item.Items)
                    {
                        if (item1.id == itemID)
                        {
                            return Task.FromResult (item1);
                        }
                    }
                }
            }
            return Task.FromResult((Item)null);
        }
        public Task<Item[]> GetAllItems (Guid id)
        {
            foreach (var item in playerList)
            {
                if (item.Id == id)
                {
                    return Task.FromResult (item.Items.ToArray());
                }
            }
            return Task.FromResult((Item[])null);
        }
        public Task<Item> CreateItem (Guid id, Item item)
        {
            foreach (var item1 in playerList)
            {
                if (item1.Id == id)
                {
                    if(item1.Items != null){
                        item1.Items.Add(item);
                    }else{
                        item1.Items.Add(item);
                    }
                    
                }
            }
            return Task.FromResult (item);
        }
        public Task<Item> ModifyItem (Guid id, Guid itemID, ModifiedItem item)
        {
            foreach (var player in playerList)
            {
                if (player.Id == id)
                {
                    foreach (var item1 in player.Items)
                    {
                        if (item1.id == itemID)
                        {
                            item1.Level = item.Level;
                            item1.Type = item.Type;
                            return Task.FromResult (item1);
                        }
                    }
                }
            }
            return Task.FromResult((Item)null);
        }
        public Task<Item> DeleteItem (Guid id, Guid itemID)
        {
            foreach (var item in playerList)
            {
                if (item.Id == id)
                {
                    foreach (var item1 in item.Items)
                    {
                        if (item1.id == itemID)
                        {
                            item.Items.Remove (item1);
                            return Task.FromResult (item1);
                        }
                    }
                }
            }
            return Task.FromResult((Item)null);
        }
    }
}