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
    /// Lógica interna para CadastroCliente.xaml
    /// </summary>
    public partial class CadastroCliente : Window, INotifyPropertyChanged
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

        private Cliente _Cliente = new Cliente();
        public Cliente ClienteSelecionado
        {
            get
            {
                return _Cliente;
            }
            set
            {
                _Cliente = value;
                this.NotifyPropertyChanged("ClienteSelecionado");
            }
        }

        public IList<Cliente> Clientes { get; set; }
        
        public CadastroCliente()
        {
            InitializeComponent();
            this.DataContext = this;


            FacadeClientes facade = new FacadeClientes();
            this.Clientes = facade.ObterCliente();

            
        }

       

        private void BT_Salvar_Click(object sender, RoutedEventArgs e)
        {
            ModelContext ctx = new ModelContext();
            

            ctx.Clientes.Add(ClienteSelecionado);
            ctx.SaveChanges();
            MessageBox.Show("Cliente Cadastrado Com Sucesso!!!");
        }

        private void BT_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
