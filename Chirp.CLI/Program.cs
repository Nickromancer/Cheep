using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    public static void Main()
    {
    using (StreamReader reader = new StreamReader("chirp_cli_db.csv"))
        {
            string line;

            while ((line = reader.ReadLine()!) != null)
            {
                //Define pattern
                //^(\w{4}|\w{5}),""(.*)"",(\d*)
                string pattern = @"^(\w{4}|\w{5}),""(.*?)"",(\d*)";

                foreach (Match match in Regex.Matches(line, pattern))
                /* Do something with X */
/*                 TimestampToDate(int.Parse(match.Groups[2].Value)); */
                    Console.WriteLine("{0} @ {2}: {1}",
                        match.Groups[1].Value, match.Groups[2].Value, TimestampToDate(int.Parse(match.Groups[3].Value)));

            }
        }
    }
    public static string TimestampToDate(int timestmp) {
        DateTime dat_Time = new DateTime(1965, 1, 1, 0, 0, 0, 0);
        dat_Time = dat_Time.AddSeconds(timestmp);
        string print_the_Date = dat_Time.ToShortDateString() +" "+ dat_Time.ToLongTimeString();
        return print_the_Date;
    }
}