using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DataSetDemo
{
    //  This program demo. how to create DataSet and DataTable from scratch
    class DSDemo
    {
        static void Main()
        {
            //  DataSet to hold DataTables
            DataSet dsStudentInfo = new DataSet("StudentInfo");
            //  DataTable to hold DataColumns and DataRows
            DataTable dtStdProfile = new DataTable("StdProfile");
            DataColumn dcStdRollNo = new DataColumn("StdRollNo",typeof(int));
            DataColumn dcStdName = new DataColumn("StdName", typeof(string));
            DataColumn dcEmail = new DataColumn("Email", typeof(string));
            //To add DataColumns into DataTable
            dtStdProfile.Columns.Add(dcStdRollNo);
            dtStdProfile.Columns.Add(dcStdName);
            dtStdProfile.Columns.Add(dcEmail);
            //  To add primary key constraint to DataTable
            DataColumn[] primaryKeyColumns = { dcStdRollNo };
            dtStdProfile.PrimaryKey = primaryKeyColumns;

            //  To Add DataTable into DataSet
            dsStudentInfo.Tables.Add(dtStdProfile);
            //  To print schema of all DataTables belogs to current dataset
            Console.WriteLine(dsStudentInfo.GetXmlSchema());

            //To create DataRows
            DataRow dataRow1 = dtStdProfile.NewRow();
            dataRow1["StdRollNo"] = 100;
            dataRow1["StdName"] = "Scott";
            dataRow1["Email"] = "scott@gmail.com";
            //  To add datarow into DataTable
            dtStdProfile.Rows.Add(dataRow1);

            DataRow dataRow2 = dtStdProfile.NewRow();
            dataRow2["StdRollNo"] = 101;
            dataRow2["StdName"] = "Smith";
            dataRow2["Email"] = "smith@gmail.com";

            //  To add datarow into DataTable
           
            dtStdProfile.Rows.Add(dataRow2);

            foreach (DataRow dataRow in dtStdProfile.Rows)
            {
                Console.WriteLine("RollNo={0}\tName={1}\tEmail={2}",dataRow["StdRollNo"],dataRow["StdName"],dataRow["Email"]);
            }
            Console.ReadLine();
        }
    }
}
