using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppAss7
{
    internal class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataAdapter sda;
        public static DataSet ds;
        public static string conStr = "server=LAPTOP-KP6PKP4L;database=Ass7LibraryDB;trusted_connection=true;";
        static void Main(string[] args)
        {
            string choice;
            do
            {
                Console.WriteLine("Choose the Operation to perform");
                Console.WriteLine("1.To Display, 2.Add New Book 3.Update a Book");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            try
                            {
                                con = new SqlConnection(conStr);
                                cmd = new SqlCommand("Select * from Books", con);
                                sda = new SqlDataAdapter(cmd);
                                ds = new DataSet();
                                con.Open();
                                sda.Fill(ds, "Books");
                                con.Close();
                                foreach (DataRow row in ds.Tables["Books"].Rows)
                                {
                                    Console.WriteLine("Book ID:"+row[0] );
                                    Console.WriteLine("Title:"+row[1] );
                                    Console.WriteLine("Author:" + row[2] );
                                    Console.WriteLine("Genre:"+row[3] );
                                    Console.WriteLine("Quantity:"+row[4]);
                                    Console.WriteLine("\n");  
                                    
                                }
                            }
                            catch (Exception ex) { Console.WriteLine("Error!!!" + ex.Message); }
                            finally { Console.ReadKey(); }
                            break;
                        }
                    case 2:
                        {
                            try
                            {
                                con = new SqlConnection(conStr);
                                cmd = new SqlCommand("Select * from Books", con);
                                sda = new SqlDataAdapter(cmd);
                                ds = new DataSet();
                                con.Open();
                                sda.Fill(ds, "Books");
                                DataTable dt = ds.Tables["Books"];
                                DataRow dr = dt.NewRow();
                                Console.WriteLine("enter Book id");
                                dr["BookId"] = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Title of Book");
                                dr["Title"]=Console.ReadLine();
                                Console.WriteLine("Enter Author of Book");
                                dr["Author"] = Console.ReadLine();
                                Console.WriteLine("Enter Genre of Book");
                                dr["Genre"] = Console.ReadLine();
                                Console.WriteLine("enter Quantity");
                                dr["Quantity"] = int.Parse(Console.ReadLine());
                                dt.Rows.Add(dr);
                                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                                sda.Update(ds, "Books");
                                Console.WriteLine("Book Added Successfully !!!");
                                con.Close();
                            }
                            catch (Exception ex) { Console.WriteLine("error!!!" + ex.Message); }
                            finally { Console.ReadKey(); }
                            break;
                        }
                    case 3:
                        {
                            try
                            {
                                con = new SqlConnection(conStr);
                                cmd = new SqlCommand("Select * from Books", con);
                                sda = new SqlDataAdapter(cmd);
                                ds = new DataSet();
                                con.Open();
                                sda.Fill(ds, "Books");
                                Console.WriteLine("Enter Book Id to Update the Book");
                                int bookid = int.Parse(Console.ReadLine());
                                DataRow dr = null;
                                foreach (DataRow row in ds.Tables["Books"].Rows)
                                {
                                    if ((int)row["BookId"] == bookid)
                                    {
                                        dr = row;
                                        break;
                                    }
                                }
                                if (dr == null)
                                {
                                    Console.WriteLine($"No Such Customer {bookid}exist in Customers table");
                                }
                                else
                                {
                                    Console.WriteLine("Enter new Title for the Book");
                                    dr["Title"] = Console.ReadLine();
                                    Console.WriteLine("Enter  Author for the Book");
                                    dr["Author"] = Console.ReadLine();
                                    Console.WriteLine("Enter  Genre for the Book");
                                    dr["Genre"] = Console.ReadLine();
                                    Console.WriteLine("Enter Quantity for the Book");
                                    dr["Quantity"] = Console.ReadLine();

                                    SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                                    sda.Update(ds, "Books");
                                    Console.WriteLine("Record Updated");
                                    con.Close();
                                }
                            }
                            catch (Exception ex) { Console.WriteLine("Error!!!" + ex.Message); }
                            finally { Console.ReadKey(); }
                            break;
                        }
                }
                Console.WriteLine("Do you want to continue yes or no");
                choice = Console.ReadLine();

            } while (choice == "yes");
        }
    }
}
