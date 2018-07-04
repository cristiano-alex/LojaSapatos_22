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
    /// Lógica interna para SelecinarPedido.xaml
    /// </summary>
    public partial class SelecinarPedido : Window, INotifyPropertyChanged
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
            get => _ItemPedido;
            set
            {
                _ItemPedido = value;
                this.NotifyPropertyChanged("ItemPedidoSelecionado");
            }
        }
        private ModelContext ctx = new ModelContext();
        private ItemPedido _ItemPedido = new ItemPedido();
        public IList<ItemPedido> ItemPedido { get; set; }
        private ICollection<Sapatos> _Sapatos;

        
        public ICollection<Sapatos> Sapatos
        {
            get { return _Sapatos; }
            set
            {
                _Sapatos = value;
                this.NotifyPropertyChanged("Sapatos");
            }
        }

        public SelecinarPedido()
        {
            InitializeComponent();

            this.DataContext = this;

            this.ItemPedido = ctx.ItemPedido.ToList();
            this.Sapatos = ctx.Sapatos.ToList();
            
            




        }

        private void TB_Confirmar_button_Click(object sender, RoutedEventArgs e)
        {
            ctx.ItemPedido.Add(ItemPedidoSelecionado);
            ctx.SaveChanges();

            MessageBox.Show("Pedido Cadastrado Com Sucesso!!!");
        }
    }
}
