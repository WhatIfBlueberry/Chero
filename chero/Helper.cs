using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chero
{
    static class Helper
    {

        public static (int x, int y) parseInput(Field field)
        {
            String input = field.ToString();
            if (input.Length > 2)
            {
                return (-2, 8);
            }
            char[] chars = input.ToCharArray();
            char firstChar = chars[0];
            char secondChar = chars[1];
            int y = secondChar - '0';
            return (fieldnumber(firstChar), y);

        }

        public static int fieldnumber(char c)
        {
            switch (c)
            {
                case 'A':
                    return 1;
                case 'B':
                    return 2;
                case 'C':
                    return 3;
                case 'D':
                    return 4;
                case 'E':
                    return 5;
                case 'F':
                    return 6;
                case 'G':
                    return 7;
                case 'H':
                    return 8;
                default:
                    return -1;
            }
        }
    }
}
