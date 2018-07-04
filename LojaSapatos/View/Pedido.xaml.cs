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
    /// Lógica interna para Pedido.xaml
    /// </summary>
    public partial class Pedido : Window, INotifyPropertyChanged
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

        public ItemPedido ItemPedidoSelecionado
        {
            get => _ItemPedidoSelecinado;
            set
            {
                _ItemPedidoSelecinado = value;
                this.NotifyPropertyChanged("ItemPedidoSelecionado");
            }
        }

        private ModelContext ctx = new ModelContext();
        private ItemPedido _ItemPedidoSelecinado;
        private ICollection<ItemPedido> _ItemPedido;

        public ICollection<ItemPedido> ItemPedido
        {
            get { return _ItemPedido; }
            set
            {
                _ItemPedido = value;
                this.NotifyPropertyChanged("ItemPedido");
            }
        }

        public Pedido()
        {
            InitializeComponent();
            this.ItemPedido = ctx.ItemPedido.ToList();


            this.ItemPedidoSelecionado = this.ItemPedido.FirstOrDefault();

            this.DataContext = this;
        }

        private void ItemPedidoDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (ItemPedido item in e.RemovedItems)
            {
                ctx.ItemPedido.Remove(item);
                ctx.SaveChanges();
            }
        }

        private void BT_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
