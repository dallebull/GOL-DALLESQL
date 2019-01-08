using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GOL_DALLESQL.BLL
{
    public class HelperClass
    {
       public string RandomSeed()
        {
            long Seed = LongRandom(10000000000000000, 99999999999999999, new Random());
            long Seed1 = LongRandom(10000000000000000, 99999999999999999, new Random());
         
            var BinarySeed = Convert.ToString(Seed, 2);
            var BinarySeed1 = Convert.ToString(Seed1, 2);
            string BinarySpeed3 = string.Concat(BinarySeed1 + BinarySeed);

            BinarySeed = BinarySpeed3.Truncate(100);
            return BinarySeed;
        }

        long LongRandom(long min, long max, Random rand)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);
            return (Math.Abs(longRand % (max - min)) + min);
        }
        
  




    }
    

    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}