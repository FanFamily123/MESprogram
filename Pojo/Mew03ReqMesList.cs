using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESprogram.Pojo
{

    [Serializable]
    public class Mew03ReqMesList : MesBaseI
    {
        public String boxId { get; set; }
        public String actionFlg { get; set; }
        public String channelNo { get; set; }
        public String areaNo { get; set; }
        public List<WaferInfo> iary { get; set; }
        public String count { get; set; }


    }
}
