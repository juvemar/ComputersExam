namespace Computers
{
    public class Rammstein
    {
        private int value;

        internal Rammstein(int a)
        {
            Amount = a;
        }

        private int Amount { get; set; }

        public void SaveValue(int newValue)
        {
            value = newValue;
        }

        public int LoadValue()
        {
            return value;
        }
    }
}
