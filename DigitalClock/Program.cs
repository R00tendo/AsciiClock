namespace DigitalClock
{
    public class Program
    {
        static void Main(string[] args)
        {
            var lines = Draw.Circle((int)(Console.WindowHeight / 2)-4);
            var handsDrawn = Draw.Hands(lines, Time.GetHours()+(Time.GetMinutes()>=30?1:0));

            Console.WriteLine("\n");
            handsDrawn.ForEach(Console.WriteLine);
            Console.WriteLine("\n");

            Console.WriteLine("Time is: " + DateTime.Now.Hour + ":" + Time.GetMinutes());
            Console.ReadKey();
        }
    }
}