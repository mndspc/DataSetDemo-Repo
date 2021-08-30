using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace DataSetDemo
{
    //  This program demo. how to export data from DataSet to XML file
    class Program
    {
        #region Database Objects
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSetDemo.Settings1.ConStr"].ConnectionString);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        DataSet dataSet = new DataSet("EmployeeData");
        #endregion
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.SaveAsXML();
            //program.GetXMLData();
            program.ReadXMLIntoDataSet();
            Console.ReadLine();
        }

        public void SaveAsXML()
        {
            //  How to SaveAs XML using WriteXML method
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "Select * from EmpMaster";
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet, "EmpMaster");
                //  This method export dataset into XML
                dataSet.WriteXml("EmpMaster.xml");
                Console.WriteLine("Employee Data has been saved into XML file");
            }
            catch (Exception ex)
            {

            }
        }

        public void GetXMLData()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "Select * from EmpMaster";
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet, "EmpMaster");
                //  This method export dataset into XML
               var xmlData= dataSet.GetXml();
                var xmlSchema = dataSet.GetXmlSchema();
                Console.WriteLine(xmlData);
                Console.WriteLine(xmlSchema);
            }
            catch (Exception ex)
            {

            }
        }

        public void ReadXMLIntoDataSet()
        {
            try
            {
                dataSet.ReadXml("EmpMaster.xml", XmlReadMode.Auto);
                var xmlData = dataSet.GetXml();
                Console.WriteLine(xmlData);
                
            }catch(Exception ex)
            {

            }
        }
    }
}
