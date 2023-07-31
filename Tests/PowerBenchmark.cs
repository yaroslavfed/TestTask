namespace TestTask.Tests
{
    public class PowerBenchmark
    {
        public static async Task StartupAsync(Data _data, double ambientTemperature)
        {
            Console.WriteLine("\nЗапуск тестового стенда номер 2");
            // Создание объекта двигателя
            var _engine = new Engine(_data, ambientTemperature);
            // Словарь <скорость коленвала, мощность двигателя>
            Dictionary<double, double> indicators = new();
            // Константа определяющая количество дробных разрядов в возвращаемом значении для контроля погрешности
            const int errorRate = 5;

            // Выполнение до остановки раскручивания двигателя
            while (Math.Round(_engine.GetAmountOfTorque(_engine.CrankshaftSpeed), errorRate)  > 0)
            {
                // Модельное время 1:10
                await Task.Delay(100);

                // Заполение словаря показанями снятыми с двигателя
                indicators.Add(_engine.CrankshaftSpeed, _engine.GetPower());

                Console.WriteLine("Скорость коленвала: {0}\tМощность двигателя: {1}", _engine.CrankshaftSpeed, _engine.GetPower());

                // Увеличение скорости коленвала
                _engine.CrankshaftSpeed += _engine.CrankshaftBoost();
            }
            Console.WriteLine("\nКонец теста - двигатель перестал раскручиваться.");

            // Поиск максимального значения мощности двигателя за время его работы и скорости коленвала при которой это мощность была достигнута
            var maxPower = indicators.Max(s => s.Value);
            var crankshaftSpeedsWithMaxPower = indicators.Where(s => s.Value.Equals(maxPower)).Select(s => s.Key).ToList();

            foreach (var item in crankshaftSpeedsWithMaxPower)
            {
                Console.Write($"Максимальная мощность: {maxPower} кВч при скорости коленвала {item} рад/сек.");
            }
        }
    }
}
