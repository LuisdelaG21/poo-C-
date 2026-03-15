# Constructores 

En cada clase, hay un tipo de **método especial** llamado **constructor**. Puedes crear un constructor en una clase y programarlo. Si no creas uno por ti mismo, el compilador creará un constructor muy simple y lo usará en su lugar.

En C# un constructor en un **método** que se activa cuando se **crea un objeto de una clase**. Un constructor se utiliza principalmente para **establecer** los **requisitos** previos de la clase.

En otras palabras, es un método que nos permite inicializar los valores o alguna parte importante de nuestra clase cada vez que **instanciamos** o creamos un objeto.

## Forma general de un constructor 

#### Un constructor está compuesto por:  

Un modificador de acceso, el nombre de la clase y su lista de parámetros.

![Partes de un constructor][Referencia_1]

[Referencia_1]: ./Resources/Partes%20de%20un%20constructor.png  

> IMPORTANTE: un constructor no tiene un **retorno**, es para inicializar, mas no para retornar algún tipo de acción. Normalmente es **public** para que las instancias sean posibles, en caso contrario, si queremos que no hayan instancias de una clase específica, podemos declarar su constructor como **private**.  

### Ejemplo de constructor  

Pensemos en un objeto el cual tenga una propiedad requerida desde su **creación**:

+ UNA CUENTA BANCARIA
    + Por lógica común una cuenta bancaria debe requerir siempre un propietario para saber en un futuro a quien pertenece.  

    ```c#
    class BankAccount {
        public string owner;

        public BankAccount(){
            owner = "Some customer"
        }
    }
    ```  

    > Si creamos un objeto derivada de la clase BankAccount, tendrá por defecto "Some customer" inicializado en su propiedad **owner**.  

También podemos pasarles parámetros a nuestro constructor.  

+ PODEMOS DEFINIR PARÁMETROS  

    + Dentro de la creación de nuestro constructor podemos definir que parámetros le podemos pasar y así inicializar alguna de nuestras propiedades.  

    ```c#
    class BankAccount {
        public string owner;

        public BankAccount(string theOwner){
            owner = "Some customer"
        }
    }
    ```  

    > Esto obliga, que al momento de crear un objeto derivada de esta clase, debamos pasar un valor como parámetro, generalmente una variable.  

### Primeras conclusiones

PODEMOS TENER UN VALOR DEFAULT Y UNO DINÁMICO  

Una clase puede tener uno o más constructores de diferentes tipos de acceso y esto dependerá del requerimiento funcional de la clase y los objetos.

```c#
class BankAccount {
        public string owner;

        public BankAccount(){
            owner = "Some customer"
        }

        public BankAccount(string theOwner){
            owner = "Some customer"
        }
    }
```   

> Hay múltiples maneras de definir un constructor; con o sin parámetros, con inicializaciones parciales, etc.



