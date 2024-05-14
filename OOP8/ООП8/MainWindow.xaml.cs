using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
using ООП8.Entities;

namespace ООП8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private OpenFileDialog openFileDialog;
        public SqlConnection conn;

        public MainWindow()
        {
            InitializeComponent();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            conn.Open();
            dataView.Items.Clear();

        }

        private void AddOwner_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("begin tran INSERT INTO Owner VALUES (@Name, @Surname, @Fathername, @BirthDate, @PassSeries, @PassNum, @ImageData); commit tran;", conn);
                if (ValidateOwnerData() && ValidateBirthDate(BirthDate))
                {
                    command.Parameters.AddWithValue("@Name", Name.Text);
                    command.Parameters.AddWithValue("@Surname", Surname.Text);
                    command.Parameters.AddWithValue("@Fathername", Fathername.Text);
                    command.Parameters.AddWithValue("@BirthDate", BirthDate.Text);
                    command.Parameters.AddWithValue("@PassSeries", PassSeries.Text);
                    command.Parameters.AddWithValue("@PassNum", PassNum.Text);
                    command.Parameters.AddWithValue("@ImageData", ConvertImageToBytes(preview.Source));
                    command.ExecuteNonQuery();
                    ClearOwnerData();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Владелец с ФИО  уже существует!");
            }
            
        }

        private void AddCheck_Click(object sender, RoutedEventArgs e)
        {

                SqlCommand command = new SqlCommand("begin tran INSERT INTO ClientCheck VALUES (@Number , @CheckType , @Balance , @Open_Date, @BankServices , @Client_Name); commit tran;",conn);
                if (ValidateCheckData()) {
                    command.Parameters.AddWithValue("@Number", Number.Text);
                    command.Parameters.AddWithValue("@CheckType", Type.Text);
                    command.Parameters.AddWithValue("@Balance", Balance.Text);
                    command.Parameters.AddWithValue("@Open_Date", OpenDate.Text);
                    command.Parameters.AddWithValue("@BankServices", Sms.IsChecked == true ? Sms.Content : (Banking.IsChecked == true ? Banking.Content : noServOsn.Content));
                    command.Parameters.AddWithValue("@Client_Name", Client_Name.Text);
                    command.ExecuteNonQuery();
                    ClearCheckData();
                }

  
        }

        private void addImage_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            try
            {
                preview.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
            }
            catch
            {
                MessageBox.Show("Неверный формат файла!");
            }
        }


        private void DelOwner(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("DeleteOwner", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", NameDel.Text);
                command.ExecuteNonQuery();
                dataView.Items.Refresh();
            }
            catch (SqlException)
            {
                MessageBox.Show("Отсутвуют данные!");
            }
            ClearOwnerData();
        }
        private void DelCheck(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand($"begin tran DELETE FROM ClientCheck where ClientCheck.Number = {NumberDel.Text}; commit tran;",conn);
                command.ExecuteNonQuery();
                MessageBox.Show("Счёт удален!");

            }
            catch (SqlException)
            {
                MessageBox.Show("Отсутвуют данные!");
            }
            ClearCheckData();
        }


        /*-----------------Настройка DataGrid---------------*/


        public void CheckGridView()
        {
            dataView.AutoGenerateColumns = false;
            dataView.Columns.Clear();
            dataView.Columns.Add(new DataGridTextColumn { Header = "Number", Binding = new Binding("Number") });
            dataView.Columns.Add(new DataGridTextColumn { Header = "CheckType", Binding = new Binding("CheckType") });
            dataView.Columns.Add(new DataGridTextColumn { Header = "Balance", Binding = new Binding("Balance") });
            dataView.Columns.Add(new DataGridTextColumn { Header = "OpenDate", Binding = new Binding("Open_Date") });
            dataView.Columns.Add(new DataGridTextColumn { Header = "BankServices", Binding = new Binding("BankServices") });
            dataView.Columns.Add(new DataGridTextColumn { Header = "Client_Name", Binding = new Binding("Client_Name") });
            dataView.Columns.Add(new DataGridTextColumn { Header = "Surname", Binding = new Binding("Surname") });
            dataView.Columns.Add(new DataGridTextColumn { Header = "PassportSeries", Binding = new Binding("PassportSeries") });
            dataView.Columns.Add(new DataGridTextColumn { Header = "PassportNumber", Binding = new Binding("PassportNumber") });

        }

        public void OwnerGridView()
        {
            dataView.AutoGenerateColumns = false;
            dataView.Columns.Clear();
            dataView.Columns.Add(new DataGridTextColumn { Header = "Name", Binding = new Binding("Name") });
            dataView.Columns.Add(new DataGridTextColumn { Header = "Surname", Binding = new Binding("Surname") });
            dataView.Columns.Add(new DataGridTextColumn { Header = "Fathername", Binding = new Binding("Fathername") });
            dataView.Columns.Add(new DataGridTextColumn { Header = "Birth", Binding = new Binding("Birth") });
            dataView.Columns.Add(new DataGridTextColumn { Header = "PassportSeries", Binding = new Binding("PassportSeries") });
            dataView.Columns.Add(new DataGridTextColumn { Header = "PassportNumber", Binding = new Binding("PassportNumber") });
            dataView.Columns.Add(new DataGridTextColumn { Header = "Person_Photo", Binding = new Binding("Person_Photo") });

        }


        /*-----------------Конвертация изображения---------------*/


        private byte[] ConvertImageToBytes(ImageSource imageSource)
        {
            if (imageSource == null)
            {
                return null;
            }

            BitmapImage bitmapImage = (BitmapImage)imageSource;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                encoder.Save(memoryStream);
                return memoryStream.ToArray();
            }
        }


        /*-----------------Полученcие всех---------------*/



        private void GetAllOwners_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OwnerGridView();
                DataTable data = new DataTable();
                SqlCommand command = new SqlCommand("begin tran SELECT * FROM Owner; commit tran;",conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                dataView.ItemsSource = data.DefaultView;
            }
            catch (SqlException)
            {
                MessageBox.Show("Данные или Таблица отсутствует!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CheckGridView();
            try
            {
                DataTable data = new DataTable();
                SqlCommand command = new SqlCommand("begin tran SELECT * FROM ALL_CHECKS; commit tran;", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                dataView.ItemsSource = data.DefaultView;
            }
            catch (SqlException)
            {
                MessageBox.Show("Данные или Таблица отсутствует!");
            }
        }


        /*-----------------Валидация---------------*/


        public bool ValidateOwnerData()
        {
            if (string.IsNullOrEmpty(Name.Text) ||
                string.IsNullOrEmpty(Surname.Text) ||
                string.IsNullOrEmpty(BirthDate.Text) ||
                string.IsNullOrEmpty(PassSeries.Text) ||
                string.IsNullOrEmpty(PassNum.Text)
                )
            {
                MessageBox.Show("Введены не все данные!");
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ValidateCheckData()
        {
            if (string.IsNullOrEmpty(Number.Text) ||
                string.IsNullOrEmpty(Type.Text) ||
                string.IsNullOrEmpty(OpenDate.Text) ||
                string.IsNullOrEmpty(Client_Name.Text) ||
                string.IsNullOrEmpty(Balance.Text)
                )
            {
                MessageBox.Show("Введены не все данные!");
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ClearOwnerData()
        {
            Name.Clear();
            Surname.Clear();
            Fathername.Clear();
            BirthDate.SelectedDate = DateTime.Now;
            PassNum.Clear();
            PassSeries.SelectedIndex = -1;
            preview.Source = null;
            NameDel.Clear();
        }


        public void ClearCheckData()
        {
            Number.Clear();
            Type.SelectedIndex = -1;
            OpenDate.SelectedDate = DateTime.Now;
            Client_Name.Clear();
            Balance.Clear();
            NumberDel.Clear();
        }

        private void CheckFO(object sender, TextCompositionEventArgs e)
        {
            Name.MaxLength = 15;
            Surname.MaxLength = 15;
            Fathername.MaxLength = 15;
            if (Char.IsDigit(e.Text, 0) && e.Text != "-") e.Handled = true;
        }

        private void ValidatePassNum(object sender, TextCompositionEventArgs e)
        {
            PassNumUpd.MaxLength = 7;   
            PassNum.MaxLength = 7;
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;

        }

        private void ValidateCheckNumber(object sender, TextCompositionEventArgs e)
        {
            Number.MaxLength = 15;
            NumberDel.MaxLength = 15;
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void ValidateBalance(object sender, TextCompositionEventArgs e)
        {
            Balance.MaxLength = 15;
            if (!Char.IsDigit(e.Text, 0) && e.Text != "." && e.Text != "-") e.Handled = true;
        }


        /*-----------------Сортировки---------------*/

        // Owner

        private void SortOwnerByName_Click(object sender, RoutedEventArgs e)
        {
            OwnerGridView();
            try
            {
                DataTable data = new DataTable();
                SqlCommand command = new SqlCommand("begin tran SELECT * FROM Owner ORDER BY Owner.Name; commit tran;",conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                dataView.ItemsSource = data.DefaultView;
            }
            catch(SqlException)
            {
                MessageBox.Show("Нет данных!");
            }
        }

        private void SortBySeries_Click(object sender, RoutedEventArgs e)
        {
            OwnerGridView();
            try
            {
                DataTable data = new DataTable();
                SqlCommand command = new SqlCommand("begin tran SELECT * FROM Owner ORDER BY Owner.PassportSeries; commit tran;", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                dataView.ItemsSource = data.DefaultView;
            }
            catch (SqlException)
            {
                MessageBox.Show("Нет данных!");
            }
        }

        private void SortOwnerByBirth_Click(object sender, RoutedEventArgs e)
        {
            OwnerGridView();
            try
            {
                DataTable data = new DataTable();
                SqlCommand command = new SqlCommand("begin tran SELECT * FROM Owner ORDER BY Owner.Birth; commit tran;", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                dataView.ItemsSource = data.DefaultView;
            }
            catch (SqlException)
            {
                MessageBox.Show("Нет данных!");
            }
        }

        private void SortOwnerByNumPass_Click(object sender, RoutedEventArgs e)
        {
            OwnerGridView();
            try
            {
                DataTable data = new DataTable();
                SqlCommand command = new SqlCommand("begin tran SELECT * FROM Owner ORDER BY Owner.PassportNumber; commit tran;", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                dataView.ItemsSource = data.DefaultView;
            }
            catch (SqlException)
            {
                MessageBox.Show("Нет данных!");
            }
        }

        // Check

        private void SortCheckByDate_Click(object sender, RoutedEventArgs e)
        {
            CheckGridView();
            try
            {
                DataTable data = new DataTable();
                SqlCommand command = new SqlCommand("begin tran SELECT * FROM ClientCheck ORDER BY ClientCheck.Open_Date; commit tran;", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                dataView.ItemsSource = data.DefaultView;
            }
            catch (SqlException)
            {
                MessageBox.Show("Нет данных!");
            }
        }

        private void SortCheckByNumber_Click(object sender, RoutedEventArgs e)
        {
            CheckGridView();
            try
            {
                DataTable data = new DataTable();
                SqlCommand command = new SqlCommand("begin tran SELECT * FROM ClientCheck ORDER BY ClientCheck.Number; commit tran;", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                dataView.ItemsSource = data.DefaultView;
            }
            catch (SqlException)
            {
                MessageBox.Show("Нет данных!");
            }
        }

        private void SortCheckByType_Click(object sender, RoutedEventArgs e)
        {
            CheckGridView();
            try
            {
                DataTable data = new DataTable();
                SqlCommand command = new SqlCommand("begin tran SELECT * FROM ClientCheck ORDER BY ClientCheck.CheckType; commit tran;", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                dataView.ItemsSource = data.DefaultView;
            }
            catch (SqlException)
            {
                MessageBox.Show("Нет данных!");
            }
        }

        private void SortCheckByBalance_Click(object sender, RoutedEventArgs e)
        {
            CheckGridView();
            try
            {
                DataTable data = new DataTable();
                SqlCommand command = new SqlCommand("begin tran SELECT * FROM ClientCheck ORDER BY ClientCheck.Balance; commit tran;", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                dataView.ItemsSource = data.DefaultView;
            }
            catch (SqlException)
            {
                MessageBox.Show("Нет данных!");
            }
        }


        /*-----------------Поиск---------------*/
        private void FindBySurname_Click(object sender, RoutedEventArgs e)
        {
            OwnerGridView();
            try
            {
                DataTable data = new DataTable();
                SqlCommand command = new SqlCommand($"begin tran SELECT * FROM Owner WHERE Owner.Surname like '{SurnameFind.Text}%'; commit tran;", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                dataView.ItemsSource = data.DefaultView;
                SurnameFind.Clear();
            }
            catch (SqlException)
            {
                MessageBox.Show("Нет данных!");
            }
        }

        private void FindByClientName_Click(object sender, RoutedEventArgs e)
        {
            CheckGridView();
            try
            {
                DataTable data = new DataTable();
                SqlCommand command = new SqlCommand($"begin tran SELECT * FROM ClientCheck WHERE ClientCheck.Client_Name like '{NameFind.Text}%'; commit tran;", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                dataView.ItemsSource = data.DefaultView;
                NameFind.Clear();
            }
            catch (SqlException)
            {
                MessageBox.Show("Нет данных!");
            }
        }


        // UPDAATING OWNER

        private void addImageUpd_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            try
            {
                previewUpd.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
            }
            catch
            {
                MessageBox.Show("Неверный формат файла!");
            }
        }

        private void updateOwner_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateBirthDate(BirthUpd))
                {
                    SqlCommand command = new SqlCommand("UpdateOwner", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", NameUpd.Text);
                    command.Parameters.AddWithValue("@Surname", SurnameUpd.Text);
                    command.Parameters.AddWithValue("@Fathername", FathernameUpd.Text);
                    command.Parameters.AddWithValue("@Birth", BirthUpd.Text);
                    command.Parameters.AddWithValue("@PassportSeries", PassSeriesUpd.Text);
                    command.Parameters.AddWithValue("@PassportNumber", PassNumUpd.Text);
                    command.Parameters.AddWithValue("@Person_Photo", ConvertImageToBytes(previewUpd.Source));
                    command.ExecuteNonQuery();
                    ClearUpdateOwnerData();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Неверный формат !");
            }

        }

        private void updateCheck_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("UpdateClientCheck", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Number", NumberUpd.Text);
                command.Parameters.AddWithValue("@CheckType", TypeUpd.Text);
                command.Parameters.AddWithValue("@Balance", BalanceUpd.Text);
                command.Parameters.AddWithValue("@Open_Date", OpenDateUpd.Text);
                command.Parameters.AddWithValue("@BankServices", SmsUpd.IsChecked == true ? SmsUpd.Content : (BankingUpd.IsChecked == true ? BankingUpd.Content : noServ.Content));
                command.Parameters.AddWithValue("@Client_Name", Client_NameUpd.Text);
                command.ExecuteNonQuery();
                ClearUpdatedCheckData();
            }
            catch(SqlException)
            {
                MessageBox.Show("Неверный формат !");

            }
        }

        private void ClearUpdatedCheckData()
        {
            NumberUpd.Clear();
            TypeUpd.SelectedIndex = -1;
            BalanceUpd.Clear();
            OpenDateUpd.SelectedDate = DateTime.Now;
            noServ.IsChecked = true;
            SmsUpd.IsChecked = false;
            BankingUpd.IsChecked = false;
            Client_NameUpd.Clear();
        }

        private void ClearUpdateOwnerData()
        {
            NameUpd.Clear();
            SurnameUpd.Clear();
            FathernameUpd.Clear();
            BirthUpd.SelectedDate = DateTime.Now;
            PassNumUpd.Clear();
            PassSeriesUpd.SelectedIndex = -1;
            previewUpd.Source = null;
        }

        private bool ValidateBirthDate(DatePicker date)
        {
            DateTime? birthDate = date.SelectedDate;
            if (!birthDate.HasValue)
            {
                MessageBox.Show("Пожалуйста, выберите дату рождения.");
                return false;
            }
            else if (birthDate.Value > DateTime.Now)
            {
                MessageBox.Show("Дата рождения не может быть в будущем!");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ValidateOpenDate(DatePicker date,DateTime? birth)
        {
            DateTime? openDate = date.SelectedDate;
            if (!openDate.HasValue)
            {
                MessageBox.Show("Пожалуйста, выберите дату рождения.");
                return false;
            }
            else if (openDate.Value < birth.Value)
            {
                MessageBox.Show("Дата открытия не может быть до рождения!");
                return false;
            }
            else
            {
                return true;
            }
        }

        private DateTime? GetBirthOfClient(string _clientName)
        {
            try
            {
                string query = "begin tran SELECT O.Birth FROM ClientCheck C INNER JOIN Owner O ON C.Client_Name = O.Name WHERE C.Client_Name = @ClientName; commit tran;";

                SqlCommand command = new SqlCommand(query, conn);

                command.Parameters.AddWithValue("@ClientName", _clientName);

                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDateTime(result);
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Произошла ошибка SQL: {ex.Message}");
                return null;
            }
        }

        private void tabNext_Click(object sender, RoutedEventArgs e)
        {
            if(allTabs.SelectedIndex == allTabs.Items.Count - 1)
            {
                allTabs.SelectedIndex = 0;
            }
            else
            {
                allTabs.SelectedIndex++;
            }
        }

        private void tabBack_Click(object sender, RoutedEventArgs e)
        {
            if (allTabs.SelectedIndex == 0)
            {
                allTabs.SelectedIndex = allTabs.Items.Count - 1;
            }
            else
            {
                allTabs.SelectedIndex--;
            }
        }
    }
}
