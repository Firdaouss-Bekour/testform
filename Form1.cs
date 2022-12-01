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

            /* con = new SqlConnection("Data Source=DESKTOP-U783UJF\\SQLEXPRESS;Initial Catalog=livre;Integrated Security=True");
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
            con.Close();*/

            button5.Enabled = true;
            button4.Enabled = true;
            button2.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;


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

            button5.Enabled = false;
            button4.Enabled = true;
            button2.Enabled = false;
            button1.Enabled = true;
            button3.Enabled = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;

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

            button5.Enabled = false;
            button4.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = true;
            button3.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;

        }

        private void button_Enregistrer(object sender, EventArgs e)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();


            button5.Enabled = false;
            button4.Enabled = false;
            button2.Enabled = true;
            button1.Enabled = true;
            button3.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'livreDataSet.biblio' table. You can move, or remove it, as needed.
            this.biblioTableAdapter.Fill(this.livreDataSet.biblio);

            button5.Enabled = false;
            button4.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = true;
            button3.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (modWasClicked)
            {

                

                button5.Enabled = false;//anuuler
                button4.Enabled = false;//
                button2.Enabled = true;
                button1.Enabled = true;
                button3.Enabled = true;
                textBox3.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                

            }
            else
            {



                button5.Enabled = false;
                button4.Enabled = false;
                button2.Enabled = false;
                button1.Enabled = true;
                button3.Enabled = false;
                textBox3.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Clear();
                textBox2.Enabled = false;
                textBox1.Clear();
                textBox3.Clear();

            }
        }
    }
}
