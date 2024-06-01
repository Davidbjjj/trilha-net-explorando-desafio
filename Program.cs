using System;
using System.Collections.Generic;
using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");

hospedes.Add(p1);
hospedes.Add(p2);

Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

Reserva reserva = new Reserva(diasReservados: 10);
reserva.CadastrarSuite(suite);

try
{
    reserva.CadastrarHospedes(hospedes);
    Console.WriteLine("Hóspedes cadastrados com sucesso!");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao cadastrar hóspedes: {ex.Message}");
}

if (reserva.Hospedes != null)
{
    Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
    
    // Verifica se a capacidade da suíte é maior ou igual ao número de hóspedes
    if (reserva.ObterQuantidadeHospedes() <= suite.Capacidade)
    {
        Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
    }
    else
    {
        Console.WriteLine("Não é possível calcular o valor da diária. A capacidade da suíte é menor que o número de hóspedes.");
    }
}
else
{
    Console.WriteLine("Não há hóspedes na reserva.");
}
