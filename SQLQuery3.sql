/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/
SELECT TOP (1000) *
  FROM [HowlingWolf].[dbo].[Organization]
  SELECT TOP (1000) *
  FROM [HowlingWolf].[dbo].[GameDiscipline]
    SELECT TOP (1000) *
  FROM [HowlingWolf].[dbo].[Commands]