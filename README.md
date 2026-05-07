# TRANSPARENCIA LOCAL: Registro de Donaciones Publicas
## 📋 Información General

Módulo: PROGRAMACION II (SIS-0122)

Universidad: UNIVERSIDAD PRIVADA DOMINGO SAVIO

Gestión: 2026

Grupo: 3

![image alt](https://github.com/Robert-VT/Proyecto6-grupo3/blob/1b21fefb5810894f6dcb2f536ca369064ff968d9/upds_logo_300.jpg)

INTEGRANTES:
-	Ismael Habib Albarracín Forondo
-	Carlos Ignacio Barvo Roca
-	Piermarco Alessio Cordova Luna
-	Sharon Ameli Dominguez Castillo
-	Roberto Ezequiel Villarreal Tirina

Docente: Andrés Grover

Fecha de Entrega: 07 de mayo de 2026

## 🎯 Planteamiento del Problema
Hoy en día muchas instituciones, campañas solidarias y organizaciones comunitarias realizan donaciones de sangre, alimentos, ropa, medicamentos entre otros recursos que ayuda a la sociedad. Sin embargo, en numerosos casos no existe un sistema digital adecuado para registrar y controlar este tipo de donaciones, lo que provoca desorganización, perdida de información y poca transparencia en el manejo de los recursos entregados a la comunidad.

La falta de un control automatizado puede generar dificultades al momento de verificar quien realizo la donación, cuál fue el destino asignado, cuanto valor representa la ayuda y si realmente fue distribuida correctamente. Esta situación afecta la confianza de los ciudadanos y limita la eficiencia en la administración de las donaciones públicas.

Es por esta razón, se desarrolló el sistema “Transparencia Local: Registro de Donaciones Públicas” una aplicación elaborada en C# .NET 10 que permite registrar, buscar, organizar y generar reportes de las donaciones realizadas. 
Este sistema contribuye directamente al cumplimiento del.

- ODS 16: Paz, justicia e Instituciones Solidas
- ODS 10: Reducción de las Desigualdades

Esto promueve la transparencia institucional, la correcta distribución de recursos y el fortalecimiento de la confianza social

## 🎯 Objetivos
Objetivos General. - Desarrollar un sistema de gestión en C# .NET 10 que permita registrar y administrar donaciones publicas para mejorar la transparencia, organización y control de los recursos solidarios mediante el uso de estructuras de datos estáticas y persistencia en archivos.

Objetivos Específicos. – 

- Implementar estructuras de datos (arrays y objetivos) para almacenar y gestionar información de las donaciones registradas.
-	Desarrollar módulos de persistencia en archivos CSV y TXT para garantizar la permanencia de la información.
-	Generar reportes automáticos que faciliten la transparencia y el control de las donaciones.
-	Aplicar principios básicos de programación estructurada y organización lógica del sistema.
-	Implementar validaciones que eviten errores en el ingreso de datos. 
-	Facilitar la exportación de información para su análisis en programas externos como Exel.

## 💻 Desarrollo del Proyecto
Tecnología utilizadas.
- Lenguaje: C#
-	Framework: .NET 10
-	IDE: Visual Studio 2026
-	Control de Versiones: Git + Github
-	Persistencia: Archivos CSV y TXT

## 💻 Estructura de Datos Implementada
Clase Principal Utilizada.

![image alt](https://github.com/Robert-VT/Proyecto6-grupo3/blob/3b10dec62fdcb853eba74b84cd536c03424e9323/1.png)

📃Descripción de Propiedades
              
|PROPIEDADES                    |DESCRIPCION                           |
|-------------------------------|--------------------------------------|
|Numero Comprobante             |Código Único generado automáticamente |
|Fecha Recepción                |Fecha de ingreso de la donación       |
|Donante                        |Nombre de la persona o instituto d.   |
|Tipo Donación                  |Tipo de ayuda recibida                |
|Valor Estimado                 |Valor monetario aproximado            |
|Destino Asignado               |Lugar o institución beneficiada       |
|Estado Distribuido             |Indica si la donación fue entregada   |
|Fecha Distribución	            |Fecha de distribución de la ayuda     |

🔹Funcionalidades Implementadas.

a)	Registro de Donaciones. – El sistema permite registrar nuevas donaciones mediante formularios en consola. Cada fonación genera automáticamente un comprobante único.

![image alt](https://github.com/Robert-VT/Proyecto6-grupo3/blob/64431b420910d14086419fadd976ca2cc2362a0e/2.png)

También se almacena la fecha exacta del registro:

![image alt](https://github.com/Robert-VT/Proyecto6-grupo3/blob/3436a268dd90bf4f02ec0000c02d7976fb3aeef8/3.png)

b)	Validación de datos. – Se implementaron validaciones para evitar errores y garantizar información correcta.

Validación de Texto. - Permite únicamente letras y espacios.
Validación de Numérica. – Controla que el usuario ingrese números válidos. 

![image alt](https://github.com/Robert-VT/Proyecto6-grupo3/blob/7cec7b54dabaf83f746db6fec82590d34c7a78c3/4.png)

c)	Búsqueda de Donaciones. – El sistema permite buscar registros por comprobante o nombre del donante utilizando LINQ.

![image alt](https://github.com/Robert-VT/Proyecto6-grupo3/blob/7cec7b54dabaf83f746db6fec82590d34c7a78c3/5.png)

d)	Listado de Donaciones Pendientes. – El programa muestra todas las donaciones que aún no fueron distribuidas. 

![image alt](https://github.com/Robert-VT/Proyecto6-grupo3/blob/7cec7b54dabaf83f746db6fec82590d34c7a78c3/6.png)

e)	Generación de Reportes. – El sistema genera automáticamente archivos TXT con información resumida de las donaciones.

![image alt](https://github.com/Robert-VT/Proyecto6-grupo3/blob/7cec7b54dabaf83f746db6fec82590d34c7a78c3/7.png)

f)	Exportación CVS. – La información puede exportarse en formato CSV para abrirse posteriormente en Exel.

![image alt](https://github.com/Robert-VT/Proyecto6-grupo3/blob/7cec7b54dabaf83f746db6fec82590d34c7a78c3/8.png)

g)	Estadísticas del Sistema. – El programa identifica automáticamente al donante con mayor aporte económico.

![image alt](https://github.com/Robert-VT/Proyecto6-grupo3/blob/7cec7b54dabaf83f746db6fec82590d34c7a78c3/9.png)

h)	Organización de Datos. – Las donaciones pueden ordenarse según:
- Más recientes 
- Más antiguas
- Mayor valor
- Menor valor

Conclusión. – El proyecto pudo permitirnos adquirir nuevos conocimientos en el transcurso de la materia de Programación II utilizando el lenguaje C# y el framework .NET 10. El sistema desarrollado cumple con los objetivos planteados al proporcionar una herramienta funcional para registrar y administrar donaciones públicas de forma organizada y transparente.

Recomendaciones. – Implementar una base de datos para almacenar mayor cantidad de registros, crear una interfaz gráfica moderna, añadir gráficos estadísticos y paneles visuales. Implementar almacenamiento

## 🌌ANEXOS
Ejemplo de Registro.

![image alt](https://github.com/Robert-VT/Proyecto6-grupo3/blob/b54dae8e90a77d65e9849c0103c25bf7c662aa07/anexo1.png)

Ejemplo de Reporte TXT

![image alt](https://github.com/Robert-VT/Proyecto6-grupo3/blob/b54dae8e90a77d65e9849c0103c25bf7c662aa07/anexo2.png)

Ejemplo de Exportación CSV

![image alt](https://github.com/Robert-VT/Proyecto6-grupo3/blob/b54dae8e90a77d65e9849c0103c25bf7c662aa07/anexo3.png)
