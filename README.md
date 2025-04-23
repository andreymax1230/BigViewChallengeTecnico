# Challenge Técnico
El Challenge Técnico se desarrollo con Arquitectura Limpia y Anngular 18

# Patrones Arquitectonicos:

* Arquitectura Limpia

# Patrones de Diseño

* Patrón Repositorio
* Patrón Unit Of Work
* Patrón Mediator
* Patrón CQRS  

# Base de Datos

* SQL Server para el almacenamiento de la logica del negocio, utiliza una metodología llamada Code First para generar las tablas a traves de clases.

# Ejecución
Para ejecutar el proyecto es necesario ejecutar las imagenes de docker (docker-compose.yaml) que contiene los siguientes servicios para el funcionamiento correcto del proyecto:

* Sql Server 

Se utiliza una consola de powershell para ejecutar el docker compose, ejemplo:
* cd C:\Users\USER\source\repos\BigViewChallenge\BigViewChallenge.Api
* docker-compose up -d

# Angular
Se utiliza los siguientes comandos:
* npm install
* ng serve
