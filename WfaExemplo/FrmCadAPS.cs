﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfaExemplo
{
    public partial class FrmCadAPS : Form
    {
        public FrmCadAPS()
        {
            InitializeComponent();
        }

        private void cmbForma_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbForma.Text)
            {
                case "Quadrado":
                    SelecionarQuadrado();
                    LimparCampos();
                    break;
                case "Triangulo":
                    SelecionarTriangulo();
                    LimparCampos();
                    break;
                case "Circunferencia":
                    SelecionarCircunferencia();
                    LimparCampos();
                    break;
                case "Retangulo":
                    SelecionarRetangulo();
                    LimparCampos();
                    break;
                default:
                    break;
            }
        }

        private void LimparCampos()
        {
            txtBase.Text = "";
            txtAltura.Text = "";
            txtRaio.Text = "";
        }

        private void SelecionarQuadrado()
        {
            ExibirBase(true);
            ExibirAltura(false);
            lblRaio.Visible = txtRaio.Visible = false;
            cmbTriangulo.Visible = false;
        }
        private void SelecionarCircunferencia()
        {
            ExibirBase(false);
            ExibirAltura(false);
            ExibirRaio(true);
            cmbTriangulo.Visible = false;
        }
        private void SelecionarRetangulo()
        {
            ExibirBase(true);
            ExibirAltura(true);
            lblRaio.Visible = txtRaio.Visible = false;
            cmbTriangulo.Visible = false;
        }

        private void ExibirAltura(bool visivel)
        {
            lblAltura.Visible = txtAltura.Visible = visivel;
        }

        private void ExibirBase(bool visivel)
        {
            lblBase.Visible = txtBase.Visible = visivel;
        }
        private void ExibirRaio(bool visivel)
        {
            lblRaio.Visible = txtRaio.Visible = visivel;
        }

        private void SelecionarTriangulo()
        {
            cmbTriangulo.Visible = cmbForma.Text.Equals("Triangulo");
            cmbTriangulo.Text = "";
            lblRaio.Visible = txtRaio.Visible = false;
            ExibirBase(false);
            ExibirAltura(false);
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            switch (cmbForma.Text)
            {
                case "Quadrado":
                    btnQuadrado();
                    break;
                case "Triangulo":
                    cmbtriangulo();
                    break;
                case "Circunferencia":
                    btnCircunferencia();
                    break;
                case "Retangulo":
                    btnRetangulo();
                    break;
                default:
                    break;
            }
        }

        private void cmbtriangulo()
        {
            if (cmbForma.Text.Equals("Triangulo"))
            {
                switch (cmbTriangulo.Text)
                {
                    case "Reto":
                        cmbReto();
                        break;
                    case "Equilatero":
                        cmbEquilatero();
                        break;
                    case "Isosceles":
                        cmbIsosceles();
                        break;
                }
            }
        }

        private void cmbReto()
        {
            try
            {
                FormaGeometrica trianguloR = new TR()
                {
                    BaseT = Convert.ToDouble(txtBase.Text),
                    AlturaT = Convert.ToDouble(txtAltura.Text)
                };
                cmbObjetos.Items.Add(trianguloR);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Atenção:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbEquilatero()
        {
            try
            {
                FormaGeometrica trianguloE = new TE()
                {
                    Base = Convert.ToDouble(txtBase.Text),
                };
                cmbObjetos.Items.Add(trianguloE);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Atenção:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbIsosceles()
        {
            try
            {
                FormaGeometrica trianguloI = new TI()
                {
                    Base = Convert.ToDouble(txtBase.Text),
                    Altura = Convert.ToDouble(txtAltura.Text),
                };
                cmbObjetos.Items.Add(trianguloI);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Atenção:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuadrado()
        {
            try
            {
                if (cmbForma.Text.Equals("Quadrado"))
                {
                    FormaGeometrica quadrado = new Quadrado()
                    {
                        Base = Convert.ToDouble(txtBase.Text)
                    };
                    cmbObjetos.Items.Add(quadrado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Atenção:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnCircunferencia()
        {
            try
            {
                if (cmbForma.Text.Equals("Circunferencia"))
                {
                    FormaGeometrica circunferencia = new Circunferencia()
                    {
                        Raio = Convert.ToDouble(txtRaio.Text)
                    };
                    cmbObjetos.Items.Add(circunferencia);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Atenção:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRetangulo()
        {
            try
            {
                if (cmbForma.Text.Equals("Retangulo"))
                {
                    FormaGeometrica retangulo = new Retangulo()
                    {
                        Base = Convert.ToDouble(txtBase.Text),
                        Altura = Convert.ToDouble(txtAltura.Text)
                    };
                    cmbObjetos.Items.Add(retangulo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro:\n" + ex.Message, "Atenção:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbObjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormaGeometrica obj = cmbObjetos.SelectedItem as FormaGeometrica;
            txtArea.Text = obj.CalcularArea().ToString();
            txtPerimetro.Text = obj.CalcularPerimetro().ToString();
        }

        private void cmbTriangulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTriangulo.Text)
            {
                case "Equilatero":
                    ExibirAltura(false); ExibirBase(true); LimparCampos(); break; 
                case "Isosceles":
                    ExibirAltura(true); ExibirBase(true); LimparCampos(); break;
                case "Reto":
                    ExibirAltura(true); ExibirBase(true); LimparCampos(); break;
            }
        }

        private void FrmCadAPS_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja mesmo sair?", "Atenção:", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}