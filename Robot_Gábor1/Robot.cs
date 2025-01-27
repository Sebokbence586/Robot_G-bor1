using System.Collections.Generic;
using System.Text;
using System;

namespace Robot_Gábor1
{
    internal class Robot
    {

            private string Kód;

            public Robot(string kód)
            {
                this.Kód = kód;
            }
            public string kód()
            {
                return Kód;
            }

            // Egyszerűsítés: ellenőrzi, hogy van-e ellentétes irányú utasításpár
            public bool Egyszerusitheto()
            {
                var ellentetes = new string[,] { { "E", "D" }, { "D", "E" }, { "K", "N" }, { "N", "K" } };
                List<char> lista = new List<char>(this.Kód.ToCharArray());

                int i = 0;
                while (i < lista.Count - 1)
                {
                    bool talalt = false;
                    for (int j = 0; j < 4; j++)
                    {
                        if (lista[i].ToString() == ellentetes[j, 0] && lista[i + 1].ToString() == ellentetes[j, 1])
                        {
                            lista.RemoveAt(i);
                            lista.RemoveAt(i);
                            i = 0;  // újra kezdjük, hogy eltűnhessenek más párok is
                            talalt = true;
                            break;
                        }
                    }
                    if (!talalt)
                        i++;
                }

                return lista.Count != this.Kód.Length;
            }

            // Minimális lépések számítása
            public (int, int) MinimalisLepesek()
            {
                int keletNyugat = 0;
                int eszakDel = 0;

                foreach (var u in this.Kód)
                {
                    if (u == 'E') keletNyugat++;
                    else if (u == 'D') keletNyugat--;
                    else if (u == 'K') eszakDel++;
                    else if (u == 'N') eszakDel--;
                }

                return (Math.Abs(keletNyugat), Math.Abs(eszakDel));
            }

            // Legnagyobb távolság számítása
            public (int, double) LegnagyobbTavolsag()
            {
                int x = 0, y = 0;
                double maxTav = 0;
                int maxLepes = 0;

                for (int i = 0; i < this.Kód.Length; i++)
                {
                    if (this.Kód[i] == 'E') x++;
                    else if (this.Kód[i] == 'D') x--;
                    else if (this.Kód[i] == 'K') y++;
                    else if (this.Kód[i] == 'N') y--;

                    double tavolsag = Math.Sqrt(x * x + y * y);
                    if (tavolsag > maxTav)
                    {
                        maxTav = tavolsag;
                        maxLepes = i + 1;  // Lépés száma (1-alapú index)
                    }
                }

                return (maxLepes, Math.Round(maxTav, 3));
            }

            // Energiaköltség számítása
            public int EnergiaKolcseg()
            {
                int energia = 0;
                int iranyValtasok = 0;

                energia += this.Kód.Length;  // Minden lépéshez 1 energia

                energia += 2;  // Az első lépéshez mindig 2 energia szükséges (indulás)

                for (int i = 1; i < this.Kód.Length; i++)
                {
                    if (this.Kód[i] != this.Kód[i - 1])
                    {
                        iranyValtasok++;
                        energia += 2;  // Irányváltás energia
                    }
                }
                energia += iranyValtasok * 2;

                return energia;
            }

            // Rövidített formára alakítás
            public string RoviditettForma()
            {
                StringBuilder roviditett = new StringBuilder();
                int i = 0;

                while (i < this.Kód.Length)
                {
                    int j = i;
                    while (j < this.Kód.Length && this.Kód[i] == this.Kód[j])
                    {
                        j++;
                    }
                    if (j - i > 1)
                    {
                        roviditett.Append((j - i).ToString());
                    }
                    roviditett.Append(this.Kód[i]);
                    i = j;
                }

                return roviditett.ToString();
            }

            // Visszaalakítás a régi formára
            public string Visszaalakitas(string roviditett)
            {
                StringBuilder utasitas = new StringBuilder();
                int i = 0;

                while (i < roviditett.Length)
                {
                    if (Char.IsDigit(roviditett[i]))
                    {
                        int count = int.Parse(roviditett[i].ToString());
                        char direction = roviditett[i + 1];
                        for (int j = 0; j < count; j++)
                        {
                            utasitas.Append(direction);
                        }
                        i += 2;
                    }
                    else
                    {
                        utasitas.Append(roviditett[i]);
                        i++;
                    }
                }

                return utasitas.ToString();
            }
        }
    }
