using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DataSetDemo
{
    class LoadCollectionToDS
    {
        DataSet dataSet = new DataSet();
        static void Main()
        {
            List<Student> students = new List<Student>
            {
                new Student{StdRollNo=100,StdName="Scott",Email="scott@gmail.com" },
                new Student{StdRollNo=101,StdName="Smith",Email="smith@gmail.com"  },
                new Student{ StdRollNo=102,StdName="Tiger",Email="tiger@gmail.com" }
            };

            List<Employee> employees = new List<Employee>
            {
                new Employee{EmpCode=100,EmpName="Jhones",Email="jhones@jkt.com" },
                 new Employee{EmpCode=101,EmpName="mark",Email="mark@jkt.com" },
                  new Employee{EmpCode=102,EmpName="marry",Email="marry@jkt.com" }
            };
            LoadCollectionToDS loadCollectionToDS = new LoadCollectionToDS();
            loadCollectionToDS.CreateSchema();
            loadCollectionToDS.AddSudentData(students);
            loadCollectionToDS.AddEmployeeData(employees);
            loadCollectionToDS.PrintDataSet();
            Console.ReadLine();
        }

        
        public void CreateSchema()
        {
           
            //  Data Tables to hold Collections data
            DataTable dtStudent = new DataTable("StdProfile");
            DataTable dtEmployee = new DataTable("EmpProfile");
            //  To create DataColumns for StdProfile
            DataColumn dcStdRollNo = new DataColumn("StdRollNo", typeof(int));
            DataColumn dcStdName = new DataColumn("StdName", typeof(string));
            DataColumn dcStdEmail = new DataColumn("Email", typeof(string));
            dtStudent.Columns.Add(dcStdRollNo);
            dtStudent.Columns.Add(dcStdName);
            dtStudent.Columns.Add(dcStdEmail);
            DataColumn[] primarykeys = { dcStdRollNo };
            dtStudent.PrimaryKey = primarykeys;
            dataSet.Tables.Add(dtStudent);

            //To create DataColumn for EmpProfile
            DataColumn dcEmpCode = new DataColumn("EmpCode", typeof(int));
            DataColumn dcEmpName = new DataColumn("EmpName", typeof(string));
            DataColumn dcEmail = new DataColumn("Email", typeof(string));

            dtEmployee.Columns.Add(dcEmpCode);
            dtEmployee.Columns.Add(dcEmpName);
            dtEmployee.Columns.Add(dcEmail);

            dataSet.Tables.Add(dtEmployee);
        }

        public void AddSudentData(List<Student> list)
        {
            foreach(var std in list)
            {
               DataRow dataRow= dataSet.Tables["StdProfile"].NewRow();
                dataRow["StdRollNo"] = Convert.ToInt32(std.StdRollNo);
                dataRow["StdName"] = Convert.ToString(std.StdName);
                dataRow["Email"] = Convert.ToString(std.Email);
                dataSet.Tables["StdProfile"].Rows.Add(dataRow);
            }
        }
        public void AddEmployeeData(List<Employee> list)
        {
            foreach (var emp in list)
            {
                DataRow dataRow = dataSet.Tables["EmpProfile"].NewRow();
                dataRow["EmpCode"] = Convert.ToInt32(emp.EmpCode);
                dataRow["EmpName"] = Convert.ToString(emp.EmpName);
                dataRow["Email"] = Convert.ToString(emp.Email);
                dataSet.Tables["EmpProfile"].Rows.Add(dataRow);
            }
        }

        public void PrintDataSet()
        {
            var data = dataSet.GetXml();
            Console.WriteLine(data);
        }
    }
}
