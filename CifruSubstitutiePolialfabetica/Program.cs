using CifruSubstitutiePolialfabetica;

PolialphabeticCipher Poli=new PolialphabeticCipher();
string message = Console.ReadLine();
message = Poli.Encrypt(message);
Console.WriteLine(message);
message = Poli.Decrypt(message);
Console.WriteLine(message);
Console.ReadKey();
