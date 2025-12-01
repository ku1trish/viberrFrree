using project;

ResearchTeam team = new ResearchTeam(" cghj", " hfgjh",123,TimeFrame.TwoYears);

Person author1 = new Person("Арина", "Зингер", new DateTime(1980, 5, 11));
Person author2 = new Person("Дмитрий", "Нагиев", new DateTime(1930, 3, 18));
Paper paper1 = new Paper("Нейронные сети", author1, new DateTime(2020, 1, 15));
Paper paper2 = new Paper("Глубокое обучение", author2, new DateTime(2022, 6, 20));

team.AddPapers(paper1, paper2);
Paper latestPaper = team.LastPublic;
Console.WriteLine($"Самая поздняя публикация: {latestPaper}");
