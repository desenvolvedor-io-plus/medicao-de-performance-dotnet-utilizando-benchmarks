// See https://aka.ms/new-console-template for more information
using BenchmarkApp;
using BenchmarkDotNet.Running;

Console.WriteLine("Hello, World!");

var summary = BenchmarkRunner.Run<AppBenchmark>();