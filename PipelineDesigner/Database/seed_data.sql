-- Добавим три трубопровода
INSERT INTO Pipelines (Name) VALUES ('Pipeline 1');
INSERT INTO Pipelines (Name) VALUES ('Pipeline 2');
INSERT INTO Pipelines (Name) VALUES ('Pipeline 3');

-- Узлы для Pipeline 1 (ID = 1)
INSERT INTO Nodes (PipelineId, X, Y) VALUES (1, 1, 2);
INSERT INTO Nodes (PipelineId, X, Y) VALUES (1, 3, 4);
INSERT INTO Nodes (PipelineId, X, Y) VALUES (1, 4, 6);
INSERT INTO Nodes (PipelineId, X, Y) VALUES (1, 6, 9);
INSERT INTO Nodes (PipelineId, X, Y) VALUES (1, 7, 12);
INSERT INTO Nodes (PipelineId, X, Y) VALUES (1, 10, 13);
INSERT INTO Nodes (PipelineId, X, Y) VALUES (1, 11, 13);

-- Узлы для Pipeline 2 (ID = 2)
INSERT INTO Nodes (PipelineId, X, Y) VALUES (2, 1, 4);
INSERT INTO Nodes (PipelineId, X, Y) VALUES (2, 2, 6);
INSERT INTO Nodes (PipelineId, X, Y) VALUES (2, 4, 7);
INSERT INTO Nodes (PipelineId, X, Y) VALUES (2, 6, 8);
INSERT INTO Nodes (PipelineId, X, Y) VALUES (2, 8, 10);
INSERT INTO Nodes (PipelineId, X, Y) VALUES (2, 9, 11);

-- Узлы для Pipeline 3 (ID = 3)
INSERT INTO Nodes (PipelineId, X, Y) VALUES (3, 1, 1);
INSERT INTO Nodes (PipelineId, X, Y) VALUES (3, 2, 1);
INSERT INTO Nodes (PipelineId, X, Y) VALUES (3, 4, 5);
INSERT INTO Nodes (PipelineId, X, Y) VALUES (3, 6, 6);
INSERT INTO Nodes (PipelineId, X, Y) VALUES (3, 7, 7);
