namespace YagodaCore
{
    internal class YagodaCoreTest
    {
        private static void Main(string[] args)
        {
            using (var yagodaCore = new CoreYagoda())
            {
                yagodaCore.Connect();
                yagodaCore.GetInfo("79625020828").ToString();
            };
        }
    }
}