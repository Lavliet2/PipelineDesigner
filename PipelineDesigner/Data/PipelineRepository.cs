using PipelineDesigner.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace PipelineDesigner.Data
{
    public class PipelineRepository
    {
        private readonly string _connectionString;

        public PipelineRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Pipeline> GetPipelines()
        {
            var list = new List<Pipeline>();
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Pipelines", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Pipeline
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public void AddPipeline(string name)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("INSERT INTO Pipelines (Name) VALUES (@name)", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeletePipeline(int id)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("DELETE FROM Pipelines WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                var cmdNodes = new SQLiteCommand("DELETE FROM Nodes WHERE PipelineId = @id", conn);
                cmdNodes.Parameters.AddWithValue("@id", id);
                cmdNodes.ExecuteNonQuery();
            }
        }

        public List<Node> GetNodes()
        {
            var nodes = new List<Node>();
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Nodes", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nodes.Add(new Node
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            PipelineId = Convert.ToInt32(reader["PipelineId"]),
                            X = Convert.ToDouble(reader["X"]),
                            Y = Convert.ToDouble(reader["Y"])
                        });
                    }
                }
            }
            return nodes;
        }

        public void AddNode(Node node)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("INSERT INTO Nodes (PipelineId, X, Y) VALUES (@p, @x, @y)", conn);
                cmd.Parameters.AddWithValue("@p", node.PipelineId);
                cmd.Parameters.AddWithValue("@x", node.X);
                cmd.Parameters.AddWithValue("@y", node.Y);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteNode(int id)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("DELETE FROM Nodes WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateNode(Node node)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("UPDATE Nodes SET X = @x, Y = @y WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@x", node.X);
                cmd.Parameters.AddWithValue("@y", node.Y);
                cmd.Parameters.AddWithValue("@id", node.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}