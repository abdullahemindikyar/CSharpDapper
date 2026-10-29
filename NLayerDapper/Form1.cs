using Dapper;
using NLayerDapper.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NLayerDapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Server=EMINDIKYAR\SQLEXPRESS;Initial Catalog=CSharpDapperDb;Integrated Security=True");

        private async void btnList_Click(object sender, EventArgs e)
        {
            string query = "Select * from TblProduct";
            var values = await connection.QueryAsync<ResultProductDto>(query);
            dataGridView.DataSource = values;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "Insert into TblProduct (ProductName, ProductStock, ProductPrice, ProductCategory) values (@productName, @productStock, @productPrice, @productCategory)";

            var parameters = new DynamicParameters();
            parameters.Add("@productName", txtProductName.Text);
            parameters.Add("@productStock", txtProductStock.Text);
            parameters.Add("@productPrice", txtProductPrice.Text);
            parameters.Add("@productCategory", txtProductCategory.Text);

            await connection.ExecuteAsync(query, parameters);
            MessageBox.Show("Product added successfully.");
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string query = "Delete From TblProduct where ProductId = @productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", Convert.ToInt32(txtProductId.Text));
            await connection.ExecuteAsync(query, parameters);
            MessageBox.Show("Product deleted successfully.");
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = "Update TblProduct set ProductName = @productName, ProductStock = @productStock, ProductPrice = @productPrice, ProductCategory = @productCategory where ProductId = @productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", Convert.ToInt32(txtProductId.Text));
            parameters.Add("@productName", txtProductName.Text);
            parameters.Add("@productStock", txtProductStock.Text);
            parameters.Add("@productPrice", txtProductPrice.Text);
            parameters.Add("@productCategory", txtProductCategory.Text);

            await connection.ExecuteAsync(query, parameters);
            MessageBox.Show("Product updated successfully.");
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string query1 = "Select Count(*) from TblProduct";
            var totalProductCount = await connection.QueryFirstOrDefaultAsync<int>(query1);
            lblTotalProductCount.Text = totalProductCount.ToString();

            string query2 = "Select ProductName from tblProduct where ProductPrice = (Select Max(ProductPrice) from tblProduct)";
            var mostPriceProduct = await connection.QueryFirstOrDefaultAsync<string>(query2);
            lblMostPriceProduct.Text = mostPriceProduct ?? "Not found";

            // Category Count
            string query3 = "Select Count(Distinct ProductCategory) from TblProduct";
            var categoryCount = await connection.QueryFirstOrDefaultAsync<int>(query3);
            lblCategoryCount.Text = categoryCount.ToString();

        }
    }
}


/*
 string query = "Select * from TblProduct";
            var values = await connection.QueryAsync<ResultProductDto>(query);
            dataGridView.DataSource = values;
 */