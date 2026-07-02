/*

1. Introducción y Objetivo General
El objetivo de este trabajo práctico es evaluar la capacidad del alumno para diseñar e implementar una
aplicación de consola en capas que gestione un sistema CRUD (Create, Read, Update, Delete) con
persistencia de datos en archivos de texto plano (.txt). El alumno deberá seleccionar uno (1) de los
enunciados presentados a continuación y desarrollar la solución completa bajo los lineamientos técnicos
especificados.

Control de Empeño y Préstamos de Objetos
Archivo de persistencia: empeños.txt
Modelo (ArticuloEmpeñado): Debe contener Id, Descripcion, MontoPrestado, DiasPlazo y
FechaIngreso (DateTime).
Reglas de Negocio / Servicio: Implementar un CRUD tradicional utilizando persistencia en
archivos. El modelo o servicio debe incluir una propiedad calculada llamada InteresAcumulado, la
cual sumará de forma dinámica un 2% del MontoPrestado por cada día transcurrido desde la
FechaIngreso hasta la fecha actual.
Interfaz de Usuario (Vistas): Menú interactivo con las opciones: 1. Registrar objetos empeñados, 2.
Listar artículos en depósito (mostrando detalladamente el dinero acumulado que el cliente debe
abonar para recuperar el objeto), 3. Liquidación de deuda (baja del registro)

Requerimientos Técnicos Obligatorios
Para que el software sea considerado válido para su evaluación, el alumno deberá cumplir estrictamente con
los siguientes patrones de desarrollo:
Arquitectura en Capas: Separación clara del código en al menos tres capas independientes:
Capa de Modelos (Entities): Clases puras que representan las entidades de datos.
Capa de Negocio / Servicio: Clases encargadas de la lógica, validaciones, cálculos y manipulación
directa del archivo de texto.
Capa de Presentación (Vistas): Flujo de consola interactivo que se comunica exclusivamente con la
capa de servicio.
Manejo de Archivos: Los datos deben persistir de manera correcta. Al cerrar y volver a abrir la
aplicación, el estado de la información debe mantenerse idéntico.
Formateo de Datos: Se permite el uso de archivos delimitados por caracteres especiales (ej: comas,
punto y coma, o barras) para facilitar la lectura y escritura de atributos por línea.

4. Criterios de Evaluación

Criterio Descripción Porcentaje

Arquitectura y
Limpieza
Correcta separación en capas (Modelos, Servicios y Vistas) sin
mezclar lógica de consola con lógica de archivos.
30%

Lógica y Reglas de
Negocio
Correcta implementación de las restricciones pedidas (cálculos de
fechas, manejo de saldos negativos, validación de duplicados, etc.).
40%

Persistencia e
Interfaz
Correcto guardado/borrado en el archivo .txt y un menú interactivo
funcional que resista ingresos inválidos.
30%

*/

ArticuloService articuloService = new();
ArticuloView articuloView = new(articuloService);

articuloView.MostrarMenu();
