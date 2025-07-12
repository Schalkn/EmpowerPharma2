using System;
using System.Collections.Generic;
using System.Web.UI;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace EmpowerPharma
{
    public partial class CreatePresc : System.Web.UI.Page
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

        private void GeneratePrescriptionPdf()
        {
            string folder = Server.MapPath("~/Prescriptions");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string filePath = Path.Combine(folder,
                $"Prescription_{DateTime.Now:yyyyMMddHHmmss}.pdf");

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                Document doc = new Document(PageSize.A4);
                PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // Doctor details
                doc.Add(new Paragraph(lblDoctorInfo.Text));
                doc.Add(Chunk.NEWLINE);

                // Products table
                doc.Add(new Paragraph("Products"));
                PdfPTable prodTable = new PdfPTable(4);
                prodTable.AddCell("Product");
                prodTable.AddCell("Quantity");
                prodTable.AddCell("Price");
                prodTable.AddCell("Description");
                foreach (var p in ProductsList)
                {
                    prodTable.AddCell(p.Name);
                    prodTable.AddCell(p.Quantity.ToString());
                    prodTable.AddCell(p.Price.ToString("C"));
                    prodTable.AddCell(p.Description);
                }
                doc.Add(prodTable);
                doc.Add(Chunk.NEWLINE);

                // Patients table
                doc.Add(new Paragraph("Patients"));
                PdfPTable patTable = new PdfPTable(3);
                patTable.AddCell("Name");
                patTable.AddCell("ID Number");
                patTable.AddCell("Mobile");
                foreach (var pt in PatientsList)
                {
                    patTable.AddCell(pt.Name);
                    patTable.AddCell(pt.IDNumber);
                    patTable.AddCell(pt.Mobile);
                }
                doc.Add(patTable);

                doc.Close();
            }
        }

        protected void btnSubmitOtp_Click(object sender, EventArgs e)
        {
            string enteredOtp = txtOtpInput.Text.Trim();
            if (Session["CurrentOtp"] != null && enteredOtp == Session["CurrentOtp"].ToString())
            {
                // OTP verified!
                GeneratePrescriptionPdf();
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
