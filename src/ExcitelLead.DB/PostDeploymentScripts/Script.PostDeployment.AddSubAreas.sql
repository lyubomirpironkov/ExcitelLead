/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

DECLARE @TMP_SubArea TABLE ([Name] VARCHAR(255) NOT NULL, [PINCode] INT NOT NULL)

INSERT INTO @TMP_SubArea
VALUES ('Area One', 1001), 
    ('Area Two', 1002), 
    ('Area Three', 1003),
    ('Area Four', 1002), 
    ('Area Five', 1003), 
    ('Area Six', 1003)

MERGE dbo.SubArea AS Target
USING @TMP_SubArea  AS Source
ON Source.Name = Target.Name
WHEN NOT MATCHED BY Target THEN
        INSERT (Name, PINCode) 
        VALUES (Source.Name, Source.PINCode);