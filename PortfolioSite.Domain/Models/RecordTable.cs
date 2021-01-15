using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioSite.Domain.Models
{
    public class RecordTable
    {
        public string ImageName { get; set; }
        public string Name { get; set; }

        public IEnumerable<Record> Records { get; set; }
    }
}
