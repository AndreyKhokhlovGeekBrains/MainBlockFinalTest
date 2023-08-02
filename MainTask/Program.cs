// Задача: Написать программу, которая из имеющегося массива строк формирует новый массив из строк, длина которых 
// меньше, либо равна 3 символам. Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения 
// алгоритма. При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

// Примеры:
// [“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]
// [“1234”, “1567”, “-2”, “computer science”] → [“-2”]
// [“Russia”, “Denmark”, “Kazan”] → []

Console.WriteLine("Введите элементы для массива через точки с запятой \";\" :");
string? input = Console.ReadLine();
string[] myArray = new string[GetSizeForArray(input) + 1];
Console.WriteLine(myArray.Length);

//--//--//--//

int GetSizeForArray(string value)
{
    int count = 0;

    if (value == "")
    {
        Console.WriteLine("Введено пустое значение. Необходимо ввести хотя бы один символ:");
        string? newValue = Console.ReadLine();
        return GetSizeForArray(newValue);
    }
    else
    {
        foreach (char character in value)
        {
            count = character == ';' ? ++count : count;
        }
        return count;
    }
}