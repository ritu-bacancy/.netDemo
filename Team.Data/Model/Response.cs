using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Team.Data.Model
{
    [DataContract]
    public class Response<T>
    {
        [DataMember(Name = "IsSuccess")]
        public bool IsSuccess { get; set; }

        [DataMember(Name = "InfoMessage")]
        public string InfoMessage { get; set; }

        [DataMember(Name = "Data")]
        public T Data { get; set; }
    }
}
