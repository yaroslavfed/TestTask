namespace TestTask
{
    public class Engine : Data, IWorkable
    {
        public Engine(Data _data, double ambientTemperature)
        {
            I = _data.I;
            M = _data.M;
            V = _data.V;
            TOverheating = _data.TOverheating;
            Hm = _data.Hm;
            Hv = _data.Hv;
            C = _data.C;
            EngineTemperature = ambientTemperature;
            CrankshaftSpeed = V[0];
        }

        // Скорость коленвала
        public double CrankshaftSpeed { get; set; }
        public double EngineTemperature { get; set; }

        // Ускорение коленвала
        public virtual double CrankshaftBoost()
        {
            return GetAmountOfTorque(CrankshaftSpeed) / I;
        }

        public virtual double GetEnginHeatingSpeed()
        {
            return Hm * GetAmountOfTorque(CrankshaftSpeed) + Hv * Math.Pow(CrankshaftSpeed, 2);
        }

        public virtual double GetEngineCoolingSpeed(double ambientTemperature)
        {
            return C * (ambientTemperature - EngineTemperature);
        }

        public virtual double GetPower()
        {
            return GetAmountOfTorque(CrankshaftSpeed) * CrankshaftSpeed / 1000;
        }

        // Получение величины крутящего момента двигателя (M) от величины скорости вращения коленвала (V)
        public double GetAmountOfTorque(double x)
        {
            if (!V.Contains(x))
            {
                var xa = V.Where(obj => obj < x).Max();
                var xb = V.Where(obj => obj > x).Min();

                var ya = M[V.IndexOf(xa)];
                var yb = M[V.IndexOf(xb)];

                return GetY(xa, xb, ya, yb, x);
            }
            return M[V.IndexOf(x)];

            static double GetY(double xa, double xb, double ya, double yb, double x) => ((x - xa) * (yb - ya) / (xb - xa)) + ya;
        }
    }
}
