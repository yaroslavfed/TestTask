using System;
using System.Text.Json;

using TestTask.Tests;

namespace TestTask
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            #region JSON input data to Data class object _data
            string fileName = "Config.json";
            string jsonString = File.ReadAllText(fileName);
            var _data = JsonSerializer.Deserialize<Data>(jsonString)!;
            #endregion

            Console.WriteLine("Введите температуру окружающей среды: ");
            if (!int.TryParse(Console.ReadLine(), out int ambientTemperature))
            {
                Console.WriteLine("Неверный ввод");
                ambientTemperature = 0;
            }

#if true
            await HeatingBenchmark.StartupAsync(_data, ambientTemperature);
#endif

#if true
            await PowerBenchmark.StartupAsync(_data, ambientTemperature);
#endif
            Console.ReadKey();
        }
    }
}