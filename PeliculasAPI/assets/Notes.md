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
