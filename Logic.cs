
using System;
using System.Text;

namespace Typing_Test
{
    public static class Logic
    {
        // Pure functions.

        public static double CalcWPM(int CorrectStrokes, double ElapsedMilliseconds)
        {
            if (CorrectStrokes == 0 || ElapsedMilliseconds == 0)
            {
                return 0.00;
            }

            double TotalSeconds = ElapsedMilliseconds / 1000;

            double Words = CorrectStrokes / 5.0;
            double Minutes = TotalSeconds / 60.0;

            double WPM = Words / Minutes;

            return WPM;
        }

        public static double CalcAccuracy(int CorrectStrokes,int WrongStrokes)
        {
            return (double)CorrectStrokes / (CorrectStrokes + WrongStrokes) * 100;
        }

        public static int NumberOfCorrectStrokes(string Strokes, string StringToSearchIn)
        {
            int CorrectStrokes = 0;
            for (int i = 0; i < Strokes.Length && i < StringToSearchIn.Length; i++)
            {
                if (Strokes[i] == StringToSearchIn[i])
                    CorrectStrokes++;
            }
            return CorrectStrokes;
        }

        public static string[] FillRandomWords(string[] AllWords,int NumberOfWords)
        {
            Random rnd = new Random();

            string[] CurrentWords = new string[NumberOfWords];

            for (int i = 0; i < NumberOfWords; i++)
            {
                int RandomNumber = rnd.Next(0, AllWords.Length);

                CurrentWords[i] = AllWords[RandomNumber];
            }

            return CurrentWords;
        }

        public static string ConvertStringArrayToString(string[] CurrentWords)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < CurrentWords.Length; i++)
            {
                sb.Append(CurrentWords[i]);
                sb.Append(" ");
            }

            sb.Append("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            return sb.ToString();
        }


        /// <returns>false if 1 character or more wrong</returns>
        public static bool CheckEachChar(string StringTyped,string Word)
        {
            if (StringTyped.Length > Word.Length)
            {
                return false;
            }

            for (int i = 0; i < StringTyped.Length; i++)
            {
                if (StringTyped[i] != Word[i])
                {
                    return false;
                }
            }

            return true;
        }

    }
}
