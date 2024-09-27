using System;
using System.IO;
using System.Windows.Forms;

namespace Formulario_c_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtener valores desde los textboxes
            string nombres = tbNombre.Text.Trim();
            string apellidos = tbApellidos.Text.Trim();
            string edad = tbEdad.Text.Trim();
            string estatura = tbEstatura.Text.Trim();
            string telefono = tbTelefono.Text.Trim();
            string genero = "";

            // Validar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(nombres) || string.IsNullOrWhiteSpace(apellidos) ||
                string.IsNullOrWhiteSpace(edad) || string.IsNullOrWhiteSpace(estatura) ||
                string.IsNullOrWhiteSpace(telefono))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que la edad y la estatura sean numéricas
            if (!int.TryParse(edad, out _) || !double.TryParse(estatura, out _))
            {
                MessageBox.Show("La edad debe ser un número entero y la estatura un número válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el teléfono sea numérico y tenga al menos 7 dígitos
            if (!long.TryParse(telefono, out _) || telefono.Length < 7)
            {
                MessageBox.Show("El teléfono debe contener al menos 7 dígitos numéricos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar selección de género
            if (rbHombre.Checked)
            {
                genero = "Hombre";
            }
            else if (rbMujer.Checked)
            {
                genero = "Mujer";
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un género.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Generar la cadena de datos
            string datos = $"Nombres: {nombres}\nApellidos: {apellidos}\nEdad: {edad} años\nEstatura: {estatura}\nTeléfono: {telefono}\nGénero: {genero}\n";

            // Guardar los datos en un archivo de texto
            try
            {
                File.AppendAllText("302024Datos.txt", datos + "\n\n");
                MessageBox.Show("Datos guardados con éxito:\n\n" + datos, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los campos después de guardar
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            tbNombre.Clear();
            tbApellidos.Clear();
            tbEdad.Clear();
            tbEstatura.Clear();
            tbTelefono.Clear();
            rbHombre.Checked = false;
            rbMujer.Checked = false;
        }

        private void InitializeComponent()
        {
            this.tbNombre = new TextBox();
            this.tbApellidos = new TextBox();
            this.tbEdad = new TextBox();
            this.tbEstatura = new TextBox();
            this.tbTelefono = new TextBox();
            this.rbHombre = new RadioButton();
            this.rbMujer = new RadioButton();
            this.btnGuardar = new Button();
            this.btnBorrar = new Button();
            this.lbNombre = new Label();
            this.lbApellidos = new Label();
            this.lbEdad = new Label();
            this.lbEstatura = new Label();
            this.lbTelefono = new Label();
            this.lbGenero = new Label();

            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(100, 30);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(200, 20);
            this.tbNombre.TabIndex = 0;

            // 
            // tbApellidos
            // 
            this.tbApellidos.Location = new System.Drawing.Point(100, 60);
            this.tbApellidos.Name = "tbApellidos";
            this.tbApellidos.Size = new System.Drawing.Size(200, 20);
            this.tbApellidos.TabIndex = 1;

            // 
            // tbEdad
            // 
            this.tbEdad.Location = new System.Drawing.Point(100, 90);
            this.tbEdad.Name = "tbEdad";
            this.tbEdad.Size = new System.Drawing.Size(200, 20);
            this.tbEdad.TabIndex = 2;

            // 
            // tbEstatura
            // 
            this.tbEstatura.Location = new System.Drawing.Point(100, 120);
            this.tbEstatura.Name = "tbEstatura";
            this.tbEstatura.Size = new System.Drawing.Size(200, 20);
            this.tbEstatura.TabIndex = 3;

            // 
            // tbTelefono
            // 
            this.tbTelefono.Location = new System.Drawing.Point(100, 150);
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(200, 20);
            this.tbTelefono.TabIndex = 4;

            // 
            // rbHombre
            // 
            this.rbHombre.AutoSize = true;
            this.rbHombre.Location = new System.Drawing.Point(100, 180);
            this.rbHombre.Name = "rbHombre";
            this.rbHombre.Size = new System.Drawing.Size(60, 17);
            this.rbHombre.TabIndex = 5;
            this.rbHombre.TabStop = true;
            this.rbHombre.Text = "Hombre";
            this.rbHombre.UseVisualStyleBackColor = true;

            // 
            // rbMujer
            // 
            this.rbMujer.AutoSize = true;
            this.rbMujer.Location = new System.Drawing.Point(170, 180);
            this.rbMujer.Name = "rbMujer";
            this.rbMujer.Size = new System.Drawing.Size(50, 17);
            this.rbMujer.TabIndex = 6;
            this.rbMujer.TabStop = true;
            this.rbMujer.Text = "Mujer";
            this.rbMujer.UseVisualStyleBackColor = true;

            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(100, 220);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new EventHandler(this.btnGuardar_Click);

            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(200, 220);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 8;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new EventHandler(this.btnBorrar_Click);

            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(30, 33);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(55, 13);
            this.lbNombre.TabIndex = 9;
            this.lbNombre.Text = "Nombres:";

            // 
            // lbApellidos
            // 
            this.lbApellidos.AutoSize = true;
            this.lbApellidos.Location = new System.Drawing.Point(30, 63);
            this.lbApellidos.Name = "lbApellidos";
            this.lbApellidos.Size = new System.Drawing.Size(55, 13);
            this.lbApellidos.TabIndex = 10;
            this.lbApellidos.Text = "Apellidos:";

            // 
            // lbEdad
            // 
            this.lbEdad.AutoSize = true;
            this.lbEdad.Location = new System.Drawing.Point(30, 93);
            this.lbEdad.Name = "lbEdad";
            this.lbEdad.Size = new System.Drawing.Size(34, 13);
            this.lbEdad.TabIndex = 11;
            this.lbEdad.Text = "Edad:";

            // 
            // lbEstatura
            // 
            this.lbEstatura.AutoSize = true;
            this.lbEstatura.Location = new System.Drawing.Point(30, 123);
            this.lbEstatura.Name = "lbEstatura";
            this.lbEstatura.Size = new System.Drawing.Size(51, 13);
            this.lbEstatura.TabIndex = 12;
            this.lbEstatura.Text = "Estatura:";

            // 
            // lbTelefono
            // 
            this.lbTelefono.AutoSize = true;
            this.lbTelefono.Location = new System.Drawing.Point(30, 153);
            this.lbTelefono.Name = "lbTelefono";
            this.lbTelefono.Size = new System.Drawing.Size(56, 13);
            this.lbTelefono.TabIndex = 13;
            this.lbTelefono.Text = "Telefono:";

            // 
            // lbGenero
            // 
            this.lbGenero.AutoSize = true;
            this.lbGenero.Location = new System.Drawing.Point(30, 183);
            this.lbGenero.Name = "lbGenero";
            this.lbGenero.Size = new System.Drawing.Size(47, 13);
            this.lbGenero.TabIndex = 14;
            this.lbGenero.Text = "Genero:";

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.lbApellidos);
            this.Controls.Add(this.tbApellidos);
            this.Controls.Add(this.lbEdad);
            this.Controls.Add(this.tbEdad);
            this.Controls.Add(this.lbEstatura);
            this.Controls.Add(this.tbEstatura);
            this.Controls.Add(this.lbTelefono);
            this.Controls.Add(this.tbTelefono);
            this.Controls.Add(this.lbGenero);
            this.Controls.Add(this.rbHombre);
            this.Controls.Add(this.rbMujer);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnBorrar);
            this.Name = "Form1";
            this.Text = "Formulario de Registro";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
