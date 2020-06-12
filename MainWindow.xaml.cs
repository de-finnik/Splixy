using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace Vokabeltrainer
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
	/// Very nice application
    public partial class MainWindow : Window
    {
        List<Vokabel> query, register = new List<Vokabel>();
        Vokabel currentQuery;
        public MainWindow()
        {
            InitializeComponent();
            btnHome.Content = "\u2302";

            textBoxRegisterLang2.KeyUp += new KeyEventHandler(btnRegisterAdd_Click);
            textBoxLearnLang2.KeyDown += new KeyEventHandler(btnLearnCheck_Click);

            listVocs.KeyDown += new KeyEventHandler((sender, e) =>
            {
                if(e.Key == Key.Delete)
                {
                    register.RemoveAt(listVocs.SelectedIndex);
                    refreshRegisterList();
                }
            });
            listVocs.MouseDoubleClick += new MouseButtonEventHandler((sender, e) =>
            {
                textBoxRegisterLang1.Text = register[listVocs.SelectedIndex].lang1;
                textBoxRegisterLang2.Text = register[listVocs.SelectedIndex].lang2;
                register.RemoveAt(listVocs.SelectedIndex);
                refreshRegisterList();
            });


            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                BtnLernen_Click(null, null);
                StartQuery(args[1]);
            }
        }

        private void BtnLernen_Click(object sender, RoutedEventArgs e)
        {
            gridStartup.Visibility = Visibility.Hidden;
            gridLearn.Visibility = Visibility.Visible;
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            textBoxLearnLang2.Text = "";
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Vocabulary List|*.vocs";
            if (!(dialog.ShowDialog() ?? false))
                return;
            StartQuery(dialog.FileName);
        }

        private void BtnEintragen_Click(object sender, RoutedEventArgs e)
        {
            gridStartup.Visibility = Visibility.Hidden;
            gridRegister.Visibility = Visibility.Visible;
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            gridStartup.Visibility = Visibility.Visible;
            gridLearn.Visibility = Visibility.Hidden;
            gridRegister.Visibility = Visibility.Hidden;
        }

        
        private void btnRegisterAdd_Click(object sender, RoutedEventArgs e)
        {
            if (sender == textBoxRegisterLang2)
            {
                if (((KeyEventArgs)e).Key != Key.Enter)
                {
                    return;
                }
            }
            if (textBoxRegisterLang1.Text == "" || textBoxRegisterLang2.Text == "")
                return;
            Vokabel neu = new Vokabel(textBoxRegisterLang1.Text, textBoxRegisterLang2.Text);
            register.Add(neu);
            refreshRegisterList();
            textBoxRegisterLang1.Text = "";
            textBoxRegisterLang2.Text = "";
            textBoxRegisterLang1.Focus();
        }

        private void btnRegisterSave_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Vocabulary List|*.vocs";
            dialog.CheckFileExists = false;
            if (!(dialog.ShowDialog() ?? false))
                return;
            Unit.Save(register, dialog.FileName);
            register.Clear();
            refreshRegisterList();
            textBoxRegisterLang1.Text = "";
            textBoxRegisterLang2.Text = "";
            textBoxRegisterLang1.Focus();
        }

        private void BtnRegisterEdit_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Vocabulary List|*.vocs";
            if (!(dialog.ShowDialog() ?? false))
                return;
            register = Unit.Read(dialog.FileName);
            refreshRegisterList();
        }

        private void StartQuery(string path)
        {
            query = Unit.Read(path);
            QueryNextItem(true);
            textBoxLearnLang2.Focus();
        }

        private void QueryNextItem(bool removeOld)
        {
            if (currentQuery != null && removeOld)
            {
                query.Remove(currentQuery);
            }
            if(query.Count < 1)
            {
                MessageBox.Show("Fertig!");
                textBoxLearnLang1.Text = "";
                btnHome_Click(null, null);
                return;
            }
            int index;
            do
            {
                index = new Random().Next(query.Count);
            } while (query.Count > 1 && query[index] == currentQuery);
            currentQuery = query[index];
            textBoxLearnLang1.Text = currentQuery.lang1;

        }

        private void refreshRegisterList()
        {
            listVocs.Items.Clear();
            foreach (Vokabel item in register)
            {
                listVocs.Items.Add(item.lang1 + " - " + item.lang2);
            }
        }

        private void btnLearnCheck_Click(object sender, RoutedEventArgs e)
        {
            if (sender == textBoxLearnLang2)
            {
                if (((KeyEventArgs)e).Key != Key.Enter)
                {
                    return;
                }
            }
            if (query == null || query.Count == 0)
                return;
            bool correct = currentQuery.lang2 == textBoxLearnLang2.Text;
            if (correct)
            {
                MessageBox.Show("Richtig");
            }
            else
            {
                MessageBox.Show("Falsch: " + currentQuery.lang2);
            }
            QueryNextItem(correct);
            textBoxLearnLang2.Text = "";
            textBoxLearnLang2.Focus();
        }
    }
}
