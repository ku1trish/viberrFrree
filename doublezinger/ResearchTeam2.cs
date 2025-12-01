using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class ResearchTeam
    {
        private string tema;
        private string nameOrganization;
        private int regNumber;
        private TimeFrame howlong;
        private Paper[] publication;

        public ResearchTeam(string tema, string nameOrganization, int regNumber, TimeFrame howlong)
        {
          
            this.tema = tema;
            this.nameOrganization = nameOrganization;
            this.regNumber = regNumber;
           this.howlong = howlong;

        }
        public ResearchTeam()
        {
           
           tema = "Не указана";
           nameOrganization = "Не указана";
           regNumber= 0;
           howlong = TimeFrame.Year;
        }

        public string Tema
        {
            get => tema;
            set => tema = value;
        }

        public string NameOrganization
        {
            get => nameOrganization;
            set => nameOrganization = value;
        }

        public int RegNumber
        {
            get => regNumber;
            set => regNumber = value;
        }

        public TimeFrame Howlong
        {
            get => howlong;
            set => howlong = value;
        }

        public Paper[] Publication
        {
            get => publication;
            private set => publication = value;
        }
        public Paper LastPublic
        {
            get
            {
                
                if (publication == null || publication.Length == 0)
                    return null;

                Paper lastpub = publication[0];

                for (int i = 1; i < publication.Length; i++)
                {
                    if (publication[i].PublicationDate > lastpub.PublicationDate)
                    {
                        lastpub = publication[i];
                    }
                }

                return lastpub;
            }

        }
        public bool this[TimeFrame timeframe]
        {
            get
            {
                return this.howlong == timeframe;
            }
        }

        public void AddPapers(params Paper[] papers)
        {
            if (papers == null || papers.Length == 0)
            {
                return;
            }
            int newSize = publication.Length + papers.Length;

            Paper[] temp = new Paper[newSize];

            for (int i = 0; i < publication.Length; i++)
            {
                temp[i] = publication[i];
            }
            for (int i = 0; i < papers.Length; i++)
            {
                if (papers[i] != null)
                {
                    temp[publication.Length + i] = papers[i];
                }
            }
            publication = temp;
        }
        public override string ToString()
        {
            return $"Тема исследования: {tema},oрганизация: {nameOrganization},pегистрационный номер: {regNumber},продолжительность: {howlong}, количество публикаций: {publication.Length}";
                   
        }
        public virtual string ToShortString()
        {
            return $"Тема исследования: {tema},oрганизация: {nameOrganization},pегистрационный номер: {regNumber},продолжительность: {howlong}";
        }
    }
}
