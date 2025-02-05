using System.Collections.Generic;
using System;
using System.IO;




namespace Robot_Gábor1
{
    internal class RobotMenete
    {
        private string fájl;
        List<Robot> robotok = new List<Robot>();

        public RobotMenete(string fájl)
        {
            this.fájl = fájl;
            Beolvas();
        }

        private void Beolvas()
        {
            string[] sorok = File.ReadAllLines(fájl);
            for (int i = 1; i < sorok.Length; i++) // Az első sor a programok száma, azt nem olvassuk be
            {
                string sor = sorok[i].Trim();
                if (sor.Length > 0)  // Ha a sor nem üres
                {
                    robotok.Add(new Robot(sor));
                }
            }
        }

        public void ElemezdRobotokat()
        {
            Console.WriteLine("Adja meg a program sorszámát (1-től kezdődően):");
            int sorszam = int.Parse(Console.ReadLine()) - 1;

            if (sorszam >= 0 && sorszam < robotok.Count)
            {
                Robot robot = robotok[sorszam];
                Console.WriteLine("Az utasítássorozat: {0}", robot);

                // Feladat 1: Egyszerűsíthetőség
                bool egyszerusitheto = robot.Egyszerusitheto();
                if (egyszerusitheto)
                {
                    Console.WriteLine("Egyszerűsíthető.");
                }
                else
                {
                    Console.WriteLine("Nem egyszerűsíthető.");
                }

                // Feladat 2: Minimális lépések
                var minimalisLepesek = robot.MinimalisLepesek();

                Console.WriteLine("Minimális lépések: {0} E vagy D, {1} K vagy N.", minimalisLepesek.Item1, minimalisLepesek.Item2);

                // Feladat 3: Legnagyobb távolság
                var tavolsag = robot.LegnagyobbTavolsag();

                Console.WriteLine("Legnagyobb távolság: {0} cm, Lépés: {1}.", tavolsag.Item2, tavolsag.Item1);

                // Feladat 4: Energia költség
                int energia = robot.EnergiaKolcseg();
                Console.WriteLine("Energia szükséglet: {0} egység.", energia);
            }
            else
            {
                Console.WriteLine("Érvénytelen sorszám.");
            }
        }
    }
}

