# Proyecto Gestion Alumnos 3 capas (3 Tier / 3 Layer)

## Introduccion

Se realiza proyecto con arquitectura 3 Layer, debido a que las capas se encuentran en el mismo servidor.
El proyecto se realiza con windows form en la capa de presentacion, el lenguaje programacion es C#.

### Estructura arquitectura
	* Presentation Layer (Winsite):
		Capa la cual se encarga de mostrar los datos al usuario.
	* Business Layer (BL):
		Capa la cual se encarga de la logica de negocio.
	* DataAcces Layer (DAO):
		Capa la cual se encarga del acceso a los datos, fuera de la aplicacion.
	* Common or Cross Cutting Layer:
		Capa comun, donde hace de puente para las funcionalidades que son requeridas por las anteriores capas.
	```
	La dependencias de las capas son las siguientes:
		Capa Presentation tiene dependencia de la Business y Common.
		Capa Business tiene dependencia de la DAO y Common.
		Capa Dao solo tiene dependencia de la Common.


En el proyecto se han ido implementado los siguientes patrones:
	- Abstract factory: Patron creacional utilizado para crear una familia objetos sin especificar un objeto concreto, en nuestro proyecto se ha creado una
	factoria de tipos formato, donde se crean objetos relacionados entre si, (XML, JSO, TXT), para poder implementar funcionalidades mutuas para almacenar los alumnos.
	- Singleton Pattern: Patron creacional utilizado para garantizar una sola instancia de una clase, en nuestro proyecto se ha aplicado para crear la lista de alumnos
	en los formatos XML, JSON, y poder trabajar de forma desconectada y poder realizar consultas directamente sobre memoria.
	- Adapater Pattern: Convierte una interfaz concreta a otra interfaz que se adapte a nuestras necesidades, para poder utilizarla sus funcionalidades a traves de la nuestra.
	En nuestro proyecto se han adaptado dos interfaces de LOG (log4net y serilog) para poder utilizarlas sobre una interfaz nuestra.

### Testing
Los testeos que se han implementado en el proyecto han sido unitarios e integrados. Realizados en la capa BL y DAO.
	* Testeo unitario con el framework NMOCK3.
	* Testeo integrado con el freamework MStest2 y xunit.

### Variables entorno
En el proyecto se han utilizado las variables entorno para poder guardar valores de la configuracion, para tener en cuenta que el estado de la ultima configuracion
que tenia el usuario al desconectar la aplicacion, en nuestro caso se han utilizado las siguientes variables locales, que se crearon al arrancar la aplicacion.
	* tipo de formatos:
		- format: (valor del formato a guardar los datos, xml, txt, json y sql).
		- fileJson: Valor del fichero donde se guardara los datos en formato Json.
		- fileXml : Valor del fichero donde se guardara los datos en formato Xml.
		- fileTxt : Valor del fichero donde se guardara los datos en formato Txt.
		- typeLog : Valor para indicar que libreria utilizamos para grabar los logs.

