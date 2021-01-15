using Microsoft.AspNetCore.Mvc;
using PortfolioSite.App;
using PortfolioSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioSite.App.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortfolioSite.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private RecordTableService _recordTableService;

        public RecordsController(RecordTableService scoreTableService)
        {
            _recordTableService = scoreTableService;
        }
        // GET: api/<RecordsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var list = new List<string>();
            foreach (var item in _recordTableService.Records)
            {
                list.Add($"{item.Id} {item.GameName} {item.Username} {item.Score}");
            }
            return list;
        }

        // GET api/<RecordsController>/5
        [HttpGet("{gameName}")]
        public IEnumerable<Record> Get(string gameName)
        {

            return _recordTableService.GetRecordsForGame(gameName);
        }

        // POST api/<RecordsController>
        [HttpPost]
        public string Post(Record record)
        {
            return _recordTableService.PublishRecord(record).ToString();
        }

        // PUT api/<RecordsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecordsController>/5
        [HttpDelete]
        public void Delete()
        {
            _recordTableService.Clear();
        }
    }
}
