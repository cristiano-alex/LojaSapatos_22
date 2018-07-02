using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LojaSapatos.View;

namespace LojaSapatos
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       



        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            CadastrarSapatos cadastrarSapatos = new CadastrarSapatos();
            cadastrarSapatos.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            
            CadastroCliente cadastroCliente = new CadastroCliente();
            cadastroCliente.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            ListaClientes listaClientes = new ListaClientes();
            listaClientes.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            ListaProdutos listaProdutos = new ListaProdutos();
            listaProdutos.Show();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            Pedido pedido = new Pedido();
            pedido.Show();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            Carrinho carrinho = new Carrinho();
            carrinho.Show();
        }
    }
}
