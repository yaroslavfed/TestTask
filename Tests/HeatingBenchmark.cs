namespace TestTask.Tests
{
    public class HeatingBenchmark
    {
        public static async Task StartupAsync(Data _data, double ambientTemperature)
        {
            Console.WriteLine("\nЗапуск тестового стенда номер 1");
            // Создание объекта двигателя
            var _engine = new Engine(_data, ambientTemperature);
            int seconds = 0;

            // Выполнение до перегрева
            while (_engine.EngineTemperature < _engine.TOverheating)
            {
                // Модельное время 1:10
                await Task.Delay(100);

                // Разница температур нагрева и охлаждения
                _engine.EngineTemperature += GetHeating(_engine) + GetCooling(_engine, ambientTemperature);

                Console.WriteLine($"Температура двигателя: {_engine.EngineTemperature}");
                Console.WriteLine();

                // Увеличение скорости коленвала
                _engine.CrankshaftSpeed += _engine.CrankshaftBoost();
                seconds++;
            }
            Console.WriteLine($"Конец теста - перегрев двигателя.\nВремя с момента старта до перегрева: {seconds} секунды");
        }

        // Нагрев двигателя
        static double GetHeating(Engine _engine)
        {
            var result = _engine.GetEnginHeatingSpeed();

            Console.Write("Увеличение температуры двигателя: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{result}");
            Console.ResetColor();

            return result;
        }

        // Охлаждение двигателя
        static double GetCooling(Engine _engine, double ambientTemperature)
        {
            var result = _engine.GetEngineCoolingSpeed(ambientTemperature);
            Console.Write("Снижение температуры двигателя: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{result}");
            Console.ResetColor();

            return result;
        }
    }
}
