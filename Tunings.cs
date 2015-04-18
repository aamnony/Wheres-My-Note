using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wheres_My_Note
{
    class Tunings
    {
        public static int[] Tune(int index)
        {
            int[] tuning = {0,0,0,0,0,0};
            switch (index)
            {
                    //standard
                case 0: tuning[0] = 405;
                        tuning[1] = 312;
                        tuning[2] = 308;
                        tuning[3] = 303;
                        tuning[4] = 210;
                        tuning[5] = 205;
                        break;
                    //drop d
                case 1: tuning[0] = 405;
                        tuning[1] = 312;
                        tuning[2] = 308;
                        tuning[3] = 303;
                        tuning[4] = 210;
                        tuning[5] = 203;
                        break;
                    //half step down
                case 2: tuning[0] = 404;
                        tuning[1] = 311;
                        tuning[2] = 307;
                        tuning[3] = 302;
                        tuning[4] = 209;
                        tuning[5] = 204;
                        break;
                   //full step down
                case 3: tuning[0] = 403;
                        tuning[1] = 310;
                        tuning[2] = 306;
                        tuning[3] = 301;
                        tuning[4] = 208;
                        tuning[5] = 203;
                        break;
                    //DADGAD
                case 4: tuning[0] = 403;
                        tuning[1] = 310;
                        tuning[2] = 308;
                        tuning[3] = 303;
                        tuning[4] = 210;
                        tuning[5] = 203;
                        break;
                    //open D
                case 5: tuning[0] = 403;
                        tuning[1] = 310;
                        tuning[2] = 307;
                        tuning[3] = 303;
                        tuning[4] = 210;
                        tuning[5] = 203;
                        break;
                    //open G
                case 6: tuning[0] = 403;
                        tuning[1] = 312;
                        tuning[2] = 308;
                        tuning[3] = 303;
                        tuning[4] = 208;
                        tuning[5] = 203;
                        break;
                    //open C
                case 7: tuning[0] = 405;
                        tuning[1] = 401;
                        tuning[2] = 308;
                        tuning[3] = 301;
                        tuning[4] = 208;
                        tuning[5] = 201;
                        break;
                    //standard
                default: tuning[0] = 405;
                         tuning[1] = 312;
                         tuning[2] = 308;
                         tuning[3] = 303;
                         tuning[4] = 210;
                         tuning[5] = 205;
                         break;
           }
           return tuning;
       }
    }
}
