//I need to figure out how to break out of the while loop. 
//I may have to look into threading but that's a little advanced for now...

namespace Hello
{
    using System;
    using System.IO;
    class TextReader
    {
        public void ReadFile()
        {
            Start:
            Console.Clear();
            Console.WriteLine("Please give me a path to a txt file!");
            string location = @Console.ReadLine();
            //need to add a section to print the last few lines
            ReadIt(location);

            Console.Write("Would you like to do another?(Yes/No): ");
            string loop = Console.ReadLine();
            if (loop.ToLower() == "yes")
                goto Start;
        }

        private void ReadIt(string args)
        {
            if (args.Length == 0)
                throw new ArgumentNullException("File Name", "you must supply a file name as an argument");

            string fileName = args;

            Start:

            try
            {
                using (StreamReader reader = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    //start at the end of the file
                    long lastMaxOffset = reader.BaseStream.Length;

                    while (true) //needs an escape
                    {
                        System.Threading.Thread.Sleep(100);

                        //if the file size has not changed, idle
                        if (reader.BaseStream.Length == lastMaxOffset)
                            continue;

                        //seek to the last max offset
                        reader.BaseStream.Seek(lastMaxOffset, SeekOrigin.Begin);

                        //read out of the file until the EOF
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                            Console.WriteLine(line);

                        //update the last max offset
                        lastMaxOffset = reader.BaseStream.Position;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                //prompt user to restart
                Console.Write("Would you like to try re-opening the file? Y/N:");
                if (Console.ReadLine().ToUpper() == "Y")
                    goto Start;
            }
        }
    }
}
