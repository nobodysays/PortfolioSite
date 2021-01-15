using PortfolioSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace PortfolioSite.App.Services
{
    public class RecordTableService
    {
        public IEnumerable<Record> Records => _db.Records;

        private readonly IApplicationDbContext _db;

        public IEnumerable<Record> GetRecordsForGame(string gameName)
        {
            return from r in _db.Records where r.GameName == gameName select r;
        }
        public RecordTable GetRecordTableForGame(string gameName)
        {
            return new RecordTable
            {
                ImageName = (gameName+".jpg").ToLower(),
                Name = gameName,
                Records = GetRecordsForGame(gameName).OrderByDescending(x=>x.Score)
            };
        }
        public RecordTableService(IApplicationDbContext db)
        {
            _db = db;
        }

        public bool PublishRecord(Record record)
        {
            var recordsForGame = from r in _db.Records
                                 where r.GameName == record.GameName
                                 select r;
            
            if(recordsForGame.Count() >= 5)
            {
                var ordered = recordsForGame.OrderBy(x => x.Score);
                var last = ordered.First();
                if(last.Score <= record.Score)
                {
                    _db.Records.Remove(last);
                    _db.Records.Add(record);
                    _db.Save();
                    return true;
                }
                else
                    return false;
            }
            else
            {
                _db.Records.Add(record);
                _db.Save();
                return true;
            }
            
        }

        public void Clear()
        {
        }
    }
}
