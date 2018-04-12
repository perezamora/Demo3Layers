﻿USE VuelingDB 
IF OBJECT_ID('dbo.Alumnos', 'U') IS NOT NULL
DROP TABLE dbo.Alumnos
GO
-- Creamos la Tabla
CREATE TABLE dbo.Alumnos
(
   Id  				INT NOT NULL  IDENTITY(1,1) PRIMARY KEY, -- Clave Primaria
   Guid             UNIQUEIDENTIFIER, 
   Nombre     		[NVARCHAR](50)  NOT NULL,
   Apellidos   		[NVARCHAR](50)  NOT NULL,
   Dni         		[NVARCHAR](50)  NOT NULL,
   FechaNacimiento  [DATETIME] NOT NULL, 
   Edad				INT NOT NULL,
   FechaCreacion	[NVARCHAR](50)  NOT NULL
);
GO
