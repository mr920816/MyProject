using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Linq
{
    public class LinqBaseData
    {
        public int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        public int[] numbers1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 11, 12, 13 };

        public string[] arrNum = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };


        public List<Student> stl;

        public LinqBaseData()
        {
            #region 基础数据

            List<Scores> list = new List<Scores>();
            Scores s1 = new Scores(1, "语文", 11);
            list.Add(s1);
            Scores s2 = new Scores(2, "英语", 12);
            list.Add(s2);
            Scores s3 = new Scores(3, "数学", 13);
            list.Add(s3);

            List<Scores> list1 = new List<Scores>();
            Scores q1 = new Scores(1, "语文", 21);
            list1.Add(q1);
            Scores q2 = new Scores(2, "英语", 22);
            list1.Add(q2);
            Scores q3 = new Scores(3, "数学", 23);
            list1.Add(q3);

            List<Scores> list2 = new List<Scores>();
            Scores w1 = new Scores(1, "语文", 31);
            list2.Add(w1);
            Scores w2 = new Scores(2, "英语", 32);
            list2.Add(w2);
            Scores w3 = new Scores(3, "数学", 33);
            list2.Add(w3);


            List<Scores> list3 = new List<Scores>();
            Scores e1 = new Scores(1, "语文", 41);
            list3.Add(e1);
            Scores e2 = new Scores(2, "英语", 42);
            list3.Add(e2);
            Scores e3 = new Scores(3, "数学", 43);
            list3.Add(e3);


            stl = new List<Student>();
            Student stu = new Student();
            stu.id = 1;
            stu.name = "aa,a";
            stu.remark = "中国";
            stu.scores = list;
            stl.Add(stu);

            stu = new Student();
            stu.id = 2;
            stu.name = "ab,b";
            stu.remark = "中国";

            stu.scores = list1;
            stl.Add(stu);

            stu = new Student();
            stu.id = 3;
            stu.name = "ba,c";
            stu.remark = "中国";
            stu.scores = list2;
            stl.Add(stu);

            stu = new Student();
            stu.id = 4;
            stu.name = "bb,c";
            stu.remark = "日本";
            stu.scores = list3;
            stl.Add(stu);

            #endregion
        }
    }
}
