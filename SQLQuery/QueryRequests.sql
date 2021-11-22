--https://media.2x2tv.ru/content/images/2021/04/YC4AQKT-1.jpg
--1
SELECT [StudentID]
      ,[Name]
      ,[Birthday]
      ,[Bursary]
      ,[GroupID]
      ,[Bonus]
      ,[CityID]
  FROM [UniversityDB].[dbo].[Student] WHERE [GroupID] = 101 
                                      or [GroupID] = 105
                                      or [GroupID] = 106
--2
SELECT [StudentID]
      ,[Name]
      ,[Birthday]
      ,[Bursary]
      ,[GroupID]
      ,[Bonus]
      ,[CityID]
  FROM [UniversityDB].[dbo].[Student] WHERE ([GroupID] = 101 
                                      or [GroupID] = 105
                                      or [GroupID] = 106)
                                      and [Bursary] > 300
--3
SELECT [Student].[StudentID]
      ,[Student].[Name]
      ,[StudentSubject].[Mark] 
FROM [UniversityDB].[dbo].[Student]
JOIN [StudentSubject] ON 
    [UniversityDB].[dbo].[Student].[StudentID] = [UniversityDB].[dbo].[StudentSubject].[StudentID]
    WHERE [Student].[Name] LIKE 'D%' 
    and ([StudentSubject].[Mark] > 7.4 and [StudentSubject].[Mark] < 9.5)
--4
SELECT [StudentID]
      ,[Name]
      ,CONVERT(varchar(12), [Birthday], 106) as [Birthday]
  FROM [UniversityDB].[dbo].[Student] WHERE [Student].[Name] LIKE '%O'
--5
SELECT [StudentID]
      ,[Name]
      ,[Birthday]
      ,[Bursary]
      ,[GroupID]
      ,[Bonus]
      ,[CityID]
  FROM [UniversityDB].[dbo].[Student] WHERE [Bonus] is not null
                                      and [Birthday] > '1988-01-01'
--6
SELECT [Student].[Name]
      ,[Student].[Birthday]
      ,[Student].[Bursary]
      ,[Student].[GroupID]
      ,[Student].[Bonus]
      ,[City].[Name]  as [CityName]
  FROM [UniversityDB].[dbo].[Student]
  JOIN [City] ON
    [UniversityDB].[dbo].[Student].[CityID] = [UniversityDB].[dbo].[City].[CityID]
    WHERE [City].[Name] = 'Gomel'
--7
SELECT [Student].[Name]
      ,[Student].[Birthday]
      ,[Student].[Bursary]
      ,[Student].[GroupID]
      ,[Student].[Bonus]
      ,[City].[Name]  as [CityName]
  FROM [UniversityDB].[dbo].[Student]
  JOIN [City] ON
    [UniversityDB].[dbo].[Student].[CityID] = [UniversityDB].[dbo].[City].[CityID]
    WHERE [City].[Name] = 'Vitebsk'
    ORDER BY [Student].[Bursary]
--8                     
SELECT [Student].[Name]
      ,[Student].[Birthday]
      ,[Student].[Bursary]
      ,[City].[Name] as [CityName]
  FROM [UniversityDB].[dbo].[Student]
  JOIN [City] ON
    [UniversityDB].[dbo].[Student].[CityID] = [UniversityDB].[dbo].[City].[CityID]
    WHERE [Student].[Birthday] > '1990-01-01' and [Student].[Birthday] < '1991-01-01'  
	ORDER BY [Student].[Bursary] DESC
--9
DECLARE @maxValue numeric(18,0)


SELECT @maxValue = MAX([Bursary])
  FROM [UniversityDB].[dbo].[Student] WHERE [GroupID] = 102

SELECT [Name]
	  ,CAST(100*[Bursary]/@maxValue as nvarchar) + '%' as PrecentBursary
FROM [UniversityDB].[dbo].[Student] WHERE [GroupID] = 102
--10
SELECT [Student].[Name]
      ,[Student].[Birthday]
      ,[Student].[Bursary]
      ,[Student].[GroupID]
      ,[Student].[Bonus]
	  ,convert(varchar,[Student].[CityID]) as [CityName]
  FROM [UniversityDB].[dbo].[Student]
	WHERE [Student].[CityID] is NULL
UNION
SELECT [Student].[Name]
      ,[Student].[Birthday]
      ,[Student].[Bursary]
      ,[Student].[GroupID]
      ,[Student].[Bonus]
      ,[City].[Name] as [CityName]
  FROM [UniversityDB].[dbo].[Student]
  JOIN [City] ON
    [UniversityDB].[dbo].[Student].[CityID] = [UniversityDB].[dbo].[City].[CityID]
    WHERE ([City].[Name] <> 'Minsk' and [City].[Name] <> 'Grodno' and [City].[Name] <> 'Gomel') or [Student].[CityID] is NULL
    ORDER BY [Student].[Name]
--11
SELECT [Student].[Name]
  FROM [UniversityDB].[dbo].[Student]
  WHERE [Student].[Name] LIKE '%[^a-zA-Z0-9]%'
--12
SELECT [Student].[Name]
      ,[Student].[Birthday]
      ,[Student].[Bursary]
      ,[Student].[GroupID]
  FROM [UniversityDB].[dbo].[Student]
  WHERE [Student].[Birthday] < '1984-04-23'
  ORDER BY [Student].[GroupID], [Student].[Name]
--13
SELECT [Teacher].[Name]
      ,[Subject].[Name]
	  ,[Subject].[Duration]
  FROM [UniversityDB].[dbo].[Teacher]
  JOIN [Subject] ON
  [UniversityDB].[dbo].[Teacher].[SubjectID] = [UniversityDB].[dbo].[Subject].[SubjectID]
--14
SELECT [Group].[Name]
	  ,[University].[Name]
	  ,[City].[Name]
  FROM [UniversityDB].[dbo].[Group]
  JOIN [UniversityDB].[dbo].[University] ON
  [Group].[UniversityID] = [University].[UniversityID]
  JOIN [UniversityDB].[dbo].[City] ON
  [University].[CityID] = [City].[CityID]
--15
SELECT [Student].[Name]
	  ,[Group].[Name]
	  ,AVG([StudentSubject].[Mark]) as Average
  FROM [UniversityDB].[dbo].[Student]
  JOIN [UniversityDB].[dbo].[Group] ON
  [Group].[GroupID] = [Student].[GroupID]
  JOIN [UniversityDB].[dbo].[StudentSubject] ON
  [StudentSubject].[StudentID] = [Student].[StudentID]
  GROUP BY [Student].[Name]
	  ,[Group].[Name]
  HAVING AVG([StudentSubject].[Mark]) < 6.2
--16
SELECT [Student].[Name]
	  ,[Group].[Name]
	  ,[City].[Name]
	  ,[City].[Population]
	  ,[University].[Name]
  FROM [UniversityDB].[dbo].[Student]
  JOIN [UniversityDB].[dbo].[Group] ON
  [Group].[GroupID] = [Student].[GroupID]
  JOIN [UniversityDB].[dbo].[University] ON
  [University].[UniversityID] = [Group].[UniversityID]
  JOIN [UniversityDB].[dbo].[City] ON
  [University].[CityID] = [City].[CityID]
  WHERE [Group].[Name] LIKE '%Uni%'
--17
SELECT [Teacher].[Name]
	  ,[UniversityTeacher].[Wage]
	  ,[University].[Name]
  FROM [UniversityDB].[dbo].[Teacher]
  JOIN [UniversityTeacher] ON
  [UniversityTeacher].[TeacherID] = [Teacher].[TeacherID]
  JOIN [University] ON
  [UniversityTeacher].[UniversityID] = [University].[UniversityID]
  WHERE [UniversityTeacher].[Wage] > 750
--18
SELECT [Teacher].[Name]
	  ,[UniversityTeacher].[Wage]
	  ,[Subject].[Name]
	  ,[Group].[Name]
	  ,[City].[Name]
  FROM [UniversityDB].[dbo].[Teacher]
  JOIN [UniversityTeacher] ON
  [UniversityTeacher].[TeacherID] = [Teacher].[TeacherID]
  JOIN [Subject] ON
  [Teacher].[SubjectID] = [Subject].[SubjectID]
  JOIN [University] ON
  [University].[UniversityID] = [UniversityTeacher].[UniversityID]
  JOIN [City] ON
  [University].[CityID] = [City].[CityID]
  JOIN [Group] ON
  [University].[UniversityID] = [Group].[UniversityID]
  WHERE ([City].[Name] = 'Minsk' or [City].[Name] = 'Grodno')
  AND [Subject].[Name] <> 'English'
  ORDER BY [Subject].[SubjectID], [Group].[GroupID]
