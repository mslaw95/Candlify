using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candlify.Application.Models
{
    public class CandleVm
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; } // TODO - struct or model
        public int Stock { get; set; }
        public bool IsAvailable => Stock > 0;
        public string Scent { get; set; } = string.Empty;
        public uint BurnTime { get; set; }
        public uint Capacity { get; set; }
        public uint Height { get; set; }
        public uint Width { get; set; }
    }
}
