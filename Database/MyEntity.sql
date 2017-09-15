CREATE TABLE [dbo].[MyEntity]
(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	MyColumn varchar(10) NOT NULL,
	MyComputedColumn AS MyColumn
)
