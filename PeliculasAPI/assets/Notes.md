# ActionResult
- modelo
- tipo de dato que hereda de action result como "BadRequest(), NoContent()"

# IActionResult
- mismo tipo de dato que hereda de action result, cuidado con el manejo del tipo que devuelve

# How to make delay
- await Task.Delay(TimeSpan.FromSeconds(3)); //3 seconds 

# asyncronia
Todos los metodos que hereden de un metodo async desde un repositorio deben de ser asincronos, desde el nieto hasta el abuelo.

# Model binding
- Formas de pedir las inserciones en los endpoint
- [frombody]        mandar el body con el modelo
- [fromheader]      desde los headers de la solicitud
- [bindrequired]    requerido
- 

# ApiController
nos indica donde se estan produciendo los errores

# Singleton la instancia de la clase es la misma en toda la solucion.

# Scoped dentro del mismo contexto tenemos la misma instancia.

# Transient siempre retorna una instancia diferente en cada ejecución

# Tools libreria para poder hacer uso de comandos como 
add-migration 

# una vez configurada la conexion a la bd, crearla por medio de los comandos de Tools
Add-Migration Initial
Update-Database

# Automapper
paquete - AutoMapper.Extensions.Microsoft.DependencyInjection
# Azure Account - Servicios en la nube
Video 101. Crear cuenta en azure
paquete nugget - Azure.Storage.Blobs

# Para guardar la ubicacion, uso de libreria 
- Microsoft.EntityFrameworkCore.SqlServer.NetTopologySuite

# IModelBinder ------ TypeBinder
- permite crear un modelo personalizado para el binding de los datos, se puede usar para validar los datos que se reciben en el endpoint
- se debe de crear una clase que herede de IModelBinder
- por ejemplo, se puede crear un modelo que reciba un string y lo convierta a un objeto de tipo Guid

# para poder recivir la imagen desde el cliente , se debe de usar el tipo de dato IFormFile
- se usa [FromForm] para indicar que se recibe desde el formulario

# Autenticacion
- se debe de crear un modelo que reciba el usuario y la contraseña
- la autenticacion se trata de que un usuario muestre sus credenciales para verificar su identidad

# Identity
- es un sistema de autenticacion que ya viene implementado en .net core- Microsoft.AspNetCore.Identity.EntityFrameworkCore	

# json web token
- es un token que se genera para poder autenticar a un usuario

# clims
- son los datos que se guardan en el token
- se pueden guardar datos como el id del usuario, el nombre, el rol, etc



# ! no olvidar corregir tabla de PeliculasActores, no se hace correctamente la inserción de personaje
