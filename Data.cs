using System.Text.Json;
using System.Text.Json.Serialization;

namespace TestTask
{
    public class Data
    {
        // Момент инерции двигателя (kg/m^2)
        public int I { get; set; }
        // Крутящий момент (H*m)
        public List<double>? M { get; set; }
        // Скорость вращения коленвала (radians/sec)
        public List<double>? V { get; set; }
        // Температура перегрева (C0)
        public int TOverheating { get; set; }
        // Коэффициент зависимости скорости нагрева от крутящего момента (C0/H*m*sec)
        public double Hm { get; set; }
        // Коэффициент зависимости скорости нагрева от скорости вращения коленвала (C0*sec/radians^2)
        public double Hv { get; set; }
        // Коэффициент зависимости скорости охлаждения от температуры двигателя и окружающей среды (1/sec)
        public double C  { get; set; }
    }
}
