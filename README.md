# SharedKernel - Security

Este proyecto es parte la implementación de una arquitectura de microservicios. 
Este en particular se encarga de la configuración los parametros de autenticación y autorización 
que se usaró en todos los microservicios.

La configuración para la autenticación que se aplica es basada en Bearer Token, utilizando JWT (JSON Web Tokens) para la autenticación y autorización de los usuarios.
La autorización se realiza mediante scopes, que son cadenas de texto que representan permisos específicos dentro de la aplicación.

La implementación de la configuración de seguridad se puede realizar de la siguiente forma:

```csharp
var jwtOptions = new JwtOptions
{
	SecretKey = "YOUR_SECRET_KEY"
	ValidIssuer = "Issuer",
	ValidAudience = "Audience",
	ValidateIssuer = true,
	ValidateAudience = true,
	Lifetime = 30,
	ValidateLifetime = true
};

var listOfScopes = new List<string>
{
	"scope1",
	"scope2"
};

builder.Services.AddSecurity(jwtOptions, listOfScopes);
```

Posteriormente, se deben declarar los middlewares de autenticación y autorización en el pipeline de la aplicación:
```csharp
app.UseAuthentication();

app.UseAuthorization();
```

Para usar este proyecto, puede ser incluido mediante NuGet, o bien, puede ser incluido como un proyecto de clase dentro de su solución.
Para inluirlo via NuGet, puede usar el siguiente comando:
```bash
Install-Package Nur.Store2025.Security 
```
Or via the .NET Core command line interface:
```bash
dotnet add package Nur.Store2025.Security 
```
