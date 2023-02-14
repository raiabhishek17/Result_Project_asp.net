webform1.aspx.cs

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Day1_Task1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        OleDbConnection Econ;
        SqlConnection con;

        string constr, Query, sqlconn;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        private void ExcelConn(string FilePath)
        {

            constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", FilePath);
            Econ = new OleDbConnection(constr);

        }

        private void connection()
        {
            sqlconn = ConfigurationManager.ConnectionStrings["SqlCom"].ConnectionString;
            con = new SqlConnection(sqlconn);

        }

        protected void UploadFile1(object sender, EventArgs e)
        { 
                String savePath = @"C:\Users\Abhishek Rai\OneDrive\Desktop\GTU Internship\Day-1_Learnings\Day1_Task1\Uploads\";
                if (FileUpload1.HasFile)
                {
                    // Append the name of the file to upload to the path.
                    savePath += FileUpload1.FileName;

                    FileUpload1.SaveAs(savePath);

                // Notify the user that the file was uploaded successfully.
                    lblResult.Text = "Your file was uploaded successfully.";

                }
                else
                {
                // Notify the user that a file was not uploaded.
                lblResult.Text = "You did not specify a file to upload.";
                }
            InsertExcelRecords1(savePath);
        }
        
        private void InsertExcelRecords1(string FilePath)
        {
            ExcelConn(FilePath);

            Query = string.Format("Select [eno],[sname],[dob],[mno],[email_id],[user_address] FROM [{0}]", "Sheet1$");
            OleDbCommand Ecom = new OleDbCommand(Query, Econ);
            Econ.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
            Econ.Close();
            oda.Fill(ds);
            DataTable Exceldt = ds.Tables[0];
            connection();
               
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            
            objbulk.DestinationTableName = "student_master";
                
            objbulk.ColumnMappings.Add("eno", "eno");
            objbulk.ColumnMappings.Add("sname", "sname");
            objbulk.ColumnMappings.Add("dob", "dob");
            objbulk.ColumnMappings.Add("mno", "mno");
            objbulk.ColumnMappings.Add("email_id", "email_id");
            objbulk.ColumnMappings.Add("user_address", "user_address");
            //inserting Datatable Records to DataBase    
            con.Open();
            objbulk.WriteToServer(Exceldt);
            con.Close();
        }
       }
       }
