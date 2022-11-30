using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace testform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool ajoutWasClicked = false;
        private bool modWasClicked = false;
        private void button_Ajouter(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-U783UJF\\SQLEXPRESS;Initial Catalog=livre;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into biblio values('" + int.Parse(textBox3.Text) + "', '" + textBox1.Text + "', '" + int.Parse(textBox2.Text) + "')", con);
            MessageBox.Show(cmd.CommandText);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ajouté avec success");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
           






        }

        private void button_Modifier(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-U783UJF\\SQLEXPRESS;Initial Catalog=livre;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update biblio set nom='" + textBox1.Text + "',prix= '" + int.Parse(textBox2.Text) + "' where id='" + int.Parse(textBox3.Text) + "'", con);
            MessageBox.Show(cmd.CommandText);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Modifié avec success");
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            con.Close();
           
        }

        private void button_Supprimer(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-U783UJF\\SQLEXPRESS;Initial Catalog=livre;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from biblio  where id='" + int.Parse(textBox3.Text) + "'", con);
            MessageBox.Show(cmd.CommandText);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Supprimé avec success");
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
            con.Close();
            
        }

        private void button_Enregistrer(object sender, EventArgs e)
        {
            if (ajoutWasClicked)
            {
                SqlCommand cmd = new SqlCommand("insert into biblio values('" + int.Parse(textBox3.Text) + "', '" + textBox1.Text + "', '" + int.Parse(textBox2.Text) + "')");
                cmd.ExecuteNonQuery();
                ajoutWasClicked = false;
            }

            if (modWasClicked)
            {
                SqlCommand cmd = new SqlCommand("update biblio set nom='" + textBox1.Text + "',prix= '" + int.Parse(textBox2.Text) + "' where id='" + int.Parse(textBox3.Text) + "'");
                cmd.ExecuteNonQuery();
                modWasClicked = false;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'livreDataSet.biblio' table. You can move, or remove it, as needed.
            this.biblioTableAdapter.Fill(this.livreDataSet.biblio);
          
        }

    }
}
