# Sintaxis C#  

El lenguaje C# tiene varios recursos y funciones integradas que son muy útiles de aprender para mejorar nuestro nivel de programación.

## Modificadores de Strings  
1. Un string puede tener varios argumentos "concatenados". A esto se le conoce como **concatenación de cadenas de caracteres**, por ejemplo:  
```c#
string message = "Hola Morty" + "soy tu abuelo Rick!";
Output:
>>> Hola Morty soy tu abuelo Rick!
```  
+ También podemos agregar saltos de línea con el recurso \n y comillas con el recurso \":
```c#
string message = "Hola Morty\n" + "soy tu abuelo \"Rick\"!";
Output:
>>> Hola Morty 
    soy tu abuelo "Rick"!
```  
---

2. Otra manera de hacer saltos multilínea es usando el recurso @ llamado **recurso de cadena literal o textual**, le dice al compilador que trate la cadena literalmente, lo que significa que ignora las secuencias de escape (como \n para nueva línea o \\ para barra invertida). Ejemplos de uso:  
    + Para saltos de línea sin usar \n:  
    ```c#
    string message = @"Hola morty
    soy tu abuelo Rick!";
    Output:
    >>> Hola Morty 
        soy tu abuelo Rick!
    ```  

    + Para escribir símbolos especiales que frecuentemente dan problemas con C#:
    ```c#
    string message = @"Hola ""morty"" 
    soy tu abuelo {{Rick!}}";
    Output:
    >>> Hola "Morty"
        soy tu abuelo {Rick!}
    ```  

    + Para escribir rutas de archivos (paths) sin tener que usar \\\ como se suele hacer comunmente:
    ```c#
    string ruta = @"C:\Users\Bienvenido\Desktop";
    ```   
---
3. **Interpolación de cadena** es un recurso que nos permite insertar o imprimir valores de las variables o expresiones directamente dentro de la cadena usando llaves { }. Se implementa anteponiendo el símbolo $ antes de las comillas:  
```c#
string personaje = "Morty";
string message = $"Hola {personaje}\n" +
"soy tu abuelo Rick!";
Output:
>>> Hola Morty
    soy tu abuelo Rick!
```  
>Este recurso hace que la concatenación de cadenas sea más legible que usar +  

4. Combinación de **Interpolación de cadena ($)** y **cadena literal (@)**. Podemos combinar ambas para obtener cadenas que permitan interpolación y sean literales al mismo tiempo:  
```c#
string name = "Luis";
string message = @$"Hola {name} 
soy Loki!";
Output:
>>> Hola Luis
    soy Loki!
```
```c#
string name = "Miguel";
string message = $@"Hola {name} 
soy ""Luna Snow!""";
Output:
>>> Hola Luis
    soy "Luna Snow!"
```  
> Para colocar comillas dentro de un string normal o con interpolación de cadenas usamos \\", para las cadenas literales simplemente duplicamos los símbolos """". Las comillas simples ' ' no suelen dar problemas.  


> Para el caso de los **backslash**, usamos doble diagonal \\\ o mejor aún, con el recurso de cadenas literales @, simplemente la colocamos una sola vez \.








