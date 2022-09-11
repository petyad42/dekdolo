using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vigenere
{
    class Program
    {
        static void Main(string[] args)
        {
        Start:
            Console.WriteLine("Kérem írja be a kódolandó üzenetet!\n(Atbash esetén a szóköz kivételével MINDEN karaktert kötőjellel kell elválasztani!)");
            string be = Console.ReadLine();             
            be = be.ToUpper();
            Start2:
            string ki = "";
            Console.WriteLine("Milyen kód nyelvet akar megfejteni?\nNyomjon c-t, ha Caesar, nyomjon a-t, ha A1Z26, nyomjon t-t ha Atbash!\n");
            char inp = Console.ReadKey().KeyChar;
            if (inp=='c')
            {
                goto Caesar;
            }
            else if (inp == 'a')
            {
                goto A1Z26;
            }
            else if (inp == 't')
            {
                goto Atbash;
            }
            
            #region caesar
            Caesar:
            Console.WriteLine();
            Console.Write("Caesar: ");
            for (int i = 0; i < be.Length; i++)
            {
                int akt = (int)be[i];
                if (akt < 65 || akt > 90)
                {
                    ki += (((char)akt).ToString());
                }
                else if (akt==65)
                {
                    ki += ("X");
                }
                else if (akt == 66)
                {
                    ki += ("Y");
                }
                else if (akt == 67)
                {
                    ki += ("Z");
                }
                else
                {
                    int újkód = akt - 3;
                    ki += (((char)újkód).ToString());
                }
            }
            Console.WriteLine();
            goto End;
        #endregion
            #region a1z26
        A1Z26:
            Console.WriteLine();
            Console.Write("A1Z26: ");
            string point = ((char) 46).ToString();
            string[] darabol;
            string[] darabol2;          
            darabol = be.Split(' ');           
            for (int i = 0; i < darabol.Length; i++)
            {               
                darabol2 = darabol[i].Split('-');
                for (int j = 0; j < darabol2.Length; j++)
                {
                    
                    if (darabol2[j]=="!"| darabol2[j] == "?" | darabol2[j] == point | darabol2[j]=="," )
                    {
                        ki+=(darabol2[j]);
                    }
                    else if (int.Parse(darabol2[j]) < 27)
                    {
                        ki+=((char)(int.Parse(darabol2[j]) + 64));
                    }
                }
                ki+=(' ');
            }
            goto End;
        #endregion
            #region atbash
        Atbash:
            Console.WriteLine();
            Console.Write("Atbash: ");
            for (int i = 0; i < be.Length; i++)
            {
                int akt = (int)be[i];
                if (akt < 65 || akt > 90)
                {
                    ki+=(((char)akt).ToString());                  
                }
                else if(akt == 32)
                {
                    ki += (" "); 
                }
                else
                {
                    int újkód = 155 - akt;
                    ki += (((char)újkód).ToString());
                }                           
            }
            Console.WriteLine();
            goto End;
        #endregion
        End:
            Console.WriteLine(ki);
            Console.WriteLine();
            Console.WriteLine("Szeretne még fordítani? I/N");
            inp = Console.ReadKey().KeyChar;
            if (inp == 'i')
            {
                Console.WriteLine();
                Console.WriteLine("Szeretné az előzőleg fordított szöveget felhasználni, kombinált kódolás esetén?I/N");
                inp = Console.ReadKey().KeyChar;
                if (inp == 'i')
                {                  
                    be = ki;
                    Console.WriteLine();
                    Console.WriteLine("Az előző kód: " + ki);
                    goto Start2;
                }
                else if (inp == 'n')
                {
                    Console.WriteLine();
                    goto Start;
                }
                
            }
            else if (inp == 'n')
            {
                              
            }          
            Console.ReadKey();
        }
    }
}
