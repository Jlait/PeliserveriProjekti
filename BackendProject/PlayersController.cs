using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace assignment2 {
    [Route ("api/[controller]")]
    [ApiController]
    public class PlayersController {

        PlayersProcessor PP;
        public PlayersController (PlayersProcessor ppr) {
            PP = ppr;
        }

        [HttpGet ("{id}")]
        public Task<Player> GetPlayer (Guid id) {
            return PP.GetPlayer (id);
        }

        [HttpGet]
        public Task<Player[]> GetAllPlayers () {
            return PP.GetAllPlayers ();
        }

        [HttpPost]
        public Task<Player> CreatePlayer ([FromBody] NewPlayer player) {
            return PP.CreatePlayer (player);
        }

        [HttpPut ("{id}")]
        public Task<Player> ModifyPlayer (Guid id, [FromBody] ModifiedPlayer player) {
            return PP.ModifyPlayer (id, player);

        }

        [HttpDelete ("{id}")]
        public Task<Player> DeletePlayer (Guid id) {
            return PP.DeletePlayer (id);
        }

    }
}