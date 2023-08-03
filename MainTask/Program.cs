// Задача: Написать программу, которая из имеющегося массива строк формирует новый массив из строк, длина которых 
// меньше, либо равна 3 символам. Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения 
// алгоритма. При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

// Примеры:
// [“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]
// [“1234”, “1567”, “-2”, “computer science”] → [“-2”]
// [“Russia”, “Denmark”, “Kazan”] → []

Console.WriteLine("Введите элементы для массива через точки с запятой \";\" :");
string? input = InputCheck(Console.ReadLine());

// Replace multiple spaces with a single space and then split the input
string[] myArray = input.Replace(" ", " ").Split(';', StringSplitOptions.RemoveEmptyEntries);
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
        return value.Trim();
    }
}

string[] GetNewArray(string[] array)
{
    int count = array.Count(value => !string.IsNullOrEmpty(value) && value.Trim().Length < 4 && !(value == " "));
    string[] newArray = new string[count];
    int newArrayIndex = 0;

    for (int i = 0; i < array.Length; i++)
    {
        string trimmedValue = array[i].Trim();
        if (trimmedValue.Length < 4 && !string.IsNullOrEmpty(trimmedValue) && !(trimmedValue == " "))
        {
            newArray[newArrayIndex] = trimmedValue;
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