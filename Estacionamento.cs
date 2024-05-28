using System;
using System.Collections.Generic;

public class Veiculo
{
    public string Placa { get; set; }
    public DateTime HoraEntrada { get; set; }
}

public class Estacionamento
{
    private List<Veiculo> veiculosEstacionados = new List<Veiculo>();

    public void AdicionarVeiculo(string placa)
    {
        veiculosEstacionados.Add(new Veiculo { Placa = placa, HoraEntrada = DateTime.Now });
        Console.WriteLine($"Veículo {placa} adicionado com sucesso.");
    }

    public void RemoverVeiculo(string placa)
    {
        var veiculo = veiculosEstacionados.Find(v => v.Placa == placa);
        if (veiculo != null)
        {
            veiculosEstacionados.Remove(veiculo);
            var duracao = DateTime.Now - veiculo.HoraEntrada;
            var valorCobrado = CalcularValorCobrado(duracao);
            Console.WriteLine($"Veículo {placa} removido. Valor cobrado: {valorCobrado:C}");
        }
        else
        {
            Console.WriteLine("Veículo não encontrado.");
        }
    }

    public void ListarVeiculos()
    {
        Console.WriteLine("Veículos estacionados:");
        foreach (var veiculo in veiculosEstacionados)
        {
            Console.WriteLine($"- {veiculo.Placa}");
        }
    }

    private decimal CalcularValorCobrado(TimeSpan duracao)
    {
        // Implemente a lógica para calcular o valor cobrado com base na duração
        // Exemplo: valor fixo por hora ou tarifa variável
        return 0m;
    }
}

class Estacionamento
{
    static void Main()
    {
        var estacionamento = new Estacionamento();
        estacionamento.AdicionarVeiculo("ABC123");
        estacionamento.ListarVeiculos();
        estacionamento.RemoverVeiculo("ABC123");
    }
}
