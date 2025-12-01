public enum TimeFrame
{
    Year,
    TwoYears,
    Long
}
public class Person
{
    private string name;
    private string lastName;
    private DateTime birthday;
    public Person(string name, string lastName, DateTime birthday)
    {
        this.name = name;
        this.lastName = lastName;
        this.birthday = birthday;
    }
    public Person()
    {
        name = "Неизвестный";
        lastName = "автор";
        birthday = DateTime.Now;
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
    public DateTime Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }
    public int Birthyear
    {
        get { return birthday.Year; }
        set
        {
            birthday = new DateTime(value, birthday.Month, birthday.Day);
        }
    }
    public override string ToString()
    {
        return $"{lastName} {name}, {birthday: dd.MM.yyyy}";
    }
    public virtual string ToShortString()
    {
        return $"{lastName} {name}";
    }
}
public class Paper
{
    public string Title { get; set; }
    public Person Author { get; set; }
    public DateTime Date { get; set; }


    public Paper(string title, Person author, DateTime date)
    {
        Title = title;
        Author = author;
        Date = date;
    }
    public Paper()
    {
        Title = "Без названия";
        Author = new Person();
        Date = DateTime.Now;
    }
    public override string ToString()
    {
        return $"Название: {Title}, автор: {Author}, дата публикации: {Date}";
    }
}
