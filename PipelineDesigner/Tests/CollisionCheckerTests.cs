using NUnit.Framework;
using PipelineDesigner.Models;
using PipelineDesigner.Services;
using System.Collections.Generic;
using System.Linq;

namespace PipelineDesigner.Tests
{
    public class CollisionCheckerTests
    {
        [Test]
        public void ShouldDetectIntersectionBetweenPipelines()
        {
            var nodes = new List<Node>
            {
                new Node { Id = 1, PipelineId = 1, X = 4, Y = 5 },
                new Node { Id = 2, PipelineId = 1, X = 6, Y = 9 },
                new Node { Id = 3, PipelineId = 2, X = 4, Y = 7 },
                new Node { Id = 4, PipelineId = 2, X = 6, Y = 8 }
            };

            var result = CollisionChecker.FindSegmentCollisions(nodes);

            Assert.That(result, Is.Not.Empty);
        }

        [Test]
        public void ShouldNotDetectIntersectionIfNoCross()
        {
            var nodes = new List<Node>
            {
                new Node { Id = 1, PipelineId = 1, X = 0, Y = 0 },
                new Node { Id = 2, PipelineId = 1, X = 1, Y = 1 },
                new Node { Id = 3, PipelineId = 2, X = 2, Y = 2 },
                new Node { Id = 4, PipelineId = 2, X = 3, Y = 3 }
            };

            var result = CollisionChecker.FindSegmentCollisions(nodes);

            Assert.That(result, Is.Empty);
        }
    }
}