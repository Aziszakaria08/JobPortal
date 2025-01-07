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
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string concatQuery, imagePath = string.Empty;
                bool isValidaToExecute = false;
                con = new SqlConnection(str);
                //if (fuCompanyLogo.HasFile)
                //{
                //    if (isValidExtension(fuCompanyLogo.FileName))
                //    {
                //        concatQuery = "";
                //    }
                //    else
                //    {

                //    }
                //}
                //else
                //{

                //}
                query = @"Insert into Jobs values(@Title, @NoOfPost, @Description, @Qualification, @Experience, @Specialization, @LastDateToApply,
                @Salary, @JobType, @CompanyName, @CompanyImage, @Website, @Email, @Address, @Country, @State, @CreateDate)";
                DateTime time = DateTime.Now;
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Title", txtJobTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@NoOfPost", txtNoOfPost.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text.Trim());
                cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                cmd.Parameters.AddWithValue("@Specialization", txtSpecialization.Text.Trim());
                cmd.Parameters.AddWithValue("@LastDateToApply", txtLastDate.Text.Trim());
                cmd.Parameters.AddWithValue("@Salary", txtSalary.Text.Trim());
                cmd.Parameters.AddWithValue("@JobType", ddlJobType.SelectedValue.Trim());
                cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text.Trim());
                //cmd.Parameters.AddWithValue("@CompanyImage", fuCompanyLogo.Trim());
                cmd.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue.Trim());
                cmd.Parameters.AddWithValue("@State", txtState.Text.Trim());
                cmd.Parameters.AddWithValue("@CreateDate", time.ToString("yyyy-MM-dd HH:mm:ss"));
                if (fuCompanyLogo.HasFile)
                {
                     if (isValidExtension(fuCompanyLogo.FileName))
                     {
                        Guid obj = Guid.NewGuid();
                        imagePath = "Images/" + obj.ToString() + fuCompanyLogo.FileName;
                        fuCompanyLogo.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + fuCompanyLogo.FileName);

                        cmd.Parameters.AddWithValue("@CompanyImage", imagePath);
                        isValidaToExecute = true;
                     }
                     else
                     {
                        lblMsg.Text = "Please Select .jpg, .png, .jpeg File for Logo";
                        lblMsg.CssClass = "alert alert-danger";
                     }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CompanyImage", imagePath);
                    isValidaToExecute = true;
                }
                if (isValidaToExecute)
                {
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if(res > 0)
                    {
                        lblMsg.Text = "Job Save is Successfull";
                        lblMsg.CssClass = "alert alert-success";
                        clear();    
                    }
                    else
                    {
                        lblMsg.Text = "Cannot saved the records, please try after sometime....!";
                        lblMsg.CssClass = "alert alert-danger";
                    }
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
        private bool isValidExtension(string fileName)
        {
            bool isValid = false;
            string[] fileExtension = { ".jpg", ".jpeg", ".png" };
            for(int i = 0; i <= fileExtension.Length-1; i++)
            {
                if (fileName.Contains(fileExtension[i]))
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }
    }
}