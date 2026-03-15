// See https://aka.ms/new-console-template for more information
// Program.cs es la clase que ejecuta la consola, es la clase main o base

// Instanciación (creamos un nuevo objeto)
// Una instancia siempre inicia con el nombre de la clase
Human luis = new(); // En versiones modernas como es el caso, ya no es necesario colocar new Human(), porque C# ya sabe que queremos instanciar la clase
Human jonathan = new();

luis.Name = "Luis Gustavo";
luis.Height = 165;
luis.Weight = 62000;
luis.Age = 21;
    // Llamada de metodos
    luis.HacerEjercicio();

// Cada objeto es diferente y tiene valores en sus propiedades diferentes
jonathan.Name = "Jonathan David";
jonathan.Height = 176;
jonathan.Weight = 6800;
jonathan.Age = 27;

// Anteponer @ ayuda a crear saltos de línea en el código string que se ven relejados en la salida
// Otra opción es usar + seguido de otra apertura $ "" (concatenación de dos argumentos), o incluso
// \n para un salto de línea en la salida.
string message = $"El humano con nombre {luis.Name} tiene un peso de {luis.Weight}\n" +
$"gramos y una altura de {luis.Height} cms con una edad de {luis.Age} años.\n" +
$"Por lo que, se considera que {luis.VerGeneracion()}.";

/* Recuerda: $ (interpolación) permite imprimir valores de variables utilizando { } , @ permite hacer 
saltos de strings multilínea y + permite concatenar varios argumentos. */

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine(message);

