using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESprogram
{
    public class HttpClientClass
    {

        public String postHttpForMesActive(String evt_no, String trx_id, String message)
        {

            StringBuilder inStrbuf = new StringBuilder();   

            inStrbuf.Append("[").Append(evt_no).Append("]");
            inStrbuf.Append("[TOMES]");
    

            inStrbuf.Append("[").Append(trx_id + "_" + "I").Append("]");
            inStrbuf.Append("[inTrx:").Append(message).Append("]");

         //   MultiValueMap<String, String> paramMap = new LinkedMultiValueMap<>();



            //paramMap.add("trxId", "BCTOMES");
            //paramMap.add("strInMsg", message);

            return ";";
        }






    }
    }
