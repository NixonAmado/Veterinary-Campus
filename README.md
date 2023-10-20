# Veterinary-Campus
## Desarrollo Backend NetCore - Filtro Final

## Introducción al Proyecto de Administración de Veterinaria

El proyecto de desarrollo de software tiene como objetivo principal la creación de un sistema de administración para una veterinaria. Este sistema permitirá a los administradores y al personal de la veterinaria gestionar de manera eficiente y efectiva todas las actividades relacionadas con la atención de mascotas y la gestión de clientes.

El sistema contará con diferentes módulos que abarcarán áreas clave como el registro de pacientes, la programación de citas, el seguimiento de tratamientos médicos, la gestión de inventario de medicamentos y productos, así como la generación de reportes y estadísticas relevantes para la toma de decisiones.

El desarrollo se realizará utilizando la tecnología **NetCore Version 7.0**, que proporciona un entorno robusto y escalable para la creación de aplicaciones web. Se implementarán las mejores prácticas de desarrollo de software para garantizar la calidad y fiabilidad del sistema.

El proyecto de administración de veterinaria tiene como objetivo mejorar la eficiencia y la experiencia del cliente, al tiempo que facilita la gestión interna de la veterinaria. Se espera que este sistema contribuya positivamente al crecimiento y éxito del negocio.

## Contexto

La solución a este proyecto se modificó ligeramente para eliminar el duplicado de entidades, por lo tanto, se tiene una sola entidad (**Person**) que engloba a:
 - Proveedor
 - Veterinario
 - Propietario

Para manejar el tipo de persona se ha creado una entidad llamada **PersonType**, la cual se encargará de establecer el tipo a la persona. Como el rol de Veterinario tiene una propiedad especial llamada **Especialidad**, se ha decidido crear una tabla **Especialidad** que se relaciona con todas las personas en general. Por ende, este campo puede ser nulo, ya que no todas las personas tienen esa propiedad (Especialidad).   

Este proyecto se ha desarrollado con archivos CSV, por lo tanto, cuando se ejecute `dotnet run`, los datos se cargarán en la base de datos de manera automática. La única excepción es la carga de usuarios.



Para el CRUD, exceptuando las operaciones GET, se basan en la entidad original, aunque el el swagger se muestre de esta manera:
![Alt text](/ImagesReadMe/explicacionBasica.png)
Solo hay que pasarle los atributos y la foranea :
![Alt text](/ImagesReadMe/demostracion.png)



## Uso de Json Web Token

Ya que no se cargan usuarios en la base de datos por medio de csvs, es necesesario crearlo. Por defecto el rol de usuario va ser Empleado, el cual puede hacer peticiones a todo el CRUD menos a los enpoints especiales. Cuando se prueben los endpoints es necesario que el usuario tenga el rol de Administrador el cual se le asigna por medio del addrole. 

Los datos necesarios para poder hacer post a los endpoints de JWT y en general se encuetran más facilmente en el Swagger, que se incializa por medio de dotnet watch run.

Nota: He tenido inconvenientes con la autorización, ya que, en vez de lanzarme la respuesta 401 o 403, me lanza 404 Not found, pero si le pasamos en token igualmente funcionará.

Si el token caduca, el programa esta diseñado para que por medio de su refresh token pueda generar otro.

### Tomamos el refresh token
![Alt text](/ImagesReadMe/refreshEnToken.png)

### creamos la cookie y apartir de ese refresh token se generan nuevos tokens
Si el token expira podemos generar cuantos queramos con el mismo refresh token. Si el refresh token expira se debe generar otro token desde el endpoint token.
- Duración del refresh token: 1 hora
- Duración del token de acceso: 1 minuto
![Alt text](/ImagesReadMe/refreshToken.png)

Si se presentan inconvenientes a la hora de generar un nuevo token desde el refresh token hay que borrar las cookies.
![Alt text](/ImagesReadMe/Cookies.png)



# Consultas

## Grupo A

 ### Crear un consulta que permita visualizar los veterinarios cuya especialidad sea X.
 ### Logica Peticion
![Alt text](ImagesReadMe/logicaP1.png)
 ### Peticion Thunder
 ```
  API/Veterinarian/GetByEspeciality/Cirujano vascular
 ```
![Alt text](/ImagesReadMe/Consulta1.png)

## Listar los medicamentos que pertenezcan al laboratorio X
### Logica Peticion
![Alt text](ImagesReadMe/logicaP2.png)
 ### Peticion Thunder
 ```
 API/Product/GetByLab/Genfar
```
![Alt text](/ImagesReadMe/consulta2.png)

## Mostrar las mascotas que se encuentren registradas cuya especie sea X.
### Logica Peticion
![Alt text](ImagesReadMe/logicaP3.png)
 ### Peticion Thunder
```
 API/Pet/GetOwnerPetByBreed/golden retriver
```
![Alt text](/ImagesReadMe/consulta3.png)

## Listar los propietarios y sus mascotas.
### Logica Peticion
![Alt text](ImagesReadMe/logicaP4.png)
 ### Peticion Thunder
```
 API/Owner/GetAllOwnersAndPets
```
![Alt text](/ImagesReadMe/consulta4.png)

## Listar los medicamentos que tenga un precio de venta mayor a X
### Logica Peticion
![Alt text](ImagesReadMe/logicaP5.png)
 ### Peticion Thunder
```
 API/Product/GetGreaterThan/50000
```
![Alt text](/ImagesReadMe/consulta5.png)

## Listar las mascotas que fueron atendidas por motivo de X en el X trimestre del 2023/X
### Logica Peticion  
![Alt text](ImagesReadMe/logicaP6.png)
 ### Peticion Thunder
```
 API/Pet/GetByReasonInTrimYear/3/2023/vacunacion
```
![Alt text](/ImagesReadMe/consulta6.png)
## Grupo B
## Listar todas las mascotas agrupadas por especie.
### Logica Peticion  
![Alt text](ImagesReadMe/logicaP7.png)
 ### Peticion Thunder
```
 API/Species/GetPetGroupedBySpecies
```
![Alt text](/ImagesReadMe/consulta7.png)

## Listar todos los movimientos de medicamentos y el valor total de cada movimiento.
### Logica Peticion  
![Alt text](ImagesReadMe/logicaP8.png)
 ### Peticion Thunder
```
 API/ProductMovement/GetProductMovementAndVal
```
![Alt text](/ImagesReadMe/consulta8.png)

## Listar las mascotas que fueron atendidas por un determinado veterinario.
### Logica Peticion  
![Alt text](ImagesReadMe/logicaP9.png)
 ### Peticion Thunder
```
 API/Veterinarian/PetsAttendedByVet/Carlos
```
![Alt text](/ImagesReadMe/consulta9.png)

## Listar los proveedores que me venden un determinado medicamento.
### Logica Peticion  
![Alt text](ImagesReadMe/logicaP10.png)
 ### Peticion Thunder
```
 API/Supplier/GetSuppliersByProduct/Dopamina
```
![Alt text](/ImagesReadMe/consulta10.png)
## Listar las mascotas y sus propietarios cuya raza sea X
### Logica Peticion  
![Alt text](ImagesReadMe/logicaP11.png)
 ### Peticion Thunder
```
 API/Pet/GetOwnerPetByBreed/Golden retriver
```
![Alt text](/ImagesReadMe/consulta11.png)

## Listar la cantidad de mascotas que pertenecen a una raza. Nota: Se debe mostrar una lista de las razas y la cantidad de mascotas que pertenecen a la raza.
### Logica Peticion  
![Alt text](ImagesReadMe/logicaP12.png)
 ### Peticion Thunder
```
 API/Breed/GetPetCountInBreed
```
![Alt text](/ImagesReadMe/consulta12.png)


