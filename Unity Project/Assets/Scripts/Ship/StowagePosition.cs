using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


class StowagePosition
{
    int x;
    String first;
    String second;
    String third;
    int bay = 0;
    int row = 0;
    int tier = 0;
    public static int highestbay = 0;
    public static int highestrow = 0;
    public static int highesttier = 0;
    public static int count = 0;



    //bay=z, tier=y, row=x

    public int[] CalculatePosition(String position)
    {
        
        // Add number if string size is 5
        if (position.Count() == 5)
        {
            position = "0" + position;
        }
        // Check if number size is 6
        if (position.Count() == 6)
        {
            x = 0;

            //Seperate the whole number in bay/row/tier numbers
            MatchCollection mc = Regex.Matches(position, "(\\d\\d)");
            foreach (Match m in mc)
            {

                switch (x)
                {
                    case 0:
                        // Set bay number
                        first = m.ToString();
                        bay = Convert.ToInt16(first);
                        x++;
                        break;
                    case 1:
                        // Set row number
                        second = m.ToString();
                        row = Convert.ToInt16(second);
                        if (row % 2 == 0)
                        {
                            row = (row * -1) / 2;
                        }
                        else
                        {
                            row += 1;
                            row = row / 2;
                        }
                        x++;
                        break;
                    case 2:
                        // Set tier number
                        third = m.ToString();
                        tier = (Convert.ToInt16(third) / 2);
                        if (tier >= 41)
                        {
                            tier = tier - 41;
                        }
                        x++;
                        break;


                }


            }

            if (tier > highesttier)
            {
                highesttier = tier;
            }
            if (row > highestrow)
            {
                highestrow = row;
            }
            if (bay > highestbay)
            {
                highestbay = bay;
            }
        }
        int[] coords = new int[] { tier, row, bay };
        return coords;
    }
}
