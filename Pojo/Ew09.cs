using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESprogram.Pojo
{
    public class Ew09:MesBaseI
    {
        public String boxId { get; set; }
        public List<WaferInfo> iary { get; set; }

        public string waferCount { get; set; }
    }
}
