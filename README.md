# SharedKernel - Security

Este proyecto es parte la implementaci�n de una arquitectura de microservicios. 
Este en particular se encarga de la configuraci�n los parametros de autenticaci�n y autorizaci�n 
que se usar� en todos los microservicios.

La implementaci�n de la configuraci�n de seguridad se puede realizar de la siguiente forma:

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

Posteriormente, se deben declarar los middlewares de autenticaci�n y autorizaci�n en el pipeline de la aplicaci�n:
```csharp
app.UseAuthentication();

app.UseAuthorization();
```