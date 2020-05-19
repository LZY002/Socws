using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapService.bussinessObject
{
    [DataContract]
    class Geometry
    {
        [DataMember]
        public Location location { get; set; }
    }
}
