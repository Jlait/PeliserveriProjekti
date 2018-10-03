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
    [Route ("api/playthroughs/{PlaythroughID}/[controller]")]
    [ApiController]
    public class PlayersController {

        PlayersProcessor PP;
        public PlayersController (PlayersProcessor ppr) {
            PP = ppr;
        }

        [HttpGet ("{playerid}")]
        public Task<Player> GetPlayer (Guid PlaythroughID, Guid playerid) {
            return PP.GetPlayer (PlaythroughID, playerid);
        }

        [HttpGet]
        public Task<Player[]> GetAllPlayers (Guid PlaythroughID) {
            return PP.GetAllPlayers (PlaythroughID);
        }

        [HttpPost]
        public Task<Player> CreatePlayer (Guid PlaythroughID, [FromBody] NewPlayer player) {
            return PP.CreatePlayer (PlaythroughID, player);
        }

        [HttpPut ("{playerid}")]
        public Task<Player> ModifyPlayer (Guid PlaythroughID, Guid playerid, [FromBody] ModifiedPlayer player) {
            return PP.ModifyPlayer (PlaythroughID, playerid, player);

        }

        [HttpDelete ("{playerid}")]
        public Task<Player> DeletePlayer (Guid PlaythroughID, Guid playerid) {
            return PP.DeletePlayer (PlaythroughID, playerid);
        }

    }
}