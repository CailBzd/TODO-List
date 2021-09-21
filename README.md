# MyTodoApp

### 1/ Description.

Création d'un Api WEB représentant une "TODO-List". 

### 2/ Cas d'utilisation.

-Mise en place d'une authentification.
-Obtenir la liste tâches de l'utilisateur connecté.
-Permetttre à l'utilisateur d'ajouter une tâche.

### 3/ Contraintes.

Utilisation du pattern DDD en C# .Net 5.
dotnet new sln

### 4/ Supplément

Approche DEVOPS : Mise en place de Docker.

### 5/ Informations complémentaires

Pour lancer le projet ( à la racine de la solution ) : 
- dotnet restore.
- dotnet run.

ou
<!-- Build an image -->
- Docker build -f <docker file> - t<image name>:<version default latest> .
<!-- Tun a Desktop Image -->
- Docker run -p <external port>:<internal port>

### 6/ Commandes utiles

<!-- Création d'une web API -->
dotnet new webapi -o TODO.API
<!-- Ajout d'un projet à une solution -->
dotnet sln add <project name>/<project name>.csproj
<!-- Ajout d'une bibliothèque -->
dotnet new classlib -o <class name>
<!-- Ajout de projet en référence dans le projet receveur-->
dotnet add reference ..\<project name>\<project name>.csproj

<!-- Installation de Swagger -->
dotnet tool install --global Swashbuckle.AspNetCore.Cli --version 5.6.3

source : https://rdonfack.developpez.com/tutoriels/documenter-web-api-aspnet-core-swagger/#LV

<!-- Authentification JWT -->
<!-- Ajout de packages nuget -->
Microsoft.AspNetCore.Authentication.JwtBearer
Microsoft.IdentityModel.Tokens 
Microsoft.EntityFrameworkCore.InMemory

source : https://www.c-sharpcorner.com/article/jwt-json-web-token-authentication-in-asp-net-core/#:~:text=JWT%20(JSON%20web%20token)%20become,a%20secure%20and%20compact%20way.

<!-- Ajout du context -->
Installer nuget Microsoft.EntityFrameworkCore 

### 7/ Commandes docker
- [Build an image] : docker build -t pierrebizard/mytodoapp .
- [Push on Docker Hub] : docker push pierrebizard/mytodoapp
- [Run a DOcker image] : docker run -p 8080:80 -dpierrebizard/mytodoapp