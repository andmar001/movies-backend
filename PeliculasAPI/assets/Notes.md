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
