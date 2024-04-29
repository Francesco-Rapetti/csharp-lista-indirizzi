/*
    Oggi esercitazione sui file, ossia vi chiedo di prendere dimestichezza con quanto appena visto sui file in classe, in particolare nel live-coding di oggi.
    In questo esercizio dovrete leggere un file CSV, che cambia poco da quanto appena visto nel live-coding in classe, 
    e salvare tutti gli indirizzi in esso contenuti all’interno di una lista di oggetti istanziati a partire dalla classe Indirizzo.
    **Attenzione:** gli ultimi 3 indirizzi presentano dei possibili “casi particolari” che possono accadere a questo genere di file: 
    vi chiedo di pensarci e di gestire come meglio crediate queste casistiche.
 */

namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = @"F:\source\csharp-lista-indirizzi\csharp-lista-indirizzi\addresses.csv";
            using StreamReader stream = File.OpenText(path);
            List<Indirizzo> indirizzi = new List<Indirizzo>();
            foreach (var line in File.ReadLines(path).Skip(1))
            {
                Console.WriteLine(line);
                var parts = line.Split(',');
                try
                {
                    if (parts.Length != 6)
                        throw new ArgumentException("Il file CSV dovrebbe avere 6 colonne");
                    if (parts[0].Length == 0)
                        throw new InvalidFieldException("Il nome non puè essere vuoto");
                    if (IsFieldDigit(parts[0]))
                        throw new InvalidFieldException("Numeri non consentiti per il nome");
                    if (parts[1].Length == 0)
                        throw new InvalidFieldException("Il cognome non puè essere vuoto");
                    if (IsFieldDigit(parts[1]))
                        throw new ArgumentException("Numeri non consentiti per il cognome");
                    if (parts[2].Length == 0)
                        throw new InvalidFieldException("La via non puè essere vuota");
                    if (!IsStreetValid(parts[2]))
                        throw new InvalidFieldException("La via deve iniziare con il numero civico");
                    if (parts[3].Length == 0)
                        throw new InvalidFieldException("La città non puè essere vuota");
                    if (IsFieldDigit(parts[3]))
                        throw new InvalidFieldException("Numeri non consentiti per la città");
                    if (parts[4].Length == 0)
                        throw new InvalidFieldException("La provincia non puè essere vuota");
                    if (!IsProvinceValid(parts[4]))
                        throw new InvalidFieldException("La provincia non è valida");
                    if (parts[5].Length == 0)
                        throw new InvalidFieldException("Il codice postale non puè essere vuoto");
                    if (!IsZipValid(parts[5]))
                        throw new InvalidFieldException("Il codice postale non è valido");
                    indirizzi.Add(new Indirizzo(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5]));
                } catch (InvalidFieldException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                } catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                } catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

            }
            Console.Write("\n\n -");
            Console.WriteLine(string.Join("\n -", indirizzi));
        }

        static bool IsFieldDigit(string name) => name.Any(c => char.IsDigit(c));
        static bool IsStreetValid(string street) => char.IsDigit(street[0]);
        static bool IsProvinceValid(string province) => !IsFieldDigit(province) && province.Length == 2;
        static bool IsZipValid(string zip) => zip.All(char.IsDigit);

    }
}
