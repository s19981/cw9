using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace LinqConsoleApp
{
    public class LinqSamples
    {
        public static IEnumerable<Emp> Emps { get; set; }
        public static IEnumerable<Dept> Depts { get; set; }
        public static IEnumerable<LikeDept> LikeDepts { get; set; }

        public LinqSamples()
        {
            LoadData();
            Console.WriteLine("Przyklad 1");
            Przyklad1();
            Console.WriteLine();
            Console.WriteLine("Przyklad 2");
            Przyklad2();
            Console.WriteLine();
            Console.WriteLine("Przyklad 3");
            Przyklad3();
            Console.WriteLine();
            Console.WriteLine("Przyklad 4");
            Przyklad4();
            Console.WriteLine();
            Console.WriteLine("Przyklad 5");
            Przyklad5();
            Console.WriteLine();
            Console.WriteLine("Przyklad 6");
            Przyklad6();
            Console.WriteLine();
            Console.WriteLine("Przyklad 7");
            Przyklad7();
            Console.WriteLine();
            Console.WriteLine("Przyklad 8");
            Przyklad8();
            Console.WriteLine();
            Console.WriteLine("Przyklad 9");
            Przyklad9();
            Console.WriteLine();
            Console.WriteLine("Przyklad 10");
            Przyklad10Button_Click();
            Console.WriteLine();
            Console.WriteLine("Przyklad 11");
            Przyklad11();
            Console.WriteLine();
            Console.WriteLine("Przyklad 12");
            Przyklad12();

        }

        public void LoadData()
        {
            var empsCol = new List<Emp>();
            var deptsCol = new List<Dept>();
            var likeDeptsCol = new List<LikeDept>();

            #region Load depts
            var d1 = new Dept
            {
                Deptno = 1,
                Dname = "Research",
                Loc = "Warsaw"
            };

            var d2 = new Dept
            {
                Deptno = 2,
                Dname = "Human Resources",
                Loc = "New York"
            };

            var d3 = new Dept
            {
                Deptno = 3,
                Dname = "IT",
                Loc = "Los Angeles"
            };

            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            Depts = deptsCol;
            #endregion

            #region Load emps
            var e1 = new Emp
            {
                Deptno = 1,
                Empno = 1,
                Ename = "Jan Kowalski",
                HireDate = DateTime.Now.AddMonths(-5),
                Job = "Backend programmer",
                Mgr = null,
                Salary = 2000
            };

            var e2 = new Emp
            {
                Deptno = 1,
                Empno = 20,
                Ename = "Anna Malewska",
                HireDate = DateTime.Now.AddMonths(-7),
                Job = "Frontend programmer",
                Mgr = e1,
                Salary = 4000
            };

            var e3 = new Emp
            {
                Deptno = 1,
                Empno = 2,
                Ename = "Marcin Korewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Frontend programmer",
                Mgr = null,
                Salary = 5000
            };

            var e4 = new Emp
            {
                Deptno = 2,
                Empno = 3,
                Ename = "Paweł Latowski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Frontend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e5 = new Emp
            {
                Deptno = 2,
                Empno = 4,
                Ename = "Michał Kowalski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Backend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e6 = new Emp
            {
                Deptno = 2,
                Empno = 5,
                Ename = "Katarzyna Malewska",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Manager",
                Mgr = null,
                Salary = 8000
            };

            var e7 = new Emp
            {
                Deptno = null,
                Empno = 6,
                Ename = "Andrzej Kwiatkowski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "System administrator",
                Mgr = null,
                Salary = 7500
            };

            var e8 = new Emp
            {
                Deptno = 2,
                Empno = 7,
                Ename = "Marcin Polewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Mobile developer",
                Mgr = null,
                Salary = 4000
            };

            var e9 = new Emp
            {
                Deptno = 2,
                Empno = 8,
                Ename = "Władysław Torzewski",
                HireDate = DateTime.Now.AddMonths(-9),
                Job = "CTO",
                Mgr = null,
                Salary = 12000
            };

            var e10 = new Emp
            {
                Deptno = 2,
                Empno = 9,
                Ename = "Andrzej Dalewski",
                HireDate = DateTime.Now.AddMonths(-4),
                Job = "Database administrator",
                Mgr = null,
                Salary = 9000
            };

            empsCol.Add(e1);
            empsCol.Add(e2);
            empsCol.Add(e3);
            empsCol.Add(e4);
            empsCol.Add(e5);
            empsCol.Add(e6);
            empsCol.Add(e7);
            empsCol.Add(e8);
            empsCol.Add(e9);
            empsCol.Add(e10);
            Emps = empsCol;

            #endregion

            #region Load likeDepts
            var ld1 = new LikeDept { Employee = e1, Depts = new List<Dept> { d1, d2 } };
            var ld2 = new LikeDept { Employee = e2, Depts = new List<Dept> { d3 } };
            var ld3 = new LikeDept { Employee = e3, Depts = new List<Dept> { d1, d2, d3 } };
            var ld4 = new LikeDept { Employee = e4, Depts = new List<Dept> { d2, d3 } };

            likeDeptsCol.Add(ld1);
            likeDeptsCol.Add(ld2);
            likeDeptsCol.Add(ld3);
            likeDeptsCol.Add(ld4);

            LikeDepts = likeDeptsCol;
            #endregion

        }


        /*
            Celem ćwiczenia jest uzupełnienie poniższych metod.
         *  Każda metoda powinna zawierać kod C#, który z pomocą LINQ'a będzie realizować
         *  zapytania opisane za pomocą SQL'a.
         *  Rezultat zapytania powinien zostać wyświetlony za pomocą kontrolki DataGrid.
         *  W tym celu końcowy wynik należy rzutować do Listy (metoda ToList()).
         *  Jeśli dane zapytanie zwraca pojedynczy wynik możemy je wyświetlić w kontrolce
         *  TextBox WynikTextBox.
        */

        /// <summary>
        /// SELECT * FROM Emps WHERE Job = "Backend programmer";
        /// </summary>
        public void Przyklad1()
        {
            //var res = new List<Emp>();
            //foreach(var emp in Emps)
            //{
            //    if (emp.Job == "Backend programmer") res.Add(emp);
            //}

            //1. Query syntax (SQL)
            var res = from emp in Emps
                      where emp.Job == "Backend programmer"
                      select new
                      {
                          Nazwisko = emp.Ename,
                          Zawod = emp.Job
                      };

            var res2 = Emps
                .Where(emp => emp.Job == "Backend programmer")
                .Select(emp => new
                    {
                        Nazwisko = emp.Ename,
                        Zawod = emp.Job
                    });

            foreach (var i in res2)
            {
                Console.WriteLine(i.Nazwisko + " " + i.Zawod);
            }

            //2. Lambda and Extension methods
        }

        /// <summary>
        /// SELECT * FROM Emps Job = "Frontend programmer" AND Salary>1000 ORDER BY Ename DESC;
        /// </summary>
        public void Przyklad2()
        {
            
            var res = from emp in Emps
                      where emp.Job == "Frontend programmer" && emp.Salary > 1000
                      orderby emp.Ename descending
                      select emp;


            var res2 = Emps.Where(emp => emp.Job == "Frontend programmer" && emp.Salary > 1000).OrderBy(emp => emp.Ename);

            foreach (var i in res2)
            {
                Console.WriteLine(i.Ename + " " + i.Job + " " + i.Salary);
            }

        }

        /// <summary>
        /// SELECT MAX(Salary) FROM Emps;
        /// </summary>
        public void Przyklad3()
        {
            var res = Emps.Max(emp => emp.Salary);
            Console.WriteLine(res);
        }

        /// <summary>
        /// SELECT * FROM Emps WHERE Salary=(SELECT MAX(Salary) FROM Emps);
        /// </summary>
        public void Przyklad4()
        {
            var res = Emps.Where(emp => emp.Salary == Emps.Max(emp => emp.Salary));

            foreach (var i in res)
            {
                Console.WriteLine(i.Ename + " " + i.Job + " " + i.Salary);
            }
        }

        /// <summary>
        /// SELECT ename AS Nazwisko, job AS Praca FROM Emps;
        /// </summary>
        public void Przyklad5()
        {
            var res = Emps.Select(emp => new
                {
                    Nazwisko = emp.Ename,
                    Praca = emp.Job
                });

            foreach (var i in res)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// SELECT Emps.Ename, Emps.Job, Depts.Dname FROM Emps
        /// INNER JOIN Depts ON Emps.Deptno=Depts.Deptno
        /// Rezultat: Złączenie kolekcji Emps i Depts.
        /// </summary>
        public void Przyklad6()
        {
            var res = Emps.Join(Depts, emp => emp.Deptno, dept => dept.Deptno, (emp, dept) => new {emp.Ename, emp.Job, dept.Dname} );

            foreach (var i in res)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// SELECT Job AS Praca, COUNT(1) LiczbaPracownikow FROM Emps GROUP BY Job;
        /// </summary>
        public void Przyklad7()
        {
            var res = Emps.GroupBy(emp => emp.Job).Select(group => new
            {
                Job = group.Key,
                Count = group.Count()
            });

            foreach (var i in res)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// Zwróć wartość "true" jeśli choć jeden
        /// z elementów kolekcji pracuje jako "Backend programmer".
        /// </summary>
        public void Przyklad8()
        {
            var res = Emps.Any(emp => emp.Job == "Backend programmer");

            Console.WriteLine(res);
        }

        /// <summary>
        /// SELECT TOP 1 * FROM Emp WHERE Job="Frontend programmer"
        /// ORDER BY HireDate DESC;
        /// </summary>
        public void Przyklad9()
        {
            var res = Emps.Select(emp => new
            {
                emp.Ename,
                emp.Job,
                emp.HireDate
            }).OrderByDescending(emp => emp.HireDate).First(emp => emp.Job == "Frontend programmer");

            Console.WriteLine(res);
        }

        /// <summary>
        /// SELECT Ename, Job, Hiredate FROM Emps
        /// UNION
        /// SELECT "Brak wartości", null, null;
        /// </summary>
        public void Przyklad10Button_Click()
        {
            var res = Emps.Select(emp => new
            {
                emp.Ename,
                emp.Job,
                emp.HireDate
            });

            foreach (var i in res)
            {
                Console.WriteLine(i);
            }
        }

        //Znajdź pracownika z najwyższą pensją wykorzystując metodę Aggregate()
        public void Przyklad11()
        {
            var res = Emps.Aggregate((res, next) => next.Salary > res.Salary ? next : res);
            Console.WriteLine(res.Ename + " " + res.Salary);
        }

        //Z pomocą języka LINQ i metody SelectMany wykonaj złączenie
        //typu CROSS JOIN
        
        public void Przyklad12()
        {

            var res = LikeDepts.SelectMany(lD => lD.Depts, (emp, dname) => new
            {
                emp.Employee.Ename,
                dname.Dname
            });
            foreach (var i in res)
            {
                Console.WriteLine(i);
            }
        }
    }
}
