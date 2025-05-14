using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesigner.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize(string connectionString)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string createPipelines = @"CREATE TABLE IF NOT EXISTS Pipelines (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL
                );";

                            string createNodes = @"CREATE TABLE IF NOT EXISTS Nodes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    PipelineId INTEGER,
                    X REAL,
                    Y REAL,
                    FOREIGN KEY(PipelineId) REFERENCES Pipelines(Id)
                );";

                using (var cmd = new SQLiteCommand(createPipelines, conn))
                {
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = createNodes;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
