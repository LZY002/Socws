﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapService.bussinessObject
{
    [DataContract]
    class ResultOfGoogleMap
    {
        [DataMember]
        public Geometry geometry { get; set; }
    }
}
