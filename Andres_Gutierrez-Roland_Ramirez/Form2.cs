using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Andres_Gutierrez_Roland_Ramirez
{
    public partial class Form2 : Form
    {
        save guar = new save();
        int N1, cont = 1, semanas_antiguedad=0;
        float complemento = 100000, sueldo_bruto = 0, impuesto = 0, exencion = 0;
        string cargo;

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            List<string> nombres = guar.Leer(); // obtener la lista de nombres desde el archivo

            // Ordenar la lista alfabéticamente por el primer nombre
            nombres = nombres.OrderBy(nombre => nombre.Split('\t')[0].Trim()).ToList();

            // Imprimir los nombres ordenados
            foreach (string nombreLinea in nombres)
            {
                label7.Text += nombreLinea + Environment.NewLine; // Imprimir en una línea diferente cada uno
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                string nombreABuscar = textBox4.Text; // Obtener el nombre del cuadro de texto
                string resultado = guar.Leeruno(nombreABuscar); // Llamar al método Leeruno con el nombre a buscar
                textBox4.Text = "";
                if (resultado != null)
                {
                    label9.Text = "";
                    label9.Text += resultado; // Mostrar el resultado en el Label
                }
                else
                {
                    label9.Text = "";
                    label9.Text = "No se encontró el nombre."; // Mostrar un mensaje si no se encuentra el nombre
                }
            }
            else
            {
                MessageBox.Show("Rellena el campo");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBox1.Text, out float number2) == true)
            {
                MessageBox.Show("Por favor, ingresa solo letras.");
                textBox1.Text = "";
            }
            else
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text!="")
            {
                if (float.TryParse(textBox2.Text, out float number)==false)
                {
                    MessageBox.Show("Por favor, ingresa solo números.");
                    textBox2.Text = "";
                }
                
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                if (float.TryParse(textBox3.Text, out float number) == false)
                {
                    MessageBox.Show("Por favor, ingresa solo números.");
                    textBox3.Text = "";
                }
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.ToLower() != "manual" && comboBox1.Text == "‎ " && comboBox1.Text.ToLower() != "cualificado" && comboBox1.Text.ToLower() != "oficinista" && comboBox1.Text.ToLower() != "directivo")
            {
                MessageBox.Show("Seleccione un cargo valido.");
                comboBox1.Text = "manual";
            }
            else
            {
                textBox3.Focus();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBox1.Text != "")
                {
                    if (textBox2.Text != "")
                    {
                        if (textBox3.Text != "")
                        {
                            if (comboBox1.Text != "")
                            {
                                calcular_salario();
                            }
                            else
                            {
                                comboBox1.Focus();
                            }
                        }
                        else
                        {
                            textBox3.Focus();
                            MessageBox.Show("porfavor ingresa tu las semanas de trabajo");
                        }
                    }
                    else
                    {
                        textBox2.Focus();
                        MessageBox.Show("porfavor ingresa tu sueldo");
                    }
                }
                else
                {
                    textBox1.Focus();
                    MessageBox.Show("porfavor ingresa tu nombre");
                }
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBox4.Text != "")
                {
                    string nombreABuscar = textBox4.Text; // Obtener el nombre del cuadro de texto
                    string resultado = guar.Leeruno(nombreABuscar); // Llamar al método Leeruno con el nombre a buscar
                    textBox4.Text = "";
                    if (resultado != null)
                    {
                        label9.Text = "";
                        label9.Text += resultado; // Mostrar el resultado en el Label
                    }
                    else
                    {
                        label9.Text = "";
                        label9.Text = "No se encontró el nombre."; // Mostrar un mensaje si no se encuentra el nombre
                    }
                }
                else
                {
                    MessageBox.Show("Rellena el campo");
                }
            }
        }

      

        public Form2(int N)
        {
            InitializeComponent();
            Icon = null;
            if (!Directory.Exists(@"C:\andres_roland"))
            {
                Directory.CreateDirectory(@"C:\andres_roland");
            }
            Directory.CreateDirectory(@"C:\andres_roland");
            System.IO.File.WriteAllText(@"C:\andres_roland\G51.txt", string.Empty);
            N1 = N;
            timer1.Enabled = false;
            calcular_salario();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if(textBox2.Text != "")
                {
                    if(textBox3.Text != "")
                    {
                        if(comboBox1.Text != "")
                        {
                            calcular_salario();
                        }
                        else
                        {
                            comboBox1.Focus();
                        }
                    }
                    else
                    {
                        textBox3.Focus();
                        MessageBox.Show("Porfavor ingresa tu las semanas de trabajo");
                    }
                }
                else
                {
                    textBox2.Focus();
                    MessageBox.Show("Porfavor ingresa tu sueldo");
                }
            }
            else
            {
                textBox1.Focus();
                MessageBox.Show("Porfavor ingresa tu nombre");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public void calcular_salario()
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "")
            {
                if (comboBox1.Text == "directivo" || comboBox1.Text == "oficinista")
                {
                    sueldo_bruto = float.Parse(textBox2.Text) + complemento;
                    exencion = (float)(sueldo_bruto * 0.10);
                    impuesto = (float)((sueldo_bruto - exencion) * 0.33);
                    sueldo_bruto = sueldo_bruto - exencion - impuesto;
                    semanas_antiguedad = int.Parse(textBox3.Text);
                    cargo = comboBox1.Text; 
                }
                else
                {
                    sueldo_bruto = float.Parse(textBox2.Text);
                    exencion = (float)(sueldo_bruto * 0.10);
                    impuesto = (float)((sueldo_bruto - exencion) * 0.33);
                    sueldo_bruto = sueldo_bruto - exencion - impuesto;
                    semanas_antiguedad = int.Parse(textBox3.Text);
                    cargo = comboBox1.Text;
                }
                label6.Text = (textBox1.Text + "\nCargo: "+ cargo + "\nSalario: " + sueldo_bruto + "\nExencion: " + exencion + "\nImpuesto: " + impuesto + "\nSemanas Antiguedad: " + semanas_antiguedad);
                guar.Escribir(textBox1.Text + "\t: Cargo: " + cargo + "\t, Salario: " + sueldo_bruto + "\t, Exencion: " + exencion + "\t, Impuesto: " + impuesto + "\t, Semanas Antiguedad: " + semanas_antiguedad);

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "";
            }
            if (cont > N1)
            {
                button1.Enabled = false;
                timer1.Enabled = true;
            }
            else
            {
                label2.Text = "Trabajador " + cont;
                cont++;
            }

        }
    }
}
