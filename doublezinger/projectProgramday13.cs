namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            Team team1 = new Team("Научная организация", 123);
            Team team2 = new Team("Научная организация", 123);
            Console.WriteLine("Сравнение объектов Team:");
            Console.WriteLine($"team1 == team2: {team1 == team2}");
            Console.WriteLine($"team1.Equals(team2): {team1.Equals(team2)}");
            Console.WriteLine($"ReferenceEquals(team1, team2): {ReferenceEquals(team1, team2)}");
            Console.WriteLine($"Хэш-код team1: {team1.GetHashCode()}");
            Console.WriteLine($"Хэш-код team2: {team2.GetHashCode()}");
            Console.WriteLine();
            try
            {
                Team team3 = new Team("Тестовая организация", 1);
                Console.WriteLine($"Исходный номер регистрации: {team3.RegNumber}");
                team3.RegNumber = -5;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Исключение перехвачено: {ex.Message}");
            }
            Console.WriteLine();
            ResearchTeam researchTeam = new ResearchTeam("Исследование ИИ", "Институт компьютерных наук", 456, TimeFrame.TwoYears);
            Person person1 = new Person("Иван", "Иванов", new DateTime(1990, 5, 15));
            Person person2 = new Person("Мария", "Петрова", new DateTime(1985, 10, 20));
            Person person3 = new Person("Алексей", "Сидоров", new DateTime(1995, 3, 8));
            Paper paper1 = new Paper("Искусственный интеллект в медицине", person1, new DateTime(2022, 6, 10));
            Paper paper2 = new Paper("Нейронные сети для обработки изображений", person2, new DateTime(2023, 9, 15));
            Paper paper3 = new Paper("Машинное обучение в финансах", person3, new DateTime(2021, 12, 5));
            researchTeam.AddMembers(person1, person2, person3);
            researchTeam.AddPapers(paper1, paper2, paper3);
            Console.WriteLine("Данные объекта ResearchTeam:");
            Console.WriteLine(researchTeam.ToString());
            Console.WriteLine();
            Console.WriteLine("Краткая информация:");
            Console.WriteLine(researchTeam.ToShortString());
            Console.WriteLine();
            Team teamFromResearch = researchTeam.Team;
            Console.WriteLine($"Свойство Team для researchTeam: {teamFromResearch}");
            Console.WriteLine();
            ResearchTeam researchTeamCopy = (ResearchTeam)researchTeam.DeepCopy();
            Console.WriteLine("Исходный объект (до изменений):");
            Console.WriteLine(researchTeam.ToShortString());
            Console.WriteLine("Копия (до изменений в исходном):");
            Console.WriteLine(researchTeamCopy.ToShortString());
            Console.WriteLine("\nИзменение данных в исходном объекте");
            researchTeam.Tema = "Новая тема исследования";
            researchTeam.NameOrganization = "Новый институт";
            researchTeam.RegNumber = 999;
            researchTeam.Howlong = TimeFrame.Long;
            Person person4 = new Person("Елена", "Кузнецова", new DateTime(1988, 7, 25));
            Paper paper4 = new Paper("Новая публикация", person4, new DateTime(2024, 1, 20));
            researchTeam.AddMembers(person4);
            researchTeam.AddPapers(paper4);
            Console.WriteLine("\nПосле изменений:");
            Console.WriteLine("Исходный объект:");
            Console.WriteLine(researchTeam.ToShortString());
            Console.WriteLine("\nКопия (должна остаться без изменений):");
            Console.WriteLine(researchTeamCopy.ToShortString());
            Paper lastPublication = researchTeam.LastPublic;
            if (lastPublication != null)
            {
                Console.WriteLine($"Последняя публикация: {lastPublication}");
            }
            else
            {
                Console.WriteLine("Нет публикаций");
            }
            Console.WriteLine($"Исследование длится год? {researchTeam[TimeFrame.Year]}");
            Console.WriteLine($"Исследование длится два года? {researchTeam[TimeFrame.TwoYears]}");
            Console.WriteLine($"Исследование длится долго? {researchTeam[TimeFrame.Long]}");
            Console.WriteLine("\nУчастники без публикаций:");
            foreach (Person person in researchTeam.MembersWithoutPublications())
            {
                Console.WriteLine($"  - {person}");
            }
            Console.WriteLine("\nПубликации за последние 2 года:");
            foreach (Paper paper in researchTeam.PublicationsLastYears(2))
            {
                Console.WriteLine($"  - {paper}");
            }
            Console.WriteLine("\n=== Задание 23 ===");
            Console.WriteLine("Участники проекта, которые не имеют публикаций:");
            int countWithoutPublications = 0;
            foreach (Person person in researchTeam.MembersWithoutPublications())
            {
                Console.WriteLine($"  • {person}");
                countWithoutPublications++;
            }
            if (countWithoutPublications == 0)
            {
                Console.WriteLine("  Все участники имеют публикации.");
            }
            Console.WriteLine($"Всего участников без публикаций: {countWithoutPublications}");
            Console.WriteLine("\n=== Задание 24 ===");
            Console.WriteLine("Публикации, вышедшие за последние два года:");
            int countRecentPublications = 0;
            foreach (Paper paper in researchTeam.PublicationsLastYears(2))
            {
                Console.WriteLine($"  • {paper.Title} (дата: {paper.Date:dd.MM.yyyy})");
                countRecentPublications++;
            }
            if (countRecentPublications == 0)
            {
                Console.WriteLine("  Нет публикаций за последние два года.");
            }
            Console.WriteLine($"Всего публикаций за последние два года: {countRecentPublications}");
            Console.WriteLine("\n=== Дополнительно: публикации за последний год ===");
            Console.WriteLine("Публикации, вышедшие за последний год:");
            int countLastYearPublications = 0;
            foreach (Paper paper in researchTeam.PublicationsLastYears(1))
            {
                Console.WriteLine($"  • {paper.Title} (дата: {paper.Date:dd.MM.yyyy})");
                countLastYearPublications++;
            }
            if (countLastYearPublications == 0)
            {
                Console.WriteLine("  Нет публикаций за последний год.");
            }
            Console.ReadKey();
        }
    }
}