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
    /// Lógica interna para ListaProdutos.xaml
    /// </summary>
    public partial class ListaProdutos : Window, INotifyPropertyChanged
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

        public Sapatos SapatoSelecionado
        {
            get => _SapatoSelecionado;
            set
            {
                _SapatoSelecionado = value;
                this.NotifyPropertyChanged("SapatoSelecionado");
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

        public ListaProdutos()
        {
            InitializeComponent();
            this.Sapatos = ctx.Sapatos.ToList();


            this.SapatoSelecionado = this.Sapatos.FirstOrDefault();

            this.DataContext = this;
        }
        private ModelContext ctx = new ModelContext();
        private Sapatos _SapatoSelecionado;
        private ICollection<Sapatos> _Sapatos;

        private void SapatosDataGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Sapatos item in e.RemovedItems)
            {
                ctx.Sapatos.Remove(item);
                ctx.SaveChanges();
            }
        }

        private void BT_Editar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        

        private void BT_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
