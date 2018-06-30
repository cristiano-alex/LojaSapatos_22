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
    /// Lógica interna para ListaClientes.xaml
    /// </summary>
    public partial class ListaClientes : Window, INotifyPropertyChanged
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
        public Cliente ClienteSelecionado
        {
            get => _ClienteSelecionado;
            set
            {
                _ClienteSelecionado = value;
                this.NotifyPropertyChanged("ClienteSelecionado");
            }
        }

        public ICollection<Cliente> Clientes
        {
            get { return _Clientes; }
            set
            {
                _Clientes = value;
                this.NotifyPropertyChanged("Clientes");
            }
        }
        public ListaClientes()
        {
            InitializeComponent();
            this.Clientes = ctx.Clientes.ToList();


            this.ClienteSelecionado = this.Clientes.FirstOrDefault();

            this.DataContext = this;
        }

        private ModelContext ctx = new ModelContext();
        private Cliente _ClienteSelecionado;
        private ICollection<Cliente> _Clientes;

        private void ClienteDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Cliente item in e.RemovedItems)
            {
                ctx.Clientes.Remove(item);
                ctx.SaveChanges();
            }
        }

        private void TB_Cancelar_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TB_Editar_button_Click(object sender, RoutedEventArgs e)
        {
            CadastroCliente cs = new CadastroCliente();
            ModelContext ctx = new ModelContext();
            Cliente Cl1 = ctx.Clientes.Find(ClienteSelecionado.Id_Cliente);
            cs.Tb_Nome_Cliente.Text = ClienteSelecionado.Cl_Nome;
            cs.Show();
        }
    }
}
