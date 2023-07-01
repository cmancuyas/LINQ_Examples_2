using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Examples_2._helper
{
    public class DataHelper
    {
        public static ArrayList GetHeterogenousDataCollection()
        {
            ArrayList arrayList = new ArrayList();

            arrayList.Add(100);
            arrayList.Add("Sio Jeong");
            arrayList.Add(2000);
            arrayList.Add(3000);
            arrayList.Add("Aran Jeong");
            arrayList.Add(new Employee
            {
                Id = 6,
                FirstName = "Chris",
                LastName = "Mancuyas",
                AnnualSalary = 90000,
                IsManager = false,
                DepartmentId = 1,

            });
            arrayList.Add(new Employee
            {
                Id = 7,
                FirstName = "Yeji",
                LastName = "Hwang",
                AnnualSalary = 60000,
                IsManager = false,
                DepartmentId = 2,

            });
            arrayList.Add(new Employee
            {
                Id = 8,
                FirstName = "Ryujin",
                LastName = "Shin",
                AnnualSalary = 60000,
                IsManager = false,
                DepartmentId = 2,

            });

            arrayList.Add(new Department
            {
                Id = 4,
                ShortName = "MKT",
                LongName = "Marketing"
            });

            arrayList.Add(new Department
            {
                Id = 5,
                ShortName = "R&D",
                LongName = "Research and Development"
            });
            arrayList.Add(new Department
            {
                Id = 6,
                ShortName = "PRD",
                LongName = "Production"
            });

            return arrayList;
        }
    }
}
