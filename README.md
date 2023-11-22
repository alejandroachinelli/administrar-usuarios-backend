### Requisitos previos

* .NET Core SDK (versión 7.0 o superior)
* SQL Server (o la base de datos de tu elección)
* Docker (opcional, si deseas ejecutar la aplicación en un contenedor)

### Instrucciones para ejecutar

1. Clonar el repositorio:

```
git clone https://github.com/alejandroachinelli/administrar-usuarios-backend.git
cd administrar-usuarios-backend
```

2. Restaurar dependencias y configurar la base de datos:

* Asegúrate de que .NET SDK esté instalado.
* Restaura las dependencias y configura la base de datos ejecutando los siguientes comandos:

```
dotnet restore
dotnet ef database update
```

* Esto restaurará las dependencias del proyecto y aplicará las migraciones necesarias a la base de datos.

3. Configurar la base de datos:

* Abre appsettings.json y configura la cadena de conexión a tu base de datos SQL Server.

4. Ejecutar la aplicación localmente:

```
dotnet run
```

* La aplicación estará disponible en https://localhost:5288.
* Puede revisar la documentacion de la API con Swagger en el puerto https://localhost:7050.

5. Opcional: Dockerizar la aplicación:

```
docker build -t administrar-usuarios-backend .
docker run -p 5288:80 administrar-usuarios-backend
```

* La aplicación estará disponible en http://localhost:5288.