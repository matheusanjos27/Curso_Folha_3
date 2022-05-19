using System;
using Extensoes;


Console.WriteLine("Inteiro");

List<int> ListaInteiros = new List<int>();
ListaInteiros.Add(1);
ListaInteiros.Add(6);
ListaInteiros.Add(2);
ListaInteiros.Add(3);
ListaInteiros.Add(4);
ListaInteiros.Add(6);
ListaInteiros.Add(1);
ListaInteiros.Add(6);
ListaInteiros.Add(6);

Console.WriteLine("Com repeticao");
foreach (int i in ListaInteiros)
{
    Console.WriteLine(i);
}


Console.WriteLine();
Console.WriteLine("Sem repeticao");

ListaInteiros = ListaInteiros.RemoveRepetidos();


foreach (int i in ListaInteiros)
{
    Console.WriteLine(i);
}


Console.WriteLine();
Console.WriteLine("String");

List<string> ListaString = new List<string>();
ListaString.Add("Matheus");
ListaString.Add("Matheus");
ListaString.Add("Clara");
ListaString.Add("Clara");
ListaString.Add("Clara");
ListaString.Add("Alinne");
ListaString.Add("Oregano");
ListaString.Add("Alex");
ListaString.Add("Alex");

Console.WriteLine("Com repeticao");
foreach (string i in ListaString)
{
    Console.WriteLine(i);
}


Console.WriteLine();
Console.WriteLine("Sem repeticao");

ListaString = ListaString.RemoveRepetidos();


foreach (string i in ListaString)
{
    Console.WriteLine(i);
}
Console.WriteLine();

Console.WriteLine("Cpf Com repetição");
List<string> listacpf = new List<string>();
listacpf.Add("187.262.677-25");
listacpf.Add("187.262.677-25");
listacpf.Add("562.895.120-33");
listacpf.Add("123.456.789-10");
listacpf.Add("187.262.677-25");
listacpf.Add("562.895.120-33");
listacpf.Add("987.654.321-01");

foreach (string i in listacpf)
{
    Console.WriteLine(i);
}
Console.WriteLine();


listacpf = listacpf.RemoveRepetidos();

Console.WriteLine("Cpf sem repetição");
foreach(string i in listacpf)
{
    Console.WriteLine(i);
}
Console.WriteLine();


for (int i = 0; i <= 10000; i++)
{

    if (i.isArmstrong())
    {
        Console.WriteLine(i.ToString()+" é Armstrong");
    }
}

Console.ReadKey();


