using System;

namespace GameAbilitiesDemo
{
    class Program
    {
        /// <summary>
        /// The function that calls the engine to run
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
