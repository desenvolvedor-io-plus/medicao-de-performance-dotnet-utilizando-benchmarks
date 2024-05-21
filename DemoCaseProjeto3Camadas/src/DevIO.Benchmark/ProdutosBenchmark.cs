using BenchmarkDotNet.Attributes;
using CsvHelper;
using DevIO.Business.Models.Produtos;
using System.Globalization;

namespace DevIO.Benchmark
{
    [MemoryDiagnoser]
    public class ProdutosBenchmark
    {
        private List<Produto> produtos;

        [GlobalSetup]
        public void Setup()
        {
            var filePath = @"SEU_PATH_AQUI";
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                produtos = csv.GetRecords<Produto>().ToList();
            }
        }

        [Benchmark]
        public List<Produto> OrdenacaoIneficiente()
        {
            var resultado = produtos
            .Select(produto =>
            {
                produto.Nome = produto.Nome.ToUpper();
                return produto;
            })
            .OrderBy(produto => produto.Nome)
            .Where(produto => produto.Ativo)  
            .ToList();
            return resultado;
        }
        [Benchmark]
        public List<Produto> OrdenacaoEficiente()
        {
            return produtos.Where(produto => produto.Ativo).OrderBy(produto => produto.Nome.ToUpper()).ToList();
        }
    }
}
