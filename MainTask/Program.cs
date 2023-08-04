// Задача: Написать программу, которая из имеющегося массива строк формирует новый массив из строк, длина которых 
// меньше, либо равна 3 символам. Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения 
// алгоритма. При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

// Примеры:
// [“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]
// [“1234”, “1567”, “-2”, “computer science”] → [“-2”]
// [“Russia”, “Denmark”, “Kazan”] → []

Console.WriteLine("Введите элементы для массива через точки с запятой \";\" :");
string? input = InputCheck(Console.ReadLine());

string[] myArray = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
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