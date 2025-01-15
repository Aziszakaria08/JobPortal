using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal.Admin
{
    public partial class NewJob : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader sdr;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            Session["title"] = "Add Job";
            if (!IsPostBack)
            {
                fillData();
            }
        }
        private void fillData()
        {
          if (Request.QueryString["id"] != null)
            {
                con = new SqlConnection(str);
                query = "Select * From Jobs where JobId = '" + Request.QueryString["id"] + "' ";
                cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        txtJobTitle.Text = sdr["Title"].ToString();
                        txtNoOfPost.Text = sdr["NoOfPost"].ToString();
                        txtDescription.Text = sdr["Description"].ToString();
                        txtQualification.Text = sdr["Qualification"].ToString();
                        txtExperience.Text = sdr["Experience"].ToString();
                        txtSpecialization.Text = sdr["Specialization"].ToString();
                        txtLastDate.Text = Convert.ToDateTime( sdr["LastDateToApply"]).ToString("yyyyy-MM-dd");
                        txtSalary.Text = sdr["Salary"].ToString();
                        ddlJobType.SelectedValue = sdr["JobType"].ToString();
                        txtCompany.Text = sdr["CompanyName"].ToString();
                        txtWebsite.Text = sdr["Website"].ToString();
                        txtEmail.Text = sdr["Email"].ToString();
                        txtAddress.Text = sdr["Address"].ToString();
                        ddlCountry.SelectedValue = sdr["Country"].ToString();
                        txtState.Text = sdr["State"].ToString();
                        btnAdd.Text = "Update";
                        linkBack.Visible = true;
                        Session["title"] = "Edit Job";
                    }
                }
                else
                {
                    lblMsg.Text = "Job not found...!";
                    lblMsg.CssClass = "alert alert-danger";
                }
                sdr.Close();
                con.Close();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string type, concatQuery, imagePath = string.Empty;
                bool isValidToExecute = false;
                con = new SqlConnection(str);
                DateTime lastDate;

                if (!DateTime.TryParse(txtLastDate.Text.Trim(), out lastDate))
                {
                    lblMsg.Text = "Invalid date format. Please enter a valid date.";
                    lblMsg.CssClass = "alert alert-danger";
                    return;
                }

                if (Request.QueryString["id"] != null)
                {
                    if (fuCompanyLogo.HasFile && Utils.isValidExtension(fuCompanyLogo.FileName))
                    {
                        concatQuery = "CompanyImage = @CompanyImage,";
                    }
                    else
                    {
                        concatQuery = string.Empty;
                    }

                    query = @"UPDATE Jobs SET Title = @Title, NoOfPost = @NoOfPost, Description = @Description, 
                       Qualification = @Qualification, Experience = @Experience, Specialization = @Specialization, 
                       LastDateToApply = @LastDateToApply, Salary = @Salary, JobType = @JobType, CompanyName = @CompanyName, "
                               + concatQuery + @"Website = @Website, Email = @Email, Address = @Address, Country = @Country, 
                       State = @State WHERE JobId = @id";

                    type = "updated";
                }
                else
                {
                    query = @"INSERT INTO Jobs (Title, NoOfPost, Description, Qualification, Experience, Specialization, 
                       LastDateToApply, Salary, JobType, CompanyName, CompanyImage, Website, Email, Address, Country, 
                       State, CreateDate) VALUES 
                       (@Title, @NoOfPost, @Description, @Qualification, @Experience, @Specialization, @LastDateToApply, 
                       @Salary, @JobType, @CompanyName, @CompanyImage, @Website, @Email, @Address, @Country, @State, 
                       @CreateDate)";

                    type = "saved";
                }

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Title", txtJobTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@NoOfPost", txtNoOfPost.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text.Trim());
                cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                cmd.Parameters.AddWithValue("@Specialization", txtSpecialization.Text.Trim());
                cmd.Parameters.AddWithValue("@LastDateToApply", lastDate);  // Use the parsed DateTime value
                cmd.Parameters.AddWithValue("@Salary", txtSalary.Text.Trim());
                cmd.Parameters.AddWithValue("@JobType", ddlJobType.SelectedValue.Trim());
                cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text.Trim());
                cmd.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue.Trim());
                cmd.Parameters.AddWithValue("@State", txtState.Text.Trim());

                if (Request.QueryString["id"] != null)
                {
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                }

                if (fuCompanyLogo.HasFile && Utils.isValidExtension(fuCompanyLogo.FileName))
                {
                    Guid obj = Guid.NewGuid();
                    imagePath = "Images/" + obj.ToString() + fuCompanyLogo.FileName;
                    fuCompanyLogo.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + fuCompanyLogo.FileName);
                    cmd.Parameters.AddWithValue("@CompanyImage", imagePath);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CompanyImage", string.Empty);
                }

                con.Open();
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    lblMsg.Text = "Job " + type + " successfully!";
                    lblMsg.CssClass = "alert alert-success";
                    clear();
                }
                else
                {
                    lblMsg.Text = "Unable to " + type + " job. Please try again.";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
        }

        private void clear()
        {
            txtJobTitle.Text = string.Empty;
            txtNoOfPost.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtQualification.Text = string.Empty;
            txtExperience.Text = string.Empty;
            txtSpecialization.Text = string.Empty;
            txtLastDate.Text = string.Empty;
            txtSalary.Text = string.Empty;
            txtCompany.Text = string.Empty;
            txtWebsite.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtState.Text = string.Empty;
            ddlJobType.ClearSelection();
            ddlCountry.ClearSelection();

        }
        //private bool isValidExtension(string fileName)
        //{
        //    bool isValid = false;
        //    string[] fileExtension = { ".jpg", ".jpeg", ".png" };
        //    for (int i = 0; i <= fileExtension.Length - 1; i++)
        //    {
        //        if (fileName.Contains(fileExtension[i]))
        //        {
        //            isValid = true;
        //            break;
        //        }
        //    }
        //    return isValid;
        //}
    }
}