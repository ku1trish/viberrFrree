ResearchTeam researchteam = new ResearchTeam(
   "Исследование зингеров",
   "Творческое объединение дабл Ж",
   12345,
   TimeFrame.TwoYears);
Person author1 = new Person("Арина",  "Михалевич", new DateTime(2008,5,12));
Person author2 = new Person("Елизавета", "Заяц", new DateTime(2007, 11, 20));
Person author3 = new Person("Полина", "Ярошевич", new DateTime(2008, 2, 12));
Paper paper1 = new Paper(
    "Главные ингридиенты загадочного зингера",
    author1,
    new DateTime(2025, 6, 11));
Paper paper2 = new Paper(
    "Кто имеет право готовить зингер",
    author2,
    new DateTime(2025, 7, 17));
Paper paper3 = new Paper(
    "Наличие грибов в зингере",
    author3,
    new DateTime(2025,9, 23));
Paper paper4 = new Paper(
    "Какие грибы используются для приготовления зингера",
    author3,
    new DateTime (2025,11,4));
researchteam.AddPapers(paper1, paper2, paper3, paper4);
string shortInfo = researchteam.ToShortString();
Console.WriteLine("Информация об исследовательской группе:");
Console.WriteLine(shortInfo);
Console.WriteLine("Полная информация: ");
Console.WriteLine(researchteam.ToString());
Console.WriteLine("Публикации: ");
if (researchteam.Publication != null)
{
    foreach (var paper in researchteam.Publication)
    {
        if (paper != null)
        {
            Console.WriteLine($"{paper}");
        }
    }
}
Paper lastPaper = researchteam.LastPublic;
if (lastPaper != null)
{
    Console.WriteLine($"Последняя публикация:");
    Console.WriteLine($"Название: {lastPaper.Title}");
    Console.WriteLine($"Автор: {lastPaper.Author.ToShortString()}");
    Console.WriteLine($"Дата: {lastPaper.Date:dd.MM.yyyy}");
}
Console.WriteLine($"Продолжительность равна Year: {researchteam[TimeFrame.Year]}");
Console.WriteLine($"Продолжительность равна TwoYears: {researchteam[TimeFrame.TwoYears]}");
Console.WriteLine($"Продолжительность равна Long: {researchteam[TimeFrame.Long]}");

