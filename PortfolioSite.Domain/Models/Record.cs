using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioSite.Domain.Models
{
    public class Record : BaseModel
    {
        public string Username { get; set; }
        public string GameName { get; set; }
        public int Score { get; set; }
    }
}
