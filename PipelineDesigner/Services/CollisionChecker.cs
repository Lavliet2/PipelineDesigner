using PipelineDesigner.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PipelineDesigner.Services
{
    public static class CollisionChecker
    {
        public static List<Node> FindSegmentCollisions(List<Node> nodes)
        {
            var collisions = new HashSet<Node>();

            var groupedByPipe = nodes
                .GroupBy(n => n.PipelineId)
                .ToDictionary(g => g.Key, g => g.OrderBy(n => n.Id).ToList());

            foreach (var pipe1 in groupedByPipe)
            {
                foreach (var pipe2 in groupedByPipe)
                {
                    if (pipe1.Key >= pipe2.Key) continue; // avoid duplicate comparisons

                    var segments1 = GetSegments(pipe1.Value);
                    var segments2 = GetSegments(pipe2.Value);

                    foreach (var seg1 in segments1)
                    {
                        foreach (var seg2 in segments2)
                        {
                            if (SegmentsIntersect(seg1.Item1, seg1.Item2, seg2.Item1, seg2.Item2))
                            {
                                collisions.Add(seg1.Item1);
                                collisions.Add(seg1.Item2);
                                collisions.Add(seg2.Item1);
                                collisions.Add(seg2.Item2);
                            }
                        }
                    }
                }
            }

            return collisions.ToList();
        }

        private static List<(Node, Node)> GetSegments(List<Node> nodes)
        {
            var segments = new List<(Node, Node)>();
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                segments.Add((nodes[i], nodes[i + 1]));
            }
            return segments;
        }

        private static bool SegmentsIntersect(Node a1, Node a2, Node b1, Node b2)
        {
            float o1 = Orientation(a1, a2, b1);
            float o2 = Orientation(a1, a2, b2);
            float o3 = Orientation(b1, b2, a1);
            float o4 = Orientation(b1, b2, a2);

            // General case
            if (o1 != o2 && o3 != o4)
                return true;

            return false;
        }

        private static float Orientation(Node p, Node q, Node r)
        {
            float val = (float)((q.Y - p.Y) * (r.X - q.X) -
                                (q.X - p.X) * (r.Y - q.Y));
            if (Math.Abs(val) < 0.0001)
                return 0; // colinear
            return val > 0 ? 1 : 2; // clock or counterclock wise
        }
    }
}