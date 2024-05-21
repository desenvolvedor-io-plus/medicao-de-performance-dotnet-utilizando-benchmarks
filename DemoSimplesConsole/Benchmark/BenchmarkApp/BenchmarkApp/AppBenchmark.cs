using BenchmarkDotNet.Attributes;

namespace BenchmarkApp
{
    public class AppBenchmark
    {
        private string texto = "/";
        [Benchmark]
        public bool TerminaComBarraString()
        {
            return texto.EndsWith("/");
        }
        [Benchmark]
        public bool TerminaComBarraChar()
        {
            return texto.EndsWith('/');
        }
    }
}
