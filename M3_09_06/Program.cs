using System.Collections.Generic;

namespace M3_09_06;

class Program
{
    public enum RectColor
    {
        red, blue, yellow, white, pink
    }

    static void Main(string[] args)
    {
        //Use dictionary to map a List of somthing to a key
        Dictionary<string, List<string>> FavoriteBands = new Dictionary<string, List<string>>();

        FavoriteBands.Add("ACDC", new List<string>() { "Fly on the Wall", "TnT", "For those about to Rock" });
        FavoriteBands.Add("PinkFloyd", new List<string>() { "Dark side of the moon", "The Wall", "Final Cut" });
        FavoriteBands.Add("Bob Dylan", new List<string>() { "Infidels" });

        Console.WriteLine(FavoriteBands.ContainsKey("Abba"));
        foreach (var performer in FavoriteBands.Keys)
        {
            Console.WriteLine($"\n{performer} albums:");
            foreach (var album in FavoriteBands[performer])
            {
                Console.WriteLine(album);
            }
        }

        //Use Dictionary to map a key to the nr occurances in a list
        //HashSet<T>
        List<RectColor> list = new List<RectColor>() { RectColor.red, RectColor.yellow, RectColor.red, RectColor.blue,
            RectColor.white, RectColor.pink, RectColor.red, RectColor.white };

        //Check number of occurnaces in the list
        Dictionary<RectColor, int> occurances = new Dictionary<RectColor, int>();
        foreach (var item in list)
        {
            //try to see if it can be added, only the first time works
            if (!occurances.TryAdd(item, 1))
            {
                //already exists, simply imcrement the value
                occurances[item]++;
            }
        }

        //print out the number of occurances
        Console.WriteLine();
        foreach (var item in occurances.Keys)
        {
            Console.WriteLine($"{item}: {occurances[item]} times");
        }
    }
}

