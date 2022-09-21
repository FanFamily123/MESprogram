using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESprogram.Pojo
{
    public class EWAdd:MesBaseI
    {
        public String waferCount { get; set; }
        public string boxIdA { get; set; }

        public string boxId { get; set; }


        public string woId { get; set; }

        public string actionType { get; set; }

        public List<Guan> IaryB { get; set; }

    }


    public class Guan
    {


        public int slotNo { get; set; }
        public String boxId { get; set; }


        public String toString()
        {
            return "iary{" +
                    "slotNo=" + slotNo +
                    ", boxId='" + boxId + '\'' +
                    '}';
        }
    }
    }
