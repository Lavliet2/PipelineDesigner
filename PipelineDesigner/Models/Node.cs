using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesigner.Models
{
    public class Node
    {
        public int Id { get; set; }
        public int PipelineId { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
