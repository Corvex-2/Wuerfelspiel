using System;
using System.Threading;

namespace AE_Wuefelspiel
{
    public static class Game
    {
        public const int MAX_DICES = 3;
        public const int MIN_DICES = 2;

        public static void Splash_Output()
        {
            Console.Clear();
            Console.WriteLine("Willkommen beim Wuerfelspiel!");
            Console.WriteLine("");
            Console.WriteLine("Tippe Ja ein um zu Spielen, Tippe Nein ein um das Spiel zu verlassen!");
        }

        public static void Game_Output()
        {
            Console.Clear();
            Console.WriteLine("Willkommen beim Wuerfelspiel!");
            Console.WriteLine("");
            Console.WriteLine("Die minimale Anzahl an wuerfeln betraegt 2, die maximale Anzahl an wuerfeln betraegt 3!");
        }

        public static void Userinterface_Loop()
        {
            while(true)
            {
                Splash_Output();
                ShallPlayResult result = Shall_Play(CInput.ReadString("Bitte taetigen Sie eine Eingabe: "));

                switch(result)
                {
                    case ShallPlayResult.Yes:
                        Game_Loop();
                        break;
                    case ShallPlayResult.No:
                        return;
                    case ShallPlayResult.Invalid:
                        Console.WriteLine("Sie haben leider eine inkorrekte Eingabe getaetigt. Bitte versuchen Sie es erneut.");
                        Thread.Sleep(2500);
                        break;
                    default:
                        Console.WriteLine("Ein unerwarteter Fehler ist aufgetreten! Bitte wenden Sie sich an die Entwicker des Spiel!");
                        Thread.Sleep(2500);
                        break;
                }
            }
        }

        public static void Game_Loop()
        {
            while(true)
            {
                Game_Output();

                int m_Dices = CInput.ReadInt("Bitte geben Sie an, mit wievielen Wuerfeln Sie spielen moechten: ");
                int m_EyeSum = CInput.ReadInt("Bitte geben Sie an, welche Augensumme Sie erwarten: ");
                int m_ThrowCount = CInput.ReadInt("Bitte geben Sie an, wie oft gewuerfelt werden soll: ");

                GamePlayResult result = Play_Game(m_Dices, m_EyeSum, m_ThrowCount);

                switch (result)
                {
                    case GamePlayResult.Finished:
                        Thread.Sleep(2500);
                        return;
                    case GamePlayResult.Invalid:
                        Console.WriteLine("Es scheint ein Fehler beim Spielen aufgetreten zu sein! Bitte versuchen Sie es erneut!");
                        Thread.Sleep(2500);
                        break;
                    default:
                        Console.WriteLine("Ein unerwarteter Fehler ist aufgetreten! Bitte wenden Sie sich an die Entwicker dieses Spiels!");
                        Thread.Sleep(2500);
                        break;
                }
            }
        }

        public static GamePlayResult Play_Game(int Dices, int EyeSum, int ThrowCount)
        {
            if (EyeSum < 1 || EyeSum > (6 * Dices))
            {
                Console.WriteLine($"Die Angegebene Augensumme ist unmoeglich zu erzielen!");
                return GamePlayResult.Invalid;
            }
            if(Dices < MIN_DICES || Dices > MAX_DICES)
            {
                Console.WriteLine($"Das Spiel unterstuetzt die angegebene Anzahl an Wuerfeln nicht!");
                return GamePlayResult.Invalid;
            }

            if(Dices == 2)
            {
                int m_SumMatchCount = 0;
                for(int m_CurrentThrow = 0; m_CurrentThrow < ThrowCount; m_CurrentThrow++)
                {
                    (int dice1, int dice2) m_Results = (CRandom.Random(1, 6), CRandom.Random(1, 6));

                    if ((m_Results.dice1 + m_Results.dice2) == EyeSum)
                        m_SumMatchCount++;
                }

                Console.WriteLine($"Die Augensumme {EyeSum} ist {m_SumMatchCount} mal vorgekommen!");
            }
            else
            {
                int m_SumMatchCount = 0;
                int m_SumNonDuplicate = 0;
                for(int m_CurrentThrow = 0; m_CurrentThrow < ThrowCount; m_CurrentThrow++)
                {
                    (int dice1, int dice2, int dice3) m_Results = (CRandom.Random(1, 6), CRandom.Random(1, 6), CRandom.Random(1, 6));

                    if (m_Results.dice1 != m_Results.dice2 && m_Results.dice1 != m_Results.dice3 && m_Results.dice2 != m_Results.dice3)
                        m_SumNonDuplicate++;
                    if ((m_Results.dice1 + m_Results.dice2 + m_Results.dice3) == EyeSum)
                        m_SumMatchCount++;
                }

                Console.WriteLine($"Die Augensumme {EyeSum} ist {m_SumMatchCount} mal vorgekommen!");
                Console.WriteLine($"Duplikate sind {ThrowCount - m_SumNonDuplicate} mal vorgekommen.");
            }

            return GamePlayResult.Finished;
        }

        public static ShallPlayResult Shall_Play(string Input)
        {
            if (Input.ToLower() == "ja")
                return ShallPlayResult.Yes;
            else if (Input.ToLower() == "nein")
                return ShallPlayResult.No;
            return ShallPlayResult.Invalid;
        }

        public static void Main(string[] args)
        {
            Userinterface_Loop();
        }
    }
}
