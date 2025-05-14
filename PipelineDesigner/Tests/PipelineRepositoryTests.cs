using NUnit.Framework;
using PipelineDesigner.Data;
using PipelineDesigner.Models;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace PipelineDesigner.Tests
{
    public class PipelineRepositoryTests
    {
        private PipelineRepository _repo;
        private string _connStr;

        [SetUp]
        public void Setup()
        {
            _connStr = "Data Source=file:memdb1?mode=memory&cache=shared;Version=3;";
            DatabaseInitializer.Initialize(_connStr);

            // Чистим таблицы
            using var conn = new SQLiteConnection(_connStr);
            conn.Open();
            using var cmd = new SQLiteCommand("DELETE FROM Nodes; DELETE FROM Pipelines;", conn);
            cmd.ExecuteNonQuery();

            _repo = new PipelineRepository(_connStr);
            _repo.AddPipeline("TestPipe");
        }


        [Test]
        public void AddAndGetNode_WorksCorrectly()
        {
            var pipelineId = _repo.GetPipelines().First().Id;

            var node = new Node { PipelineId = pipelineId, X = 10, Y = 20 };
            _repo.AddNode(node);

            var nodes = _repo.GetNodes();

            Assert.That(nodes.Count, Is.EqualTo(1));
            Assert.That(nodes[0].X, Is.EqualTo(10));
            Assert.That(nodes[0].Y, Is.EqualTo(20));
        }

        [Test]
        public void DeleteNode_RemovesFromDatabase()
        {
            var pipelineId = _repo.GetPipelines().First().Id;

            var node = new Node { PipelineId = pipelineId, X = 1, Y = 1 };
            var newId = _repo.AddNode(node);

            _repo.DeleteNode(newId);

            var remaining = _repo.GetNodes();
            Assert.That(remaining.Count, Is.EqualTo(0));
        }
    }
}
