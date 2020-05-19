using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VelibService.bussinessObjet
{
    [DataContract]
    class Contract
    {
        [DataMember]
        public String name { get; set; }
        [DataMember]
        public String commercial_name { get; set; }
    }
}
