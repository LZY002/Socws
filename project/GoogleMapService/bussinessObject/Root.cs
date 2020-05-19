using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapService.bussinessObject
{
    [DataContract]
    class Root
    {
        [DataMember]
        public List<ResultOfGoogleMap> results { get; set; }
    }
}
