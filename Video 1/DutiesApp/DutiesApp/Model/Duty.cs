using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutiesApp.Model
{
    public class Duty
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Info { get; set; }

        public override string ToString() => $"{Id}- {Title} -> {Info}";
    }
}
