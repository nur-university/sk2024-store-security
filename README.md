# SharedKernel - Security

Este proyecto es parte la implementación de una arquitectura de microservicios. 
Este en particular se encarga de la configuración los parametros de autenticación y autorización 
que se usará en todos los microservicios.

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