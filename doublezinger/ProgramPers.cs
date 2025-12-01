using project;

Console.WriteLine("1. Одномерный массив Person:");
Person[] mas = new Person[3];

mas[0] = new Person("Лиза", "Скоростная", new DateTime(2007, 11, 20));
mas[1] = new Person("Полина", "Черномазая", new DateTime(2008, 2, 12));
mas[2] = new Person("Арина", "Зингер", new DateTime(2008, 5, 12));

for (int i = 0; i < mas.Length; i++)
{
    Console.WriteLine($"{mas[i]}");
}
Console.WriteLine("2. Двумерный прямоугольный массив Person:");
Person[,] mas2= new Person[2, 3];

mas2[0, 0] = new Person("Анна", "Кузнецова", new DateTime(1992, 7, 18));
mas2[0, 1] = new Person("Дмитрий", "Васильев", new DateTime(1988, 11, 30));
mas2[0, 2] = new Person("Елена", "Морозова", new DateTime(1993, 2, 14));
mas2[1, 0] = new Person("Сергей", "Николаев", new DateTime(1987, 9, 5));
mas2[1, 1] = new Person("Ольга", "Зайцева", new DateTime(1991, 4, 25));
mas2[1, 2] = new Person("Павел", "Федоров", new DateTime(1994, 12, 3));

int rows = mas2.GetLength(0);
int cols = mas2.GetLength(1);

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < cols; j++)
    {
        Console.WriteLine($" {mas2[i, j].ToShortString()}");
    }
}

Console.WriteLine("3. Ступенчатый массив Person:");

Person[][] mas3 = new Person[4][];

mas3[0] = new Person[2];  
mas3[1] = new Person[3];  
mas3[2] = new Person[1];  
mas3[3] = new Person[4];  

mas3[0][0] = new Person("Игорь", "Семенов", new DateTime(1980, 1, 10));
mas3[0][1] = new Person("Татьяна", "Иванова", new DateTime(1982, 6, 20));

mas3[1][0] = new Person("Владимир", "Попов", new DateTime(1975, 3, 15));
mas3[1][1] = new Person("Надежда", "Соколова", new DateTime(1988, 9, 5));
mas3[1][2] = new Person("Артем", "Лебедев", new DateTime(1990, 12, 25));

mas3[2][0] = new Person("Юлия", "Новикова", new DateTime(1993, 7, 30));

mas3[3][0] = new Person("Григорий", "Медведев", new DateTime(1983, 4, 12));
mas3[3][1] = new Person("Лариса", "Волкова", new DateTime(1979, 11, 8));
mas3[3][2] = new Person("Станислав", "Козлов", new DateTime(1986, 2, 28));
mas3[3][3] = new Person("Вероника", "Егорова", new DateTime(1991, 8, 17));

Console.WriteLine($"  Количество строк: {mas3.Length}");

int totalElements = 0;
for (int i = 0; i < mas3.Length; i++)
{
    Console.WriteLine($"  Строка {i} ({mas3[i].Length} элементов):");

    for (int j = 0; j < mas3[i].Length; j++)
    {
        Console.WriteLine($"    [{i}][{j}]: {mas3[i][j].ToShortString()}");
    }
    totalElements += mas3[i].Length;
}
