﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDSSales.MODULOS
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
            DibujarUsuarios();
        }

        public void DibujarUsuarios()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("select * from USUARIO2 WHERE Estado = 'ACTIVO'", con);

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Label b = new Label();
                    Panel p1 = new Panel();
                    PictureBox I1 = new PictureBox();

                    b.Text = rdr["Login"].ToString();
                    b.Name = rdr["idUsuario"].ToString();
                    b.Size = new System.Drawing.Size(175, 25);
                    b.Font = new System.Drawing.Font("Microsoft Sans Serif", 13);
                    b.BackColor = Color.FromArgb(67, 67, 67);
                    b.ForeColor = Color.White;
                    b.Dock = DockStyle.Bottom;
                    b.TextAlign = ContentAlignment.MiddleCenter;
                    b.Cursor = Cursors.Hand;

                    p1.Size = new System.Drawing.Size(237, 170);
                    p1.BorderStyle = BorderStyle.None;
                    p1.BackColor = Color.FromArgb(67, 67, 67);


                    I1.Size = new System.Drawing.Size(237, 135);
                    I1.Dock = DockStyle.Top;
                    I1.BackgroundImage = null;
                    byte[] bi = (Byte[])rdr["Icono"];

                    MemoryStream ms = new MemoryStream(bi);
                    I1.Image = Image.FromStream(ms);
                    I1.SizeMode = PictureBoxSizeMode.Zoom;
                    I1.Tag = rdr["Login"].ToString();
                    I1.Cursor = Cursors.Hand;

                    p1.Controls.Add(b);
                    p1.Controls.Add(I1);
                    b.BringToFront();
                    flowLayoutPanel1.Controls.Add(p1);

                    //b.Click += new EventHandler(mieventoLabel);
                    //I1.Click += new EventHandler(miEventoImagen);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            UsuariosOK user = new UsuariosOK();
            user.Show();
        }
        private void miEventoImagen(System.Object sender, EventArgs e)
        {
            //txtlogin.Text = ((PictureBox)sender).Tag.ToString();
            //panel2.Visible = true;
            //panel1.Visible = false;
            //MOSTRAR_PERMISOS();
        }

        private void mieventoLabel(System.Object sender, EventArgs e)
        {

 
            //panel2.Visible = true;
            //panel1.Visible = false;
            //MOSTRAR_PERMISOS();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }
        private void cargarusuarios()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("validar_usuario", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@password", txtpassword.Text);
                da.SelectCommand.Parameters.AddWithValue("@login", txtbuscar.Text);

                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }



        }

    }
}
