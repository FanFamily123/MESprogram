using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESprogram.Pojo
{
    public class Ew03: MesBaseI
    {
      
   


        public String boxId { get; set; }
        public String actionType { get; set; }
        public String channelNo { get; set; }
        public String boatblockNo { get; set; }
        public String waferCount { get; set; }
        public String channelId { get; set; }
        public String prdSeqId { get; set; }

        public String BoxIdA { get; set; }

        public String BoxIdB { get; set; }

        public String areaNo { get; set; }


        public List<WaferInfo> iary { get; set; }



    }


    public class WaferInfo {

    
        public int slotNo { get; set; }
        public String prdSeqId { get; set; }

        
          public String toString()
        {
            return "WaferInfo{" +
                    "slotNo=" + slotNo +
                    ", prdSeqId='" + prdSeqId + '\'' +
                    '}';
        }
    }
}
