using System.Net.WebSockets;
using Feitep.MySql.Models;
using Feitep.MySql.Repository;

var factory = new SistemaContextFactory();
var context = factory.CreateDbContext();

var clientes = context.Clientes!.ToList();

clientes.ForEach(cliente =>
{
    System.Console.WriteLine($"{cliente.Id} - {cliente.Nome} - {cliente.DataNascimento}");
});


Console.ReadKey();