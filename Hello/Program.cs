//This is a play area as I learn to write in C#
namespace Hello
{
    using System;
    class Program
    {         
        static void Main()
        {
            Menu wm = new Menu();
            while (true)
            {
                wm.WelcomeMessage();
                Console.Clear();               
            }
        }
    }
}