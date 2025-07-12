using System;
using System.Collections.Generic;
using System.Web.UI;

namespace EmpowerPharma
{
    public partial class CreateP : System.Web.UI.Page
    {
        protected static List<Product> ProductsList = new List<Product>();
        protected static List<Patient> PatientsList = new List<Patient>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblDoctorInfo.Text = $"Logged in as: Dr. John Doe (Reg #MP1234, Cell: 0821234567)";
                LoadProductsDropdown();
                BindProductGrid();
                BindPatientGrid();
            }
        }

        protected void LoadProductsDropdown()
        {
            // Replace with real products
            ddlProducts.Items.Clear();
            ddlProducts.Items.Add("Select a product");
            ddlProducts.Items.Add("Paracetamol 500mg");
            ddlProducts.Items.Add("Ibuprofen 200mg");
            ddlProducts.Items.Add("Amoxicillin 250mg");
        }

        protected void btnNewProduct_Click(object sender, EventArgs e)
        {
            pnlAddProduct.Visible = true;
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (ddlProducts.SelectedIndex > 0)
            {
                ProductsList.Add(new Product
                {
                    Name = ddlProducts.SelectedValue,
                    Quantity = int.Parse(txtProductQuantity.Text),
                    Price = GetProductPrice(ddlProducts.SelectedValue),
                    Description = txtProductDescription.Text
                });
                pnlAddProduct.Visible = false;
                BindProductGrid();
            }
        }

        protected decimal GetProductPrice(string productName)
        {
            // Example prices
            if (productName.Contains("Paracetamol")) return 50;
            if (productName.Contains("Ibuprofen")) return 70;
            if (productName.Contains("Amoxicillin")) return 100;
            return 0;
        }

        protected void BindProductGrid()
        {
            gvProducts.DataSource = ProductsList;
            gvProducts.DataBind();
        }

        protected void btnNewPatient_Click(object sender, EventArgs e)
        {
            pnlAddPatient.Visible = true;
        }

        protected void btnAddPatient_Click(object sender, EventArgs e)
        {
            PatientsList.Add(new Patient
            {
                Name = txtPatientName.Text,
                IDNumber = txtPatientID.Text,
                Mobile = txtPatientMobile.Text
            });
            pnlAddPatient.Visible = false;
            BindPatientGrid();
        }

        protected void BindPatientGrid()
        {
            gvPatients.DataSource = PatientsList;
            gvPatients.DataBind();
        }

        protected void btnCreatePrescription_Click(object sender, EventArgs e)
        {
            string generatedOtp = GenerateOtp();
            Session["CurrentOtp"] = generatedOtp;
            lblOtpInstructions.Text = $"A 6-digit code has been sent to Dr. John Doe's mobile. (Demo: {generatedOtp})";

            // TODO: Integrate with real SMS provider
            SendSmsToDoctor(generatedOtp);

            StartOtpCountdown();

            mpeOTP.Show();
        }

        private string GenerateOtp()
        {
            Random rand = new Random();
            return rand.Next(100000, 999999).ToString();
        }

        private void SendSmsToDoctor(string otp)
        {
            // Placeholder for SMS integration
            System.Diagnostics.Debug.WriteLine($"SMS sent to doctor: {otp}");
        }

        private void StartOtpCountdown()
        {
            lblOtpCountdown.Text = "Expires in 60 seconds.";
            // For real countdown, you'd use JS or Timer control
        }

        protected void btnSubmitOtp_Click(object sender, EventArgs e)
        {
            string enteredOtp = txtOtpInput.Text.Trim();
            if (Session["CurrentOtp"] != null && enteredOtp == Session["CurrentOtp"].ToString())
            {
                // OTP verified!
                // TODO: Save prescription
                lblOtpInstructions.Text = "OTP Verified! Prescription saved.";
            }
            else
            {
                lblOtpInstructions.Text = "Invalid OTP. Try again.";
            }

            mpeOTP.Show();
        }

        protected void btnCancelOtp_Click(object sender, EventArgs e)
        {
            mpeOTP.Hide();
        }

        protected void btnResendOtp_Click(object sender, EventArgs e)
        {
            btnCreatePrescription_Click(sender, e);
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }

    public class Patient
    {
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public string Mobile { get; set; }
    }
}
