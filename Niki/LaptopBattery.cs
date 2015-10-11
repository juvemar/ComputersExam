namespace Computers
{
    public class LaptopBattery
    {
        internal int Percentage { get; set; }

        internal LaptopBattery()
        {
            this.Percentage = 100 / 2;
        }

        internal void Charge(int p)
        {
            Percentage += p;
            if (Percentage > 100)
            {
                Percentage = 100;
            }
            else if (Percentage < 0)
            {
                Percentage = 0;
            }
        }
    }
}
