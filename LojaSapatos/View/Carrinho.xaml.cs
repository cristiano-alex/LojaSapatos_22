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

namespace LojaSapatos.View
{
    /// <summary>
    /// Lógica interna para Carrinho.xaml
    /// </summary>
    public partial class Carrinho : Window, INotifyPropertyChanged
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

        private ModelContext ctx = new ModelContext();
        private ICollection<Cliente> _Clientes;
        private ICollection<Sapatos> _Sapatos;
        private Pedido _PedidoSelecinado;

        public Pedido PedidoSelecinado
        {
            get { return _PedidoSelecinado; }
            set
            {
                _PedidoSelecinado = value;
                this.NotifyPropertyChanged("ItemPedido");
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

        public ICollection<Sapatos> Sapatos
        {
            get { return _Sapatos; }
            set
            {
                _Sapatos = value;
                this.NotifyPropertyChanged("Sapatos");
            }
        }

        public Carrinho()
        {
            InitializeComponent();
            this.Sapatos = ctx.Sapatos.ToList();
            this.Clientes = ctx.Clientes.ToList();

            


            

            this.DataContext = this;
        }

        private void TB_Confirmar_button_Click(object sender, RoutedEventArgs e)
        {
            ctx.Pedido.Add(this.PedidoSelecinado);
            MessageBox.Show("Compra Efetuada");
        }
    }
}
