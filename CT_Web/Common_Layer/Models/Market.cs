using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CT_App.Models
{
    public class Market
    {
        public string M_ID { get; set; }
        public DateTime M_Date { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Plese Insert Greater Then 0")]
        public float M_Amount { get; set; }
        public string M_Insrt_Person { get; set; }
        public string M_Updt_Person { get; set; }
        public string M_Del_Person { get; set; }

        public List<Market> MarketDataList { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
