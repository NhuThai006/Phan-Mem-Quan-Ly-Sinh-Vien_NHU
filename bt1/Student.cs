using bt1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Student
{
    My_DB db = new My_DB();

    public int MSSV { get; set; }
    public string Fname { get; set; }
    public string Lname { get; set; }
    public DateTime Dob { get; set; }
    public string Gender { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Hometown { get; set; }
    public string Email { get; set; }
    public byte[] Picture { get; set; }

    // Constructor
    public Student(int mssv, string fname, string lname, DateTime dob,
        string gender, string phone, string address, string hometown,
        string email, byte[] picture)
    {
        MSSV = mssv; Fname = fname; Lname = lname; Dob = dob;
        Gender = gender; Phone = phone; Address = address;
        Hometown = hometown; Email = email; Picture = picture;
    }

    public bool AddStudent()
    {
        try
        {
            db.openConnection();
            string query = "INSERT INTO Student VALUES " +
                "(@mssv, @fname, @lname, @dob, @gder, @phone, @addr, @htown, @email, @pic)";
            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@mssv", MSSV);
            cmd.Parameters.AddWithValue("@fname", Fname);
            cmd.Parameters.AddWithValue("@lname", Lname);
            cmd.Parameters.AddWithValue("@dob", Dob);
            cmd.Parameters.AddWithValue("@gder", Gender);
            cmd.Parameters.AddWithValue("@phone", Phone);
            cmd.Parameters.AddWithValue("@addr", Address);
            cmd.Parameters.AddWithValue("@htown", Hometown);
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@pic", (object)Picture ?? DBNull.Value);

            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }
        catch { return false; }
        finally { db.closeConnection(); }
    }
}