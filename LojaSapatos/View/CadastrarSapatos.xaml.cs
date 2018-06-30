using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LojaSapatos.Model;

namespace LojaSapatos
{
    /// <summary>
    /// Lógica interna para CadastrarSapatos.xaml
    /// </summary>
    public partial class CadastrarSapatos : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string Property)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(
                    Property));
            }
        }

        private Sapatos _Sapatos = new Sapatos();

        public Sapatos SapatoSelecionado
        {
            get
            {
                return _Sapatos;
            }
            set
            {
                _Sapatos = value;
                this.NotifyPropertyChanged("SapatoSelecionado");
            }
        }

        public IList<Sapatos> Sapatos_ { get; set; }
        public CadastrarSapatos()
        {
            InitializeComponent();
            this.DataContext = this;

            FacadeSapato facade = new FacadeSapato();
            this.Sapatos_ = facade.ObterSapatos();

        }

        
        private void ButtonSalvar_Click(object sender, RoutedEventArgs e)
        {

            ModelContext ctx = new ModelContext();

            ctx.Sapatos.Add(SapatoSelecionado);
            ctx.SaveChanges();
            MessageBox.Show("Sapato Cadastrado Com Sucesso!!!");
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
