using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace assignment2
{
    [Route ("api/players/{id}/[controller]")]
    [ApiController]
    [CustomErrorAttribute]
    public class ItemsController
    {
       ItemProcessor IP;
        public ItemsController (ItemProcessor IPr) {
            IP = IPr;
        }

        [HttpGet ("{itemID}")]
        public Task<Item> GetItem (Guid id, Guid itemID) {
            return IP.GetItem (id, itemID);
        }

        [HttpGet]
        public Task<Item[]> GetAllItems (Guid id) {
            return IP.GetAllItems (id);
        }

        [HttpPost]
        public Task<Item> CreateItem (Guid id, [FromBody]NewItem item) {
            return IP.CreateItem (id, item);
        }

        [HttpPut ("{itemID}")]
        public Task<Item> ModifyItem (Guid id, Guid itemID, [FromBody]ModifiedItem item) {
            return IP.ModifyItem (id, itemID, item);

        }

        [HttpDelete ("{itemID}")]
        public Task<Item> DeleteItem (Guid id, Guid itemID) {
            return IP.DeleteItem (id, itemID);
        } 
    }
}