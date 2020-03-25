using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace TDSSales.MODULOS
{
    public partial class UsuariosOK : Form
    {
        public UsuariosOK()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        public bool validar_Mail(string sMail) {
            return Regex.IsMatch(sMail, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (validar_Mail(txtcorreo.Text) == false)
            {
                MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, " + " por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcorreo.Focus();
                txtcorreo.SelectAll();
            }
            else
            {

                if (txtnombre.Text != string.Empty && txtusuario.Text != string.Empty && txtpassword.Text != string.Empty
                    && txtrol.Text != string.Empty)
                {
                    try
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insertar_usuario", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombres", txtnombre.Text);
                        cmd.Parameters.AddWithValue("@Login", txtusuario.Text);
                        cmd.Parameters.AddWithValue("@Password", txtpassword.Text);

                        cmd.Parameters.AddWithValue("@Correo", txtcorreo.Text);
                        cmd.Parameters.AddWithValue("@Rol", txtrol.Text);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        ICONO.Image.Save(ms, ICONO.Image.RawFormat);


                        cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer());
                        cmd.Parameters.AddWithValue("@Nombre_de_icono", lblnumeroicono.Text);
                        cmd.Parameters.AddWithValue("@Estado", "ACTIVO");

                        cmd.ExecuteNonQuery();
                        con.Close();

                        mostrar();
                        panelregistro1.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else {
                    MessageBox.Show("Asegurese de haber completado todos los campos", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
            }
        }
        private void mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                da = new SqlDataAdapter("mostrar_usuario", con);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();
                datalistado.Columns[1].Visible = false;
                datalistado.Columns[5].Visible = false;
                datalistado.Columns[6].Visible = false;
                datalistado.Columns[7].Visible = false;
                datalistado.Columns[8].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  
            }
            CONEXION.Tamaño_automatico_de_datatables.Multilinea(ref datalistado);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox3.Image;
            lblnumeroicono.Text = "1";
            lblicono.Visible = false;
            panelIcono.Visible = false;
        }
        private void Cargar_estado_de_iconos()
        {
            try
            {
                foreach (DataGridViewRow row in datalistado.Rows)
                {

                    try
                    {

                        string Icono = Convert.ToString(row.Cells["Nombre_de_icono"].Value);

                        if (Icono == "1")
                        {
                            pictureBox3.Visible = false;
                        }
                        else if (Icono == "2")
                        {
                            pictureBox4.Visible = false;
                        }
                        else if (Icono == "3")
                        {
                            pictureBox5.Visible = false;
                        }
                        else if (Icono == "4")
                        {
                            pictureBox6.Visible = false;
                        }
                        else if (Icono == "5")
                        {
                            pictureBox7.Visible = false;
                        }
                        else if (Icono == "6")
                        {
                            pictureBox8.Visible = false;
                        }
                        else if (Icono == "7")
                        {
                            pictureBox9.Visible = false;
                        }
                        else if (Icono == "8")
                        {
                            pictureBox10.Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                      
                        MessageBox.Show(ex.Message);

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void lblicono_Click(object sender, EventArgs e)
        {
            panelIcono.Visible = true;
            Cargar_estado_de_iconos();
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox4.Image;
            lblnumeroicono.Text = "2";
            lblicono.Visible = false;
            panelIcono.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox5.Image;
            lblnumeroicono.Text = "3";
            lblicono.Visible = false;
            panelIcono.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox6.Image;
            lblnumeroicono.Text = "4";
            lblicono.Visible = false;
            panelIcono.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox7.Image;
            lblnumeroicono.Text = "5";
            lblicono.Visible = false;
            panelIcono.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox8.Image;
            lblnumeroicono.Text = "6";
            lblicono.Visible = false;
            panelIcono.Visible = false;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox9.Image;
            lblnumeroicono.Text = "7";
            lblicono.Visible = false;
            panelIcono.Visible = false;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox10.Image;
            lblnumeroicono.Text = "8";
            lblicono.Visible = false;
            panelIcono.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panelregistro1.Visible = true;
            lblicono.Visible = true;
            limpiarcampos();
            btnguardarcambios.Visible = false;
            btnguardar.Visible = true;
 
        }
        private void limpiarcampos()
        {
            txtnombre.Clear();
            txtusuario.Clear();
            txtpassword.Clear();
            txtcorreo.Clear();
            

        }

        private void UsuariosOK_Load(object sender, EventArgs e)
        {
            panelregistro1.Visible = false;
            panelIcono.Visible = false;
            mostrar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void datalistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datalistado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblidusuarios.Text = datalistado.SelectedCells[1].Value.ToString();
            txtnombre.Text = datalistado.SelectedCells[2].Value.ToString();
            txtusuario.Text = datalistado.SelectedCells[3].Value.ToString();
            txtpassword.Text = datalistado.SelectedCells[4].Value.ToString();

            ICONO.BackgroundImage = null;
            byte[] b = (Byte[])datalistado.SelectedCells[5].Value;
            MemoryStream ms = new MemoryStream(b);
            ICONO.Image = Image.FromStream(ms);
            //ICONO.SizeMode = PictureBoxSizeMode.Zoom;
            lblicono.Visible = false;

            lblnumeroicono.Text = datalistado.SelectedCells[6].Value.ToString();
            txtcorreo.Text = datalistado.SelectedCells[7].Value.ToString();
            txtrol.Text = datalistado.SelectedCells[8].Value.ToString();
            panelregistro1.Visible = true;
            btnguardarcambios.Visible = true;
            btnguardar.Visible = false;

        }

        private void ICONO_Click(object sender, EventArgs e)
        {
            Cargar_estado_de_iconos();
            panelIcono.Visible = true;
        }

        private void btnvolver_Click(object sender, EventArgs e)
        {
            panelregistro1.Visible = false;
        }

        private void btnguardarcambios_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text != string.Empty)
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("editar_usuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", lblidusuarios.Text);
                    cmd.Parameters.AddWithValue("@nombres", txtnombre.Text);
                    cmd.Parameters.AddWithValue("@Login", txtusuario.Text);
                    cmd.Parameters.AddWithValue("@Password", txtpassword.Text);

                    cmd.Parameters.AddWithValue("@Correo", txtcorreo.Text);
                    cmd.Parameters.AddWithValue("@Rol", txtrol.Text);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    ICONO.Image.Save(ms, ICONO.Image.RawFormat);


                    cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer());
                    cmd.Parameters.AddWithValue("@Nombre_de_icono", lblnumeroicono.Text);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    mostrar();
                    panelregistro1.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.datalistado.Columns["Eli"].Index)
            {
                DialogResult result;
                result = MessageBox.Show("¿Realmente desea eliminar este Usuario?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    SqlCommand cmd;
                    try
                    {
                        foreach (DataGridViewRow row in datalistado.SelectedRows)
                        {

                            int onekey = Convert.ToInt32(row.Cells["idUsuario"].Value);
                            string usuario = Convert.ToString(row.Cells["Login"].Value);

                            try
                            {

                                try
                                {

                                    SqlConnection con = new SqlConnection();
                                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                                    con.Open();
                                    cmd = new SqlCommand("eliminar_usuario", con);
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    cmd.Parameters.AddWithValue("@idusuario", onekey);
                                    cmd.Parameters.AddWithValue("@login", usuario);
                                    cmd.ExecuteNonQuery();

                                    con.Close();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);
                            }

                        }
                        mostrar();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void datalistado_Click(object sender, EventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtusuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtcorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtrol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Click(object sender, EventArgs e)
        {
            panelIcono.Visible = false;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de Imagenes TDSSales";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ICONO.BackgroundImage = null;
                ICONO.Image = new Bitmap(dlg.FileName);
                ICONO.SizeMode = PictureBoxSizeMode.Zoom;
                lblnumeroicono.Visible = true;
                lblnumeroicono.Text = Path.GetFileName(dlg.FileName);
                lblicono.Visible = false;
                panelIcono.Visible = false;
            }
        }
        private void buscar_usuario()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                da = new SqlDataAdapter("buscar_usuario", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", txtbuscar.Text);

                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();
                datalistado.Columns[1].Visible = false;
                datalistado.Columns[5].Visible = false;
                datalistado.Columns[6].Visible = false;
                datalistado.Columns[7].Visible = false;
                datalistado.Columns[8].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CONEXION.Tamaño_automatico_de_datatables.Multilinea(ref datalistado);
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            buscar_usuario();
        }
        public void Numeros(System.Windows.Forms.TextBox CajaTexto, System.Windows.Forms.KeyPressEventArgs e) {
            if (char.IsDigit(e.KeyChar)) {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtcorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            Numeros(txtbuscar, e);
        }
    }
}
