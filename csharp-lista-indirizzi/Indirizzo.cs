using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lista_indirizzi
{
    internal class Indirizzo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string ZIP { get; set; }
        

        public Indirizzo(string name, string surname, string street, string city, string province, string zip)
        {
            this.Name = name;
            this.Surname = surname;
            this.Street = street;
            this.City = city;
            this.Province = province;
            this.ZIP = zip;
        }

        public override string ToString() => $"NAME: {Name}, SURNAME: {Surname}, STREET: {Street}, CITY: {City}, PROVINCE: {Province}, ZIP: {ZIP}";
    }
}
