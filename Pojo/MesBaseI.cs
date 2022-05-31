using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESprogram.Pojo
{
    public class MesBaseI
    {
        public String lineId { get; set; }

        public String opeId { get; set; }

        public String evtUsr { get; set; }
        public String toolId { get; set; }
        public String actionFlg { get; set; }


        public String trxId { get; set; }

        public String transactionId { get; set; }
    }
}
