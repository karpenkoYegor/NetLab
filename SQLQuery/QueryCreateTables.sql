CREATE TABLE [dbo].[City]
	([CityID] numeric(18, 0) PRIMARY KEY NOT NULL,
	[Name] nvarchar(MAX) NOT NULL,
	[Population] numeric(18, 0) NOT NULL)
GO

CREATE TABLE [dbo].[University]
	([UniversityID] numeric(18, 0) PRIMARY KEY NOT NULL,
	[Name] nvarchar(MAX) NOT NULL,
	[Address] nvarchar(MAX) NOT NULL,
	[CityID] numeric(18, 0) NOT NULL,
	FOREIGN KEY ([CityID]) REFERENCES [dbo].[City]([CityID]))
GO
CREATE TABLE [dbo].[Group]
	([GroupID] numeric(18, 0) PRIMARY KEY NOT NULL,
	[Name] nvarchar(MAX) NOT NULL,
	[UniversityID] numeric(18, 0) NOT NULL,
	FOREIGN KEY ([UniversityID]) REFERENCES [dbo].[University]([UniversityID]))
GO

CREATE TABLE [dbo].[Student]
    ([StudentID] numeric(18,0) PRIMARY KEY NOT NULL,
    [Name] nvarchar(MAX) NOT NULL,
    [UniversityID] numeric(18,0) NOT NULL,
    [Birthday] Date NOT NULL,
    [Bursary] numeric(18,0) NOT NULL,
    [GroupID] numeric(18, 0) NOT NULL,
    [Bonus] numeric(18, 0),
    [CityID] numeric(18, 0),
	FOREIGN KEY ([CityID]) REFERENCES [dbo].[City]([CityId]),
	FOREIGN KEY ([GroupID]) REFERENCES [dbo].[Group]([GroupID]))
GO

CREATE TABLE [dbo].[Subject]
	([SubjectID] numeric(18, 0) PRIMARY KEY NOT NULL,
	[Name] nvarchar(MAX) NOT NULL,
	[Duration] nvarchar(MAX) NOT NULL)
GO

CREATE TABLE [dbo].[Teacher]
	([TeacherID] numeric(18, 0) PRIMARY KEY NOT NULL,
	[Name] nvarchar(MAX) NOT NULL,
	[Phone] numeric(18, 0) NOT NULL,
    [SubjectID] numeric(18, 0) NOT NULL,
	FOREIGN KEY ([SubjectID]) REFERENCES [dbo].[Subject]([SubjectID]))
GO

CREATE TABLE [dbo].[UniversityTeacher]
	([TeacherID] numeric(18, 0) NOT NULL,
    [UniversityID] numeric(18, 0) NOT NULL,
    [Wage] numeric(18,0) NOT NULL,
    FOREIGN KEY ([TeacherID]) REFERENCES [dbo].[Teacher](TeacherID),
	FOREIGN KEY ([UniversityID]) REFERENCES [dbo].[University](UniversityID))
GO

CREATE TABLE [dbo].[StudentSubject]
	([StudentID] numeric(18, 0) NOT NULL,
    [SubjectID] numeric(18, 0) NOT NULL,
    [Mark] numeric(18,0) NOT NULL,
    FOREIGN KEY ([StudentID]) REFERENCES [dbo].[Student](StudentID),
	FOREIGN KEY ([SubjectID]) REFERENCES [dbo].[Subject](SubjectID))
GO

ALTER TABLE UniversityTeacher
    ADD CONSTRAINT pk_myConstraint PRIMARY KEY (UniversityID, TeacherID)

ALTER TABLE StudentSubject
    ADD CONSTRAINT pk_myConstraint1 PRIMARY KEY (StudentID, SubjectID)