using BookstoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BSE195BaranovaEV
{
    [DataContract]
    public class Book : Product
    {
        [DataMember]
        public short numberOfPages;
        [DataMember]
        public short year;
        [DataMember]
        public double rating;
        public short NumberOfPages
        {
            get =>  numberOfPages;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Значение numberOfPages меньше нуля");
                numberOfPages = value;
            }
        }

        public short Year
        {
            get => year;
            set
            {
                if (value >= 1990 || value <= 2020)
                    year = value;
                else
                throw new ArgumentException("Значение year не в диапазоне [1990, 2020]");
            }
        }

        public double Rating
        {
            get => rating;
            set
            {
                if (value < 0 || value >= 5)
                    throw new ArgumentException("Значение numberOfPages меньше нуля");
                rating = value;
            }
        }

        string GetShortInfo()
        {
            return $"{NumberOfPages}.{Year}.{Title.Distinct().Count()}.{(Rating * 100):F2}";
        }

        public override string ToString()
        {
            return $"{base.ToString()},  количество страниц = {NumberOfPages}, год = {Year}, рейтинг = {Rating:F3} титул = {Title}, {GetShortInfo()}";
        }
    }
}
