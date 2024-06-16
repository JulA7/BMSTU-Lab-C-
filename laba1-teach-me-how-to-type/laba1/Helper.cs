using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    public static class Helper
    {
        public static int getCountErrors(string originalString, string inputString)
        {
            int countErrors = 0;
            var countElementsForOriginal = originalString.Length;
            var countElementsForInput = inputString.Length;
            var differentLenght = Math.Abs(countElementsForInput - countElementsForOriginal);

            if (differentLenght != 0)  
               countErrors += differentLenght;

            for (int i = 0; i < countElementsForOriginal; i++)
            {
                if (i >= countElementsForInput) 
                   break;
                if (originalString[i] != inputString[i]) 
                   countErrors++;
            }

            return countErrors;
        }

        public static double calculateSpeed(TimeSpan timeWriting, int countChars)
        {
            var tempCountMinut = timeWriting.Seconds / 60.0;
            var countMinut = Math.Round(tempCountMinut, 2);
            var speed = Math.Round(countChars / countMinut, 2);

            return speed;
        }
    }
}
