using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ApiDemo2.Models
{
    [DataContract]
    public class ProductModel
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid ProdductId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public String Name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public double? UnitPrice { get; set; }
    }
}