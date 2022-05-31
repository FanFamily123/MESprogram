using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESprogram.Pojo
{
    public class Ew08:MesBaseI
    {

        public String subToolId { get; set; }
        public List<WaferInfo> iary { get; set; }
        public string waferCount { get; set; }

        public String lastSubToolId { get; set; }

        public string channelId { get; set; }
        public String boxId { get; set; }

    }
}
