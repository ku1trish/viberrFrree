using System.Collections;

namespace project
{
    public enum TimeFrame
    {
        Year,
        TwoYears,
        Long
    }
    interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }
    class Person : IEquatable<Person>
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
        public virtual object DeepCopy()
        {
            return new Person(name, lastName, birthday);
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
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return Equals((Person)obj);
        }
        public bool Equals(Person other)
        {
            if (other is null) return false;

            return name == other.name &&
                   lastName == other.lastName &&
                   birthday == other.birthday;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (name?.GetHashCode() ?? 0);
                hash = hash * 23 + (lastName?.GetHashCode() ?? 0);
                hash = hash * 23 + birthday.GetHashCode();
                return hash;
            }
        }
        public static bool operator ==(Person left, Person right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }
        public static bool operator !=(Person left, Person right)
        {
            return !(left == right);
        }
        public override string ToString()
        {
            return $"{name}, {birthday:dd.MM.yyyy}";
        }
        public virtual string ToShortString()
        {
            return $"{lastName}{name}";
        }
    }
    class Paper : IEquatable<Paper>
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
        public virtual object DeepCopy()
        {
            return new Paper(Title, (Person)Author.DeepCopy(), Date);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return Equals((Paper)obj);
        }
        public bool Equals(Paper other)
        {
            if (other is null) return false;

            return Title == other.Title &&
                   Author == other.Author &&
                   Date == other.Date;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Title?.GetHashCode() ?? 0);
                hash = hash * 23 + (Author?.GetHashCode() ?? 0);
                hash = hash * 23 + Date.GetHashCode();
                return hash;
            }
        }
        public static bool operator ==(Paper left, Paper right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }
        public static bool operator !=(Paper left, Paper right)
        {
            return !(left == right);
        }
        public override string ToString()
        {
            return $"Название: {Title}, автор: {Author}, дата публикации: {Date}";
        }
    }
    class Team : INameAndCopy, IEquatable<Team>
    {
        protected string nameOrganization;
        protected int regNumber;
        public Team(string nameOrganization, int regNumber)
        {
            this.nameOrganization = nameOrganization;
            this.regNumber = regNumber;
        }
        public Team()
        {
            nameOrganization = "Не указана";
            regNumber = 0;
        }
        public string Name
        {
            get => nameOrganization;
            set => nameOrganization = value;
        }
        public virtual object DeepCopy()
        {
            return new Team(nameOrganization, regNumber);
        }
        public string NameOrganization
        {
            get { return nameOrganization; }
            set { nameOrganization = value; }
        }
        public int RegNumber
        {
            get { return regNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Регистрационный номер должен быть положительным числом больше нуля.");
                }
                regNumber = value;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return Equals((Team)obj);
        }
        public bool Equals(Team other)
        {
            if (other is null) return false;

            return nameOrganization == other.nameOrganization &&
                   regNumber == other.regNumber;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (nameOrganization?.GetHashCode() ?? 0);
                hash = hash * 23 + regNumber.GetHashCode();
                return hash;
            }
        }
        public static bool operator ==(Team left, Team right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }
        public static bool operator !=(Team left, Team right)
        {
            return !(left == right);
        }
        public override string ToString()
        {
            return $"Организация: {nameOrganization}, регистрационный номер: {regNumber}";
        }
    }
    class ResearchTeam : Team, INameAndCopy, IEquatable<ResearchTeam>
    {
        private string tema;
        private TimeFrame howlong;
        private ArrayList publication;
        private ArrayList participants;

        public ResearchTeam(string tema, string nameOrganization, int regNumber, TimeFrame howlong) : base(nameOrganization, regNumber)
        {
            this.tema = tema;
            this.howlong = howlong;
            this.publication = new ArrayList();
            this.participants = new ArrayList();
        }

        public ResearchTeam() : base()
        {
            tema = "Не указана";
            howlong = TimeFrame.Year;
            this.publication = new ArrayList();
            this.participants = new ArrayList();
        }

        public override object DeepCopy()
        {
            ResearchTeam copy = new ResearchTeam(tema, nameOrganization, regNumber, howlong);

            foreach (Paper paper in publication)
            {
                if (paper != null)
                {
                    copy.publication.Add(paper.DeepCopy());
                }
            }

            foreach (Person person in participants)
            {
                if (person != null)
                {
                    copy.participants.Add(person.DeepCopy());
                }
            }

            return copy;
        }

        public string Tema
        {
            get => tema;
            set => tema = value;
        }

        public TimeFrame Howlong
        {
            get => howlong;
            set => howlong = value;
        }

        public ArrayList Publication
        {
            get => publication;
            set => publication = value ?? new ArrayList();
        }

        public ArrayList Participants
        {
            get => participants;
            set => participants = value ?? new ArrayList();
        }

        public Team Team
        {
            get => new Team(nameOrganization, regNumber);
            set
            {
                if (value != null)
                {
                    nameOrganization = value.NameOrganization;
                    regNumber = value.RegNumber;
                }
            }
        }

        public Paper LastPublic
        {
            get
            {
                if (publication == null || publication.Count == 0)
                    return null;

                Paper lastpub = null;
                foreach (Paper paper in publication)
                {
                    if (paper != null)
                    {
                        if (lastpub == null || paper.Date > lastpub.Date)
                        {
                            lastpub = paper;
                        }
                    }
                }
                return lastpub;
            }
        }

        public bool this[TimeFrame timeframe]
        {
            get => this.howlong == timeframe;
        }

        public void AddPapers(params Paper[] papers)
        {
            if (papers == null || papers.Length == 0)
                return;

            foreach (Paper paper in papers)
            {
                if (paper != null)
                {
                    publication.Add(paper);
                }
            }
        }

        public void AddMembers(params Person[] persons)
        {
            if (persons == null || persons.Length == 0)
                return;

            foreach (Person person in persons)
            {
                if (person != null)
                {
                    participants.Add(person);
                }
            }
        }
        public IEnumerable MembersWithoutPublications()
        {
            foreach (Person person in participants)
            {
                if (person != null)
                {
                    bool hasPublication = false;
                    foreach (Paper paper in publication)
                    {
                        if (paper != null && paper.Author != null && paper.Author.Equals(person))
                        {
                            hasPublication = true;
                            break;
                        }
                    }

                    if (!hasPublication)
                    {
                        yield return person;
                    }
                }
            }
        }
        public IEnumerable PublicationsLastYears(int n)
        {
            if (n < 0)
                yield break;

            DateTime minDate = DateTime.Now.AddYears(-n);

            foreach (Paper paper in publication)
            {
                if (paper != null && paper.Date >= minDate)
                {
                    yield return paper;
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return Equals((ResearchTeam)obj);
        }

        public bool Equals(ResearchTeam other)
        {
            if (other is null) return false;
            if (!base.Equals(other)) return false;
            if (tema != other.tema || howlong != other.howlong)
                return false;
            if (publication.Count != other.publication.Count)
                return false;
            if (participants.Count != other.participants.Count)
                return false;

            for (int i = 0; i < publication.Count; i++)
            {
                Paper p1 = publication[i] as Paper;
                Paper p2 = other.publication[i] as Paper;
                if ((p1 == null && p2 != null) || (p1 != null && p2 == null) || (p1 != null && p2 != null && !p1.Equals(p2)))
                    return false;
            }

            for (int i = 0; i < participants.Count; i++)
            {
                Person p1 = participants[i] as Person;
                Person p2 = other.participants[i] as Person;
                if ((p1 == null && p2 != null) || (p1 != null && p2 == null) || (p1 != null && p2 != null && !p1.Equals(p2)))
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = base.GetHashCode();
                hash = hash * 23 + (tema?.GetHashCode() ?? 0);
                hash = hash * 23 + howlong.GetHashCode();

                foreach (Paper paper in publication)
                {
                    hash = hash * 23 + (paper?.GetHashCode() ?? 0);
                }

                foreach (Person person in participants)
                {
                    hash = hash * 23 + (person?.GetHashCode() ?? 0);
                }

                return hash;
            }
        }

        public static bool operator ==(ResearchTeam left, ResearchTeam right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        public static bool operator !=(ResearchTeam left, ResearchTeam right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            string result = $"Тема исследования: {tema}, организация: {nameOrganization}, " +
                           $"регистрационный номер: {regNumber}, продолжительность: {howlong}\n";

            result += "Участники проекта:\n";
            foreach (Person person in participants)
            {
                if (person != null)
                {
                    result += $"  - {person}\n";
                }
            }

            result += "Публикации:\n";
            foreach (Paper paper in publication)
            {
                if (paper != null)
                {
                    result += $"  - {paper}\n";
                }
            }

            return result;
        }

        public virtual string ToShortString()
        {
            return $"Тема исследования: {tema}, организация: {nameOrganization}, " +
                   $"регистрационный номер: {regNumber}, продолжительность: {howlong}, " +
                   $"участников: {participants.Count}, публикаций: {publication.Count}";
        }
    }
}
