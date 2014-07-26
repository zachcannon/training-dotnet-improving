MERGE INTO TaskStatus AS Target 
USING (VALUES 
  (0, N'Pending'), 
  (1, N'Working'), 
  (2, N'Finished') 
) 
AS Source (TaskStatusId, StatusText) 
ON Target.TaskStatusId = Source.TaskStatusId 
-- update matched rows 
WHEN MATCHED THEN 
UPDATE SET StatusText = Source.StatusText 
-- insert new rows 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (TaskStatusId, StatusText) 
VALUES (TaskStatusId, StatusText) 
-- delete rows that are in the target but not the source 
WHEN NOT MATCHED BY SOURCE THEN 
DELETE;