# Stack vs Heap memory  

La memoria de una aplicación se divide principalmente en tres secciones: **código de máquina**, **Stack** y **Heap**.  

### 1. **Memoria Stack** (Pila)  

+ **Estructura**: Funciona bajo el principio LIFO (Last In, First Out), similar a una pila de libros donde solo puedes interactuar con el elemento superior.

+ **Función**: Se encarga del "Call Stack" (pila de llamadas), rastreando qué método se está ejecutando y a cuál debe regresar el control al terminar. También almacena las variables locales.

+ **Persistencia**: Las variables en el stack son _efímeras_; desaparecen en cuanto el método finaliza su ejecución y la memoria se libera.  

+ **Matiz Técnico**: Es extremadamente rápida (asignación $O(1)$) porque la CPU usa un puntero directo. Sin embargo, su tamaño es limitado; si intentas meter demasiada información (como una recursividad infinita), ocurre un Stack Overflow.  

![Stack vs Heap](./Resources/Stack%20vs%20Heap.png)


### 2. **Memoria Heap** (Montículo)  

+ **Flexibilidad**: A diferencia del stack, permite almacenar y acceder a los datos en cualquier orden, sin restricciones de posición.

+ **Uso**: Se utiliza para datos que deben persistir más allá de la ejecución de un método o que necesitan ser compartidos en diferentes partes del código.

+ **Gestión**: Debido a su flexibilidad, tiene un mayor costo de procesamiento (overhead) para agregar o eliminar elementos.  

+ **Matiz Técnico**: A diferencia del Stack, el Heap puede sufrir fragmentación (huecos de memoria inutilizada), lo que puede afectar el rendimiento a largo plazo si no se gestiona bien.  

### 3. **Tipos de Valor vs. Referencia**  

+ **Tipos de valor** (ej. int): Almacenan el valor real. Si se declaran localmente, van al stack; si son globales o parte de una clase, se guardan en el heap.  

![Tipo de valor en Heap](./Resources/Tipo%20de%20valor%20en%20Heap.png)

+ **Tipos de referencia**: Constan de un puntero (dirección de memoria) que suele estar en el stack, mientras que el objeto o valor real reside siempre en el heap.  

![Tipo de referencia](./Resources/Tipo%20de%20referencia.png)

### 4. **El Recolector de Basura (Garbage Collector)** 

+ Es un proceso automático que escanea el heap en busca de objetos que ya no están siendo utilizados (porque ya no hay punteros que los señalen) y libera ese espacio de memoria.

### 5. **Casos Especiales y Excepciones**

+ **Variables estáticas**: Siempre se almacenan en el heap para estar disponibles globalmente. 

+ **Funciones anónimas**: A veces requieren que las variables locales se muevan al heap para poder acceder a ellas después de que el método original haya terminado.

+ **Métodos asíncronos**: Al ejecutarse en hilos separados (cada uno con su propio stack), los resultados deben almacenarse en el heap para que puedan ser recuperados por el hilo principal.  

![Metodos asincronos](./Resources/Metódos%20asíncronos.png)

### Glosario de Conceptos Clave

-  **Efímero**: En computación, se refiere a algo que tiene una vida útil muy corta y predefinida. En el contexto del Stack, significa que la variable nace y muere estrictamente dentro de las llaves { } de su función.

-  **Función Anónima** (en C#): Es un método que no tiene un nombre propio. En C# se usan comúnmente mediante expresiones lambda (ej. (x) => x * x). Son útiles para pasar bloques de código como parámetros (en LINQ, por ejemplo) sin tener que declarar un método formal en la clase.

-  **Métodos Asíncronos**: Son funciones diseñadas para no bloquear el hilo principal de ejecución mientras esperan una respuesta (como una consulta a la base de datos o una descarga). En C# los identificas por las palabras clave async y await. Permiten que la aplicación siga respondiendo mientras la "tarea" se completa en segundo plano.

-  **Overhead**: Se refiere al "exceso" o costo adicional de recursos (tiempo de CPU, memoria, red) que requiere una operación específica. Gestionar el Heap tiene más overhead que el Stack porque requiere algoritmos de búsqueda y organización más complejos.

> Video completo  
 
<!--  <a href="https://www.youtube.com/watch?v=5OJRqkYbK-4
" target="_blank"><img src="https://img.youtube.com/vi/5OJRqkYbK-4/0.jpg"
alt="IMAGE ALT TEXT HERE" width="360" height="280" border="2" /></a> -->

[![Video completo](https://img.youtube.com/vi/5OJRqkYbK-4/0.jpg)](https://www.youtube.com/watch?v=5OJRqkYbK-4)

