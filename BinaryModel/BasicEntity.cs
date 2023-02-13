using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BinaryModel.Interfaces;

namespace BinaryModel
{
    public class BasicEntity
    {
        public IStringRepresentation StringRepresentation { get; set; } = null!;
        public string Bytes { get; set; } = null!;
        public int Position {get;set;}
    }
}