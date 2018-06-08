using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp.Linq
{
    public class LinqExample : LinqBaseData
    {

        public void LinqConsole()
        {
            exmple();



        }
        public void exmple()
        {
            // https:// code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b
            #region Projection Operators

            // index
            var ex1 = arrNum.Where((d, index) => d.Length < index);
            //foreach (var p in ex1)
            //    Console.WriteLine(p);


            // select-transformation 选择转化
            var ex2 = from n in numbers
                      select arrNum[n];
            //foreach (var p in ex2)
            //    Console.WriteLine(p);


            // select-Anonymous types 匿名类型
            var ex3 = from n in numbers
                      select new { d = arrNum[n], even = (n % 2 == 0) };
            //foreach (var p in ex3)
            //    Console.WriteLine(p.d + " " + p.even);


            // select - indexed
            var ex4 = numbers.Select((n, index) => new { num = n, inPlace = (n == index) });
            //foreach (var p in ex4)
            //    Console.WriteLine(p.num + " " + p.inPlace);


            // selectMany- compound from 1
            var ex5 =
                   from a in numbers
                   from b in numbers1
                   where a < b
                   select new { a, b };
            //foreach (var p in ex5)
            //    Console.WriteLine(p.a + " " + p.b);

            var ex6 =
              from a in numbers
              from b in numbers1
              where a < 2
              select new { a, b };
            //foreach (var p in ex6)
            //    Console.WriteLine(p.a + " " + p.b);


            // selectMany - indexed  "custindex " +  custindex + " score " +
            var ext7 = stl.SelectMany((cust, custindex) => cust.scores.Select(o => custindex + "  " + o.id + "  " + o.scoresName + "  " + o.score));

            //foreach (var p in ext7)
            //    Console.WriteLine(p);

            //int i = 0;
            //foreach (Student s in stl)
            //{

            //    foreach (Scores t in s.Scores)
            //    {

            //        Console.WriteLine( "  " + i + "  " + t.id + "  " + t.ScoresName + "  " + t.score);
            //    }
            //    i++;
            //}

            #endregion


            #region Partitioning Operators

            // Take 采取
            // 获取数组前三个元素
            var ex21 = numbers.Take(3);
            // foreach(var n in ex21)
            // Console.WriteLine(n);

            // Skip 跳过 
            // 跳过前5个
            var ex22 = numbers.Skip(5);

            // TakeWhile，获取小于6的
            //获取， 依次获取小于6的,大于6的停止循环获取
            var ex23 = numbers.TakeWhile(n => n < 6);
            // foreach (var n in ex23)
            // Console.WriteLine(n);


            // 5, 4, 1, 3, 9, 8, 6, 7, 2, 0
            // 0, 1, 2, 3, 4, 5, 6, 7, 8, 9

            var ex24 = numbers.TakeWhile((n, index) => n >= index);
            //foreach (var n in ex24)
            //    Console.WriteLine(n);


            //跳过， 获取第一个大于6后面的所有序列
            var ex25 = numbers.SkipWhile(n => n < 6);
            //foreach (var n in ex25)
            //Console.WriteLine(n);

            // 5, 4, 1, 3, 9, 8, 6, 7, 2, 0
            // 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
            var ex26 = numbers.SkipWhile((n, index) => n >= index);
            //foreach (var n in ex25)
            //Console.WriteLine(n);

            #endregion

            #region Ordering Operators

            // OrderBy - Comparer
            // 此示例使用一个带有自定义比较器的OrderBy子句，对数组中的单词进行区分大小写的排序
            var ex27 = arrNum.OrderBy(a => a, new CaseInsensitiveComparer());
            //foreach (var n in ex27)
            //    Console.WriteLine(n);


            // ThenBy 组合排序
            var ex28 = from d in arrNum
                       orderby d.Length, d
                       select d;
            //foreach (var n in ex28)
            //    Console.WriteLine(n);


            var ex29 = arrNum.OrderBy(a => a.Length)
                             .ThenBy(a => a, new CaseInsensitiveComparer());
            var ex291 = arrNum.OrderBy(a => a.Length)
                                .ThenBy(a => a);
            //foreach (var n in ex29)
            //    Console.WriteLine(n);


            // Reverse 相反
            var ex30 = (from d in arrNum
                        where d[1] == 'i'
                        select d)
                         .Reverse();
            //foreach (var n in ex30)
            //    Console.WriteLine(n);






            #endregion

            #region Grouping Operators

            string[] anagrams = { "from", "salt", "earn", "last", "near", "form", "ormf" };
            var ex31 = anagrams.GroupBy(w => w.Trim(), new AnagramEqualityComparer());
            //foreach (var p in ex31)
            //  Console.WriteLine(p);
            #endregion

            #region Set Operators

            // Union 并集
            var ex32 = numbers.Union(numbers1);
            //Intersect 交集
            var ex33 = numbers.Intersect(numbers1);
            //Except 除了,非交集
            var ex34 = numbers1.Except(numbers);
            //foreach (var p in ex34)
            //    Console.WriteLine(p);

            #endregion

            #region Conversion Operators
            object[] test35 = { null, 2.1, "two", "4our", 1, 2 };

            var ex35 = test35.OfType<int>();
            //foreach (var p in ex35)
            //    Console.WriteLine(p);

            #endregion

            #region  Element Operators 

            /// Element Operators
            int ex36 = (from n in numbers
                        where n >= 5
                        select n).ElementAt(1);

            //Console.WriteLine(ex36);


            /// Generation Operators

            // range(10.20) 生成10后面的20个数字
            var ex37 = from n in Enumerable.Range(10, 20)
                       select n;
            //foreach (var p in ex37)
            //    Console.WriteLine(p);
            // repeat(3,10) 生成3 重复十次

            /// Quantifiers
            bool ex38 = arrNum.Any(n => n.Contains("one"));
            //Console.WriteLine(ex38);
            var ex39 = from s in stl
                       group s by s.remark into g
                       where g.Any(p => p.id > 1)
                       select new { ke = g.Key, stu = g };
            //foreach (var p in ex39)
            //    Console.WriteLine(p.ke + " " + p.stu.Count());

            // All 确定所有元素是否满足条件
            int[] test40 = { 1, 11, 21 };
            var ex40 = test40.All(n => n % 2 == 1);
            //Console.WriteLine(ex40);
            #endregion

            #region Aggregate Operators
            var ex41 = numbers.Count(n => n % 2 == 1);
            var ex42 = numbers.Count(n => n > 3);
            // Console.WriteLine(ex42);

            var ex43 = from p in stl
                       select new { p.name, socreCnt = p.scores.Count() };
            //foreach (var p in ex43)
            //    Console.WriteLine(p.name+" "+p.socreCnt);

            // SUM MIN MAX AVERAGE

            // Aggregate  
            // cutNumAccum 累积值
            double[] test44 = { 2, 3, 4, 3, 1 };
            var ex44 = test44.Aggregate((cutNumAccum, nextNum) => cutNumAccum * nextNum);
            //Console.WriteLine(ex44);

            double test45 = 100;
            var ex45 = test44.Aggregate(test45,
                    (cutNumAccum, nextNum) =>
                            ((nextNum <= cutNumAccum) ? (cutNumAccum - nextNum) : test45));
            //Console.WriteLine(ex45);


            #endregion

            #region Miscellaneous Operators

            // concat 连接两个字符串
            var ex46 = numbers.Concat(numbers1);
            //foreach (var p in ex46)
            //    Console.WriteLine(p);

            // SequenceEqual 序列相等
            var ex47 = numbers.SequenceEqual(numbers1);
            //Console.WriteLine(ex47);



            #endregion

            #region Custom Sequence Operators

            // concat 连接两个字符串
            // var ex46 = numbers.Concat(numbers1);
            //foreach (var p in ex46)
            //    Console.WriteLine(p);





            #endregion

        }

        public void study()
        {
            // group 
            var group = from l in stl

                        group l by l.name[0] into g

                        orderby g.Key
                        select g;

            // let 
            var let = from l in stl
                      let frt = l.name.Split(",")[1]
                      select frt;

            // lookup
            var quert = stl.ToLookup(n => n.id);
        }
    }

    public static class CustomSequenceOperators
    {
        //public static IEnumerable Combine(this IEnumerable first, IEnumerable second, Func func)
        //{
        //    using (IEnumerator)

        //}
    }



    public class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        }
    }

    public class AnagramEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return getCanonicalString(x) == getCanonicalString(y);
        }
        public int GetHashCode(string obj)
        {
            return getCanonicalString(obj).GetHashCode();
        }

        public string getCanonicalString(string word)
        {
            char[] wordChars = word.ToCharArray();
            Array.Sort<char>(wordChars);
            return new string(wordChars);
        }

    }

}
