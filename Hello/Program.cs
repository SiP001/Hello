﻿//This is a play area as I learn to write in C#
namespace Hello
{
    using System;
    class Program
    {         
        static void Main()
        {
            Welcome wm = new Welcome();
            while (true)
            {
                wm.WelcomeMessage();
                Console.Clear();               
            }
        }
    }
}