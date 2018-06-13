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
        public List<Grade> gList;
        public List<School> sList;
        public LinqBaseData()
        {
            #region 基础数据

            List<Scores> list = new List<Scores>();
            Scores s1 = new Scores(1, "语文", 11);
            list.Add(s1);
            Scores s2 = new Scores(2, "数学", 12);
            list.Add(s2);
            Scores s3 = new Scores(3, "英语", 13);
            list.Add(s3);

            List<Scores> list1 = new List<Scores>();
            Scores q1 = new Scores(1, "语文", 21);
            list1.Add(q1);
            Scores q2 = new Scores(2, "数学", 22);
            list1.Add(q2);
            Scores q3 = new Scores(3, "英语", 23);
            list1.Add(q3);

            List<Scores> list2 = new List<Scores>();
            Scores w1 = new Scores(1, "语文", 31);
            list2.Add(w1);
            Scores w2 = new Scores(2, "数学", 32);
            list2.Add(w2);
            Scores w3 = new Scores(3, "体育", 33);
            list2.Add(w3);


            List<Scores> list3 = new List<Scores>();
            Scores e1 = new Scores(1, "语文", 41);
            list3.Add(e1);
            Scores e2 = new Scores(2, "数学", 42);
            list3.Add(e2);
            Scores e3 = new Scores(3, "物理", 43);
            list3.Add(e3);

            sList = new List<School>();
            School sh1 = new School();
            sh1.id = 1;
            sh1.sName = "女子学校";
            sList.Add(sh1);
            School sh2 = new School();
            sh2.id = 2;
            sh2.sName = "男足小学";
            sList.Add(sh2);
            School sh3 = new School();
            sh3.id = 3;
            sh3.sName = "师范学校";
            sList.Add(sh3);

            gList = new List<Grade>();
            Grade g1 = new Grade();
            g1.id = 1;
            g1.gName = "一年级";
            gList.Add(g1);
            Grade g2 = new Grade();
            g2.id = 2;
            g2.gName = "二年级";
            gList.Add(g2);

            stl = new List<Student>();
            Student stu = new Student();
            stu.id = 1;
            stu.name = "aa,a1";
            stu.remark = "中国";
            stu.scores = list;
            stu.SchName = sh1;
            stu.gId = 2;
            stl.Add(stu);

            stu = new Student();
            stu.id = 2;
            stu.name = "ab,b2";
            stu.remark = "中国";
            stu.scores = list1;
            stu.SchName = sh2;
            stu.gId = null;
            stl.Add(stu);

            stu = new Student();
            stu.id = 3;
            stu.name = "ba,c3";
            stu.remark = "中国";
            stu.scores = list2;
            //stu.SchName = sh1;
            stu.gId = 2;
            stl.Add(stu);

            stu = new Student();
            stu.id = 4;
            stu.name = "bb,c4";
            stu.remark = "日本";
            stu.scores = list3;
            stu.SchName = sh2;
            stu.gId = 1;
            stl.Add(stu);

            stu = new Student();
            stu.id = 5;
            stu.name = "bb,c5";
            stu.remark = "韩国";
            stu.scores = list3;
            stu.SchName = null;
            stu.gId = 5;
            stl.Add(stu);


            #endregion
        }
    }
}
