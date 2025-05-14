using PipelineDesigner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesigner.Services
{
    public static class CollisionChecker
    {
        public static List<Node> FindCollisions(List<Node> nodes)
        {
            var grouped = nodes.GroupBy(n => new { n.X, n.Y });
            return grouped.Where(g => g.Count() > 1).SelectMany(g => g).ToList();
        }
    }

}
