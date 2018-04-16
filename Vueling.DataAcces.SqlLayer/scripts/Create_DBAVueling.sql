EXEC sp_configure filestream_access_level, 2 
 RECONFIGURE  
GO
USE master
GO
IF NOT EXISTS (
   SELECT name
   FROM sys.databases
   WHERE name = N'VuelingDB'
)
CREATE DATABASE VuelingDB
ON PRIMARY(
    name='VuelingDB_Primary',
	filename='C:\CursoSqlServer2017\Vueling\Data\MDF\VuelingDB.mdf',
	size=4MB,
	maxsize=10MB,
	filegrowth=1MB),
FILEGROUP VuelingDB_FG1
  ( NAME = 'VuelingDB_FG1_Dat1',
    FILENAME =
       'C:\CursoSqlServer2017\Vueling\Data\NDF\VuelingDB_FG1_1.ndf',
    SIZE = 1MB,
    MAXSIZE=10MB,
    FILEGROWTH=1MB),
  ( NAME = 'VuelingDB_FG1_Dat2',
    FILENAME =
       'C:\CursoSqlServer2017\Vueling\Data\NDF\VuelingDB_FG1_2.ndf',
    SIZE = 1MB,
    MAXSIZE=10MB,
    FILEGROWTH=1MB),
FILEGROUP FileStreamGroup1 CONTAINS FILESTREAM
  ( NAME = 'VuelingDB_FS',
    FILENAME = 'C:\CursoSqlServer2017\Vueling\Data\filestream1')
LOG ON(
	name=VuelingDB_log,
	filename='C:\CursoSqlServer2017\Vueling\Data\LDF\VuelingDB_log.ldf',
	size=2MB, 
	maxsize=2MB,
	filegrowth=0MB
	)
	COLLATE modern_spanish_ci_as
GO