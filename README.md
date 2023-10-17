# Veterinary-Campus
# Desarrollo Backend NetCore Filtro Final

## Introducción al Proyecto de Administración de Veterinaria

El proyecto de desarrollo de software tiene como objetivo principal la creación de un sistema de administración para una veterinaria. Este sistema permitirá a los administradores y al personal de la veterinaria gestionar de manera eficiente y efectiva todas las actividades relacionadas con la atención de mascotas y la gestión de clientes.

El sistema contará con diferentes módulos que abarcarán áreas clave como el registro de pacientes, la programación de citas, el seguimiento de tratamientos médicos, la gestión de inventario de medicamentos y productos, así como la generación de reportes y estadísticas relevantes para la toma de decisiones.

El desarrollo se realizará utilizando la tecnología NetCore Version 7.0, que proporciona un entorno robusto y escalable para la creación de aplicaciones web. Se implementarán las mejores prácticas de desarrollo de software para garantizar la calidad y fiabilidad del sistema.

El proyecto de administración de veterinaria tiene como objetivo mejorar la eficiencia y la experiencia del cliente, al tiempo que facilita la gestión interna de la veterinaria. Se espera que este sistema contribuya positivamente al crecimiento y éxito del negocio.

## Contexto

La solucion a este proyecto se modicó ligeramente para eliminar el duplicado de entidades, por lo tanto, se tiene una sola entidad(Person) que engloba a :
 - Proovedor
 - Veterinario
 - Propietario

Para manejar el tipo de persona se a creado una entidad llamada PersonType la cual se va a encargar de establecer el tipo a la persona. Como Veterinario tiene una propiedad especial llamada Especialidad, decidí crear una tabla especialidad que liga a persona en general, por ende este campo puede ser null, ya que, no todas las personas tienen esa propiedad (Especialidad).   
#### Nota:
Es importante tener en cuenta los nombres de tipo para quea sean compatibles al momento de filtrarlos con las consultas
![Alt text](./image.png)

# Consultas

## Grupo A

 ## Crear un consulta que permita visualizar los veterinarios cuya especialidad sea Cirujano vascular.
 #### Se crea la especialidad
![Alt text](/ImagesReadMe/especialidad.png)
#### Se liga a la persona con tipo veterinario
![Alt text](/ImagesReadMe/people.png)
### Se hace la peticion
Ruta =  /API/Veterinarian/GetByEspeciality/Cirujano vascular
![Alt text](/ImagesReadMe/consulta1.png)

## Listar los medicamentos que pertenezcan al laboratorio Genfar
##### laboratorio
![Alt text](/ImagesReadMe/Laboratorio.png)
##### productos
![Alt text](/ImagesReadMe/producto.png)
### Se hace la peticion
Ruta = /API/Product/GetByLab/Genfar
![Alt text](/ImagesReadMe/consulta2.png)

- Mostrar las mascotas que se encuentren registradas cuya especie sea felina.

- Listar los propietarios y sus mascotas.
- Listar los medicamentos que tenga un precio de venta mayor a 50000
- Listar las mascotas que fueron atendidas por motivo de vacunacion en el primer trimestre del 2023