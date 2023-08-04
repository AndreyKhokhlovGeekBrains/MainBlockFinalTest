# Текстовое описание решения

## Задача

Написать программу, которая из имеющегося массива строк формирует новый массив из строк, длина которых меньше, либо равна 3 символам. Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

## Примеры

[“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]

[“1234”, “1567”, “-2”, “computer science”] → [“-2”]

[“Russia”, “Denmark”, “Kazan”] → []

## Решение

1. Запрашиваем вводные данные у пользователя с применением текстовой подсказки, в которой просим пользователя разделить элементы с помощью точки с запятой (;). Для текстовой подсказки используется функция Console.WriteLine. Вот так: Console.WriteLine("Введите элементы для массива через точки с запятой \";\" :").

2. Сохраняем введенные данные в переменную с именем *"input"*. Данная переменная имеет тип данных *string*. Вот так: string? input = InputCheck(Console.ReadLine()).

__Примечание__

*В C# вопросительный знак после типа указывает на то, что переменная имеет тип nullable. Использование нулевых типов полезно в ситуациях, когда значение может быть недоступно или когда необходимо отличить пустое значение от отсутствующего. Например, при чтении пользовательского ввода из консоли он может быть пустым (допустимая строка, не содержащая символов) или полностью нулевым, если ввода не было вообще. Использование нулевых типов позволяет более эффективно справляться с подобными сценариями.*

*Однако в моем коде использование string? является излишним и может быть заменено на string. Поскольку Console.ReadLine() возвращает строку, нет необходимости явно объявлять ввод как string? Вместо этого можно напрямую использовать string input = Console.ReadLine()*

*Вопросительный знак используется только с целью избежать навязчивого подчеркивания, подсказывающего, что значение может принимать null value*

3. Создаем массив с именем *myArray* и типом данных *string*. Массив создается с помощью функции *Split*, где разделителем элементов является точка с запятой (;), а с помощью метода *StringSplitOptions.RemoveEmptyEntries* обрабатываются (удаляются) пустые значения, введенные двумя последовательными точками с запятой (";;"). Вот так: string[] myArray = input.Split(';', StringSplitOptions.RemoveEmptyEntries).

4. 
for(int i = 0; i < myArray.Length; i++)
{
    myArray[i] = myArray[i].Trim();
}

string[] newArray = GetNewArray(myArray);
Console.WriteLine("Строки нового массива длина которых меньше, либо равна 3 символам:");
PrintArray(newArray);

//--//--//--//

string InputCheck(string value)
{
    if (string.IsNullOrEmpty(value))
    {
        Console.WriteLine("Введено пустое значение. Необходимо ввести хотя бы один символ:");
        string? newValue = Console.ReadLine();
        return InputCheck(newValue);
    }
    else
    {
        return value;
    }
}

string[] GetNewArray(string[] array)
{
    int count = array.Count(value => !string.IsNullOrEmpty(value) && value.Length < 4 && !(value == " "));
    string[] newArray = new string[count];
    int newArrayIndex = 0;

    for (int i = 0; i < array.Length; i++)
    {
        string value = array[i];
        if (value.Length < 4 && !string.IsNullOrEmpty(value) && !(value == " "))
        {
            newArray[newArrayIndex] = value;
            newArrayIndex++;
        }
    }
    return newArray;
}

void PrintArray(string[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.WriteLine($"{i + 1}: {array[i]}");
    }
}