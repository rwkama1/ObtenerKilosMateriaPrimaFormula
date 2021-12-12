using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Testing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvDatos.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDatos.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDatos.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            List<LineaDocumento> listalineas = lineasDocumento();
            CDocumento doc = new CDocumento(listalineas, new DateTime(2021, 11, 01));
            foreach (LineaDocumento lineaDocumento in doc.lineadoc)
            {
               dgvDatos.Rows.Add($"Producto: {lineaDocumento.producto.codigo} ", "Formula: " + lineaDocumento.formula.codigo, "Kilos: " + lineaDocumento.kilos);
              
                foreach (Compuesto compuesto in lineaDocumento.formula.listacompuesto)
                {

                    dgvDatos.Rows.Add(lineaDocumento.formula.codigo, compuesto.MateriaPrima.codigonombre, compuesto.porcentaje, lineaDocumento.kilos);



                }


                int indice = dgvDatos.Rows.Add("", "", "", "asd");
                dgvDatos.Rows[indice].DefaultCellStyle.Font = new Font(dgvDatos.Font, FontStyle.Bold);
            }



        }
        private List<LineaDocumento> lineasDocumento()
        {
            Producto producto1 = new Producto(64454);
            Producto producto2 = new Producto(755645);
            Producto producto3 = new Producto(879978);
            Producto producto4 = new Producto(756989);
            Producto producto5 = new Producto(685456);

            CMateriaPrima materiaprima = new CMateriaPrima("6554 MateriaPrima1");
            CMateriaPrima materiaprima2 = new CMateriaPrima("752 MateriaPrima2");
            CMateriaPrima materiaprima3 = new CMateriaPrima("568 MateriaPrima3");
            CMateriaPrima materiaprima4 = new CMateriaPrima("742 MateriaPrima4");
            CMateriaPrima materiaprima5 = new CMateriaPrima("567 MateriaPrima5");
            CMateriaPrima materiaprima6 = new CMateriaPrima("415 MateriaPrima6");
            CMateriaPrima materiaprima7 = new CMateriaPrima("568 MateriaPrima7");
            CMateriaPrima materiaprima8 = new CMateriaPrima("875 MateriaPrima8");
            CMateriaPrima materiaprima9 = new CMateriaPrima("985 MateriaPrima9");
            CMateriaPrima materiaprima10 = new CMateriaPrima("852 MateriaPrima10");


            List<Compuesto> listacompuesto1 = new List<Compuesto>
            {
             new Compuesto(materiaprima,90),
            new Compuesto(materiaprima2, 10)
            };
            List<Compuesto> listacompuesto2 = new List<Compuesto>
            {
             new Compuesto(materiaprima3,80),
            new Compuesto(materiaprima4, 20)
            };
            List<Compuesto> listacompuesto3 = new List<Compuesto>
            {
             new Compuesto(materiaprima5,70),
            new Compuesto(materiaprima6, 30)
            };
            List<Compuesto> listacompuesto4 = new List<Compuesto>
            {
             new Compuesto(materiaprima7,60),
            new Compuesto(materiaprima8, 40)
            };
            List<Compuesto> listacompuesto5 = new List<Compuesto>
            {
             new Compuesto(materiaprima9,50),
            new Compuesto(materiaprima10, 50)
            };

            CFormula formula1 = new CFormula(485, listacompuesto1);
            CFormula formula2 = new CFormula(495, listacompuesto2);
            CFormula formula3 = new CFormula(458, listacompuesto3);
            CFormula formula4 = new CFormula(526, listacompuesto4);
            CFormula formula5 = new CFormula(885, listacompuesto5);

            LineaDocumento lineaDocumento = new LineaDocumento(formula1, producto1, 10000);
            LineaDocumento lineaDocumento2 = new LineaDocumento(formula2, producto2, 20000);
            LineaDocumento lineaDocumento3 = new LineaDocumento(formula3, producto3, 30000);
            LineaDocumento lineaDocumento4 = new LineaDocumento(formula4, producto4, 40000);
            LineaDocumento lineaDocumento5 = new LineaDocumento(formula5, producto5, 50000);

            List<LineaDocumento> listalineasdocumento = new List<LineaDocumento>
            {
                lineaDocumento,lineaDocumento2,lineaDocumento3,lineaDocumento4,lineaDocumento5
            };

            return listalineasdocumento;

        }

        struct Producto
        {
            public int codigo;


            public Producto(int codigo)
            {
                this.codigo = codigo;

            }

        }
        struct CMateriaPrima
        {
            public string codigonombre;
            public CMateriaPrima(string codigonombre)
            {
                this.codigonombre = codigonombre;

            }

        }
        struct Compuesto
        {

            public CMateriaPrima MateriaPrima;
            public int porcentaje;

            public Compuesto(CMateriaPrima materiaPrima, int porcentaje)
            {
                this.MateriaPrima = materiaPrima;
                this.porcentaje = porcentaje;
            }
        }
        struct CFormula
        {
            public int codigo;
            public List<Compuesto> listacompuesto;

            public CFormula(int codigo, List<Compuesto> listacompuesto)
            {
                this.codigo = codigo;
                this.listacompuesto = listacompuesto;
            }
        }

        struct LineaDocumento
        {
            public CFormula formula;
            public Producto producto;
            public int kilos;

            public LineaDocumento(CFormula formula, Producto producto, int kilos)
            {
                this.formula = formula;
                this.producto = producto;
                this.kilos = kilos;
            }
        }
        struct CDocumento
        {

            public List<LineaDocumento> lineadoc;

            public DateTime fecha;

            public CDocumento(List<LineaDocumento> lineadoc, DateTime fecha)
            {
                this.lineadoc = lineadoc;
                this.fecha = fecha;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Validating(object sender, CancelEventArgs e)
        {

        }


    }
}
