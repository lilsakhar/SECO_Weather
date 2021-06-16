Declare @JSON varchar(max)
SELECT @JSON=BulkColumn
FROM OPENROWSET (BULK 'city.list.json', SINGLE_CLOB) import

SELECT Data.* 
INTO #Temp
FROM OPENJSON (@JSON)
WITH 
(
    id int, 
    name nvarchar(max), 
    state nvarchar(max), 
    country nvarchar(max)--,
)  AS [Data]
where country = 'PL'

INSERT INTO
City (id,name, state,country)
SELECT *
FROM #Temp

Drop table #Temp
