using System;
using System.Collections.Generic;

public class Veiculo
{
    public int Id { get; set; }
    public string Placa { get; set; }
    public DateTime HoraEntrada { get; set; }
}

public class Estacionamento
{
    private List<Veiculo> veiculosEstacionados = new List<Veiculo>();
    private int proximoId = 1;
    private const int LimiteCarros = 7;

    public void AdicionarVeiculo(string placa)
    {
        if (veiculosEstacionados.Count >= LimiteCarros)
        {
            Console.WriteLine("Limite de carros atingido. Nao e possivel adicionar mais veigit brculos.");
            return;
        }

        veiculosEstacionados.Add(new Veiculo { Id = proximoId, Placa = placa, HoraEntrada = DateTime.Now });
        Console.WriteLine($"Veiculo {placa} (ID: {proximoId}) adicionado com sucesso.");
        proximoId++;
    }

    public void RemoverVeiculo(int id)
    {
        var veiculo = veiculosEstacionados.Find(v => v.Id == id);
        if (veiculo != null)
        {
            veiculosEstacionados.Remove(veiculo);
            Console.WriteLine($"Veiculo (ID: {id}) removido.");
        }
        else
        {
            Console.WriteLine("Veiculo nao encontrado.");
        }
    }

    public void ListarVeiculos()
    {
        Console.WriteLine("Veiculos estacionados:");
        foreach (var veiculo in veiculosEstacionados)
        {
            Console.WriteLine($"- ID: {veiculo.Id}, Placa: {veiculo.Placa}");
        }
    }
}

class Program
{
    static void Main()
    {
        var estacionamento = new Estacionamento();

        while (true)
        {
            Console.WriteLine("\nEscolha uma opcao:");
            Console.WriteLine("1. Adicionar veiculo");
            Console.WriteLine("2. Listar veiculos");
            Console.WriteLine("3. Remover veiculo por ID");
            Console.WriteLine("0. Sair");

            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite a placa do veiculo: ");
                    var placa = Console.ReadLine();
                    estacionamento.AdicionarVeiculo(placa);
                    break;
                case "2":
                    estacionamento.ListarVeiculos();
                    break;
                case "3":
                    Console.Write("Digite o ID do veiculo a ser removido: ");
                    if (int.TryParse(Console.ReadLine(), out int idRemover))
                    {
                        estacionamento.RemoverVeiculo(idRemover);
                    }
                    else
                    {
                        Console.WriteLine("ID invalido. Tente novamente.");
                    }
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opcao invalida. Tente novamente.");
                    break;
            }
        }
    }
}



