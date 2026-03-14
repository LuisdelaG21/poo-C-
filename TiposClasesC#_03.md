# Tipos de objetos en C# (V.9.0+)  

En C#, la elección entre **class**, **record** y **struct** no es solo de estilo — afecta directamente *cómo se almacenan los datos en memoria*, cómo se comparan y qué tan seguros son de usar.  

En C#, un objeto es una **instancia en memoria** de un tipo definido, principalmente clases, estructuras o récords. Mientras que la clase actúa como el plano o molde, el objeto es la entidad concreta que posee un estado (propiedades), comportamiento (métodos) e **identidad única**. Todos los tipos en C# heredan en última instancia de la clase base object, permitiendo su gestión unificada.  

### **Clasificación y Naturaleza de los Objetos**  

Para entender los "tipos" de objetos, debemos distinguir cómo se crean y almacenan:  

+ **Instancias de Clases** (Tipos por referencia): Son los objetos tradicionales creados con la palabra reservada *new*. Se almacenan en el **heap** y su variable contiene una referencia a la **dirección de memoria** donde reside el objeto.  

+ **Estructuras** (Tipos por valor): Aunque son tipos, se comportan como objetos al permitir encapsular datos y métodos. Se almacenan directamente donde se declaran (usualmente en el **stack**), lo que los hace más eficientes para datos pequeños.  

+ **Récords** (Records): Introducidos para modelos de datos inmutables, facilitan la comparación de igualdad **basada en valores** en lugar de referencias, ideal para transferencia de datos.  

## Conceptos Clave
+ **Clase vs. Objeto**: La clase define la estructura; el objeto es el elemento vivo en ejecución que ocupa memoria.  

+ **Identidad**: Cada objeto tiene una identidad única en memoria, incluso si dos objetos tienen los mismos valores en sus propiedades.  

+ **Genéricos**: Permiten crear objetos de tipos flexibles (ej. List< T >), donde el tipo de objeto contenido se define al momento de la instanciación.  

+ **Stack (pila)**: zona de memoria pequeña y muy rápida. Aquí se guardan valores directamente — números, booleanos, y referencias (punteros) a objetos. Se gestiona sola: cuando una función termina, su bloque de stack desaparece automáticamente.
+ **Heap (montículo)**: zona de memoria más grande y flexible. Aquí viven los objetos complejos. No se libera sola — el Garbage Collector (GC) de .NET se encarga de limpiar lo que ya no se usa.
> **Tipo por valor** (value type): guarda el dato directamente donde se declara (normalmente en el stack). **Copiar una variable copia el valor entero**.  

> **Tipo por referencia** (reference type): guarda una referencia (una dirección de memoria) en el stack, pero el objeto real vive en el heap. **Copiar una variable solo copia la referencia — ambas variables apuntan al mismo objeto**.  

## Las tres opciones: _class_, _struct_ y _record_  

![Diagrama de tipos de objeto](./Resources/Tipos%20de%20objetos.png)   

## 1. class — el tipo de referencia clásico  
---  

Es el bloque más fundamental de la POO en C#. Cuando creas un objeto de una clase, el objeto vive en el **heap** y lo que tienes en tu variable es una **referencia** (dirección de memoria) hacia ese objeto.
```c#
public class Persona
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
}

var persona1 = new Persona { Nombre = "Ana", Edad = 30 };
var persona2 = persona1; // ¡No copia el objeto! Copia la referencia

persona2.Nombre = "Luis";

Console.WriteLine(persona1.Nombre); // "Luis" — ambas apuntan al mismo objeto
``` 

**Igualdad por identidad**: por defecto, dos variables de tipo class son iguales solo *si apuntan exactamente al mismo objeto en memoria*, no si tienen los mismos datos.  
```c#
var a = new Persona { Nombre = "Ana", Edad = 30 };
var b = new Persona { Nombre = "Ana", Edad = 30 };

Console.WriteLine(a == b); // false — son dos objetos distintos en el heap
```  

Soporta **herencia, polimorfismo** y toda la maquinaria clásica de la POO. Es **mutable** por defecto (puedes cambiar sus propiedades después de crearlo).  

> **¿Cuándo usar class?** Cuando el objeto tiene identidad propia, ciclo de vida largo, o necesitas herencia. Ejemplos: *UsuarioService*, *ProductoRepository*, *EmailSender*.

## 2. struct — el tipo de valor
---  
Un struct guarda sus datos directamente donde se declara. En la práctica, esto suele significar el **stack**, lo que lo hace muy eficiente en memoria y velocidad para datos pequeños.  
```c#
public struct Punto
{
    public int X { get; set; }
    public int Y { get; set; }
}

var p1 = new Punto { X = 10, Y = 20 };
var p2 = p1; // Copia COMPLETA del valor

p2.X = 99;

Console.WriteLine(p1.X); // 10 — p1 no fue afectado, son copias independientes
```  

**Igualdad por valor**: dos struct son iguales *si todos sus campos tienen el mismo valor*. Esto viene automáticamente.  

No soporta herencia (aunque sí puede implementar **interfaces** --> *se verá más adelante*). Al ser copiado en cada asignación, un struct grande puede ser contraproducente — el costo de copiar 100 campos en cada operación supera el beneficio de evitar el heap.  

> **¿Cuándo usar struct?** Cuando el tipo es pequeño (2-4 campos), representa un valor simple sin identidad, y se usa mucho en colecciones o bucles. Ejemplos: *Point*, *Vector3*, *Color*, *DateTime*.  

## 3. record — inmutabilidad e igualdad por valor
---  
Un record es, en esencia, una **clase especial**. Por eso comparte el mismo modelo de memoria: la variable vive en el stack y actúa como un puntero (referencia) hacia el objeto real que está en el heap.  

Introducido en C# 9, el record nació para resolver un problema frecuente: necesitar una clase cuya **igualdad se base en sus datos**, no en su identidad, y que sea inmutable por defecto.  

**Inmutable** significa que una vez creado, no puedes cambiar sus propiedades. Esto hace el código más predecible y seguro, especialmente en aplicaciones concurrentes o de mensajería.  
```c#
public record Factura(string Numero, decimal Total, string Cliente);

var f1 = new Factura("F-001", 1500.00m, "Acme Corp");
var f2 = new Factura("F-001", 1500.00m, "Acme Corp");

Console.WriteLine(f1 == f2); // true — igualdad por valor, automáticamente
```  

![Estrcutura en memoria de un objeto record](./Resources/Estructura%20record.png)


+ **¿Qué pasa exactamente con la igualdad?**  
   
   Cuando f1 == f2 es true, son **DOS objetos distintos en el heap**, cada uno con su propia dirección de memoria. La igualdad no significa que compartan la misma ubicación — significa que el compilador generó automáticamente un método **Equals** que compara propiedad por propiedad.  

   ```c#
    var f1 = new Factura("F-001", 1500.00m, "Acme Corp");
    var f2 = new Factura("F-001", 1500.00m, "Acme Corp");

    // f1 vive en, digamos, 0x4A10 en el heap
    // f2 vive en, digamos, 0x7B30 en el heap
    // Son objetos DISTINTOS en memoria

    Console.WriteLine(f1 == f2); // true  → compara datos
    Console.WriteLine(ReferenceEquals(f1,f2)); // false →      compara direcciones
   ``` 



El compilador genera automáticamente: constructor, **Equals**, **GetHashCode**, **ToString** y el operador **==** basado en los valores de las propiedades. No tienes que escribir nada de eso.  

Para "modificar" un record, usas la expresión **with**, que crea una copia nueva con los cambios especificados — el original nunca se toca:
```c#
var f1 = new Factura("F-001", 1500.00m, "Acme Corp");
var f2 = f1 with { Total = 2000.00m }; // nueva factura, f1 intacta

Console.WriteLine(f1.Total); // 1500.00
Console.WriteLine(f2.Total); // 2000.00
```  

![Compilador usando record](./Resources/Compilador%20usando%20record.png)

También existe el **record struct** (C# 10), que combina la semántica de valor del struct con las ventajas del record.

> **¿Cuándo usar record?** Cuando los datos representan un hecho o mensaje que no debería cambiar: DTOs (Data Transfer Objects), eventos de dominio, respuestas de API, configuraciones. Ejemplos: *PedidoCreadoEvent*, *UsuarioDto*, *ConfiguracionApp*.  

### Regla de oro para elegir

Cuando tengas dudas, esta lógica te guía:  

1. **¿El objeto tiene identidad propia y puede cambiar con el tiempo?** → class (una cuenta bancaria, un usuario, un servicio).  

2. **¿Es un dato pequeño y simple que representa un valor matemático o físico?** → struct (una coordenada, un color, un rango numérico).  

3. **¿Es un dato que representa un hecho, mensaje o estado que no debería cambiar?** → record (una respuesta de API, un evento ocurrido, un DTO).

--> Pendiente, agregar conceptos sobre interfaz en el contexto de objetos (struct).


