﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool Weight) : base(name, Weight)
        {
            Type = Enums.GradeBookType.Ranked;
        }


        public override char GetLetterGrade(double averageGrade)
        {
            int totStu = Students.Count;

            if (totStu < 5) {
                throw new InvalidOperationException();
            }

            List<double> classTotal = new List<double>();

            foreach (Student stu in Students) {
                classTotal.Add(stu.AverageGrade);
            }
            classTotal.Sort();

            //double per20 = Math.Round(totStu * 0.2, 0);
            int per20 = totStu / 5;
            int stuNum = 0;

            foreach (double currGrade in classTotal)
            {
                if (currGrade > averageGrade)
                {
                    break;
                }
                stuNum = stuNum + 1;
            }

            if (stuNum > (totStu-per20))
            {
                return 'A';
            }
            else if ((totStu-per20) >= stuNum && stuNum > (totStu-per20*2))
            {
                return 'B';
            }
            else if ((totStu - 2*per20) >= stuNum && stuNum > (totStu - per20 * 3))
            {
                return 'C';
            }
            else if ((totStu - 3*per20) >= stuNum && stuNum > (totStu - per20 * 4))
            {
                return 'D';
            }



            return 'F';
        }


        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();

        }

        public override void CalculateStudentStatistics(string name)
        {

            if (Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }

    }
}
