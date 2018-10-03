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
    [Route ("api/[controller]")]
    [ApiController]
    [CustomErrorAttribute]
    public class PlaythroughsController
    {
       PlaythroughProcessor IP;
        public PlaythroughsController (PlaythroughProcessor IPr) {
            IP = IPr;
        }

        [HttpGet("{id}")]
        public Task<Playthrough> GetPlaythrough (Guid id) {
            Console.WriteLine(id);
            return IP.GetPlaythrough (id);
        }

        [HttpGet]
        public Task<PTListObj> GetAllPlaythroughs () {
            return IP.GetAllPlaythroughs ();
        }

        [HttpPost]
        public Task<Playthrough> CreatePlaythrough ([FromBody]NewPlaythrough Playthrough) {
            return IP.CreatePlaythrough (Playthrough);
        }

        [HttpPut ("{PlaythroughID}")]
        public Task<Playthrough> ModifyPlaythrough (Guid PlaythroughID, [FromBody]Playthrough Playthrough) {
            return IP.ModifyPlaythrough (PlaythroughID, Playthrough);

        }

        [HttpDelete ("{PlaythroughID}")]
        public Task<Playthrough> DeletePlaythrough (Guid PlaythroughID) {
            return IP.DeletePlaythrough (PlaythroughID);
        } 
    }
}