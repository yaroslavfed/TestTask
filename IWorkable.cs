using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public interface IWorkable
    {
        // Температура двигателя
        double EngineTemperature { get; set; }
        // Расчет мощности двигателя
        double GetPower();
        // Расчет скорости нагрева двигателя в секунду
        double GetEnginHeatingSpeed();
        // Расчет скорости охлаждения двигателя в секунду
        double GetEngineCoolingSpeed(double ambientTemperature);
    }
}
