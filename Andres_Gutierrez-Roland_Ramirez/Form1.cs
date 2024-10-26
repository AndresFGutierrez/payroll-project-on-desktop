using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//Se desea desarrollar un software a una compañía que permita almacenar la nómina con los siguientes datos
//de cada empleado:
//• Nombre.
//• Nº de empleado. Cargado automáticamente al ingresarlo
//• Nivel (manual, cualificado, oficinista o directivo). Se debe usar un comboBox para la selección
//• Sueldo bruto.
//• Exención de impuesto. //Vamos a ponerlo en 10%
//• Nº de semanas de antigüedad en la empresa.
//Si el nivel es de oficinista o directivo lleva un complemento en el sueldo. Este complemento es una cantidad
//constante igual para todos. Los datos ingresados se emplearán para imprimir los recibos de las nóminas.
//El sueldo bruto total que cobran es Sueldo bruto + Complemento.
//El impuesto se deduce según la fórmula: (sueldo bruto total – exención) *0,33.
//Escribir un programa que permita, mediante un menú, realizar las operaciones
//Nota: esta información se visualiza con un timer al finalizar el ingreso de la información de cada empleado
//siguientes:

//• Utilizar un centinela que indique el fin del ingreso de información.
//• Mostrar todos los resultados de los trabajadores utilizando un Label y de forma ordenada
//alfabéticamente por nombres
//• En cualquier instante se puede consultar la información de un empleado.
namespace Andres_Gutierrez_Roland_Ramirez
{
    public partial class Form1 : Form
    {
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Form2 f2 = new Form2(int.Parse(textBox1.Text));
                f2.Show();
                this.Hide(); //oculta el form
            }
            else
            {
                MessageBox.Show("No se permite el campo vacio");
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int number) || number < 1 || number > 200000000)
            {
                MessageBox.Show("Solo se permiten numeros \n No se permiten negativos \n No se permite el campo vacio");
                textBox1.Text = "";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBox1.Text != "")
                {
                    Form2 f2 = new Form2(int.Parse(textBox1.Text));
                    f2.Show();
                    this.Hide(); //oculta el form
                }
                else
                {
                    MessageBox.Show("No se permite el campo vacio");
                }
            }
            
        }
    }
}
