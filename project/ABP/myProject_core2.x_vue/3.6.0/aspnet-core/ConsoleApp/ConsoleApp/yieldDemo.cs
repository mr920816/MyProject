using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class yieldDemo
    {
        //IEnumerable<int> GetSingleDigitNumbers()
        //{
        //    int index = 0;
        //    while (index++ < 10)
        //        yield return index;
        //}






    }

    public class DaysOfTheWeek : IEnumerable
    {
        string[] m_days = { "Sum","Mon","Tue","Wed","Thr","Fri","Sat" };
        public IEnumerator GetEnumerator()
        {
            for (int i =0; i< m_days.Length; i++)
            {
                yield return m_days[i];
            }
        }
    }
}
