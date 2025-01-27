using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Gábor1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fájl = "program.txt";
            RobotMenete robotMenete = new RobotMenete(fájl);
            robotMenete.ElemezdRobotokat();
            Console.ReadLine();
        }
    }
}
