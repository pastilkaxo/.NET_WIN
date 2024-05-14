﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
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

namespace ООП9
{
    public partial class MainWindow : Window
    {
        BankContext db;
        Owner owner;
        ClientCheck check;
        public MainWindow()
        {
            InitializeComponent();
            db = new BankContext();
            db.Owners.Load();
            dataView.ItemsSource = db.Owners.Local.ToBindingList();
        }

        private void ClearOwner()
        {
            Name.Clear();
            Surname.Clear();
            Fathername.Clear();
            Birth.SelectedDate = DateTime.Now;
            PassSeries.SelectedIndex = -1;
            PassNum.Clear();
            NewName.Clear();
            NewSurname.Clear();
            NewFathername.Clear();
            NewBirth.SelectedDate = DateTime.Now;
            NewPassSeries.SelectedIndex = -1;
            NewPassNum.Clear();
            PrevOwner.Clear();


        }
        private void ClearCheck()
        {
            Type.SelectedIndex = -1;
            BalanceValue.Clear();
            Client.Clear();
            NewType.SelectedIndex = -1;
            NewBalance.Clear();
            NewClient.Clear();
        }


        private void ValidatePassNumber(object sender, TextCompositionEventArgs e)
        {
            NewPassNum.MaxLength = 7;
            PassNum.MaxLength = 7;
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        public bool ValidateOwnerData()
        {
            if (string.IsNullOrEmpty(Name.Text) ||
                string.IsNullOrEmpty(Surname.Text) ||
                string.IsNullOrEmpty(Birth.Text) ||
                string.IsNullOrEmpty(PassSeries.Text) ||
                string.IsNullOrEmpty(PassNum.Text)
                )
            {
                MessageBox.Show("Введены не все данные!");
                return false;
            }
            else if (dataView.Items.Contains(PassNum.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ValidateCheckData()
        {
            if (
                string.IsNullOrEmpty(Type.Text) ||
                string.IsNullOrEmpty(Client.Text) ||
                string.IsNullOrEmpty(BalanceValue.Text)
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

        private void AddOwner_Click(object sender, RoutedEventArgs e)
        {

                if (ValidateBirthDate(Birth) && ValidateOwnerData())
                {
                    int pNumber = Convert.ToInt32(PassNum.Text);
                    bool isUnique = db.Owners.Any(o => o.PassportNumber == pNumber);
                if (!isUnique && PassNum.Text.Length == 7 )
                {
                    owner = new Owner()
                    {
                        Name = Name.Text,
                        Surname = Surname.Text,
                        Fathername = Fathername.Text,
                        Birth = Convert.ToDateTime(Birth.Text),
                        PassportSeries = PassSeries.Text,
                        PassportNumber = Convert.ToInt32(PassNum.Text)
                    };

                    db.Owners.Add(owner);
                    db.SaveChanges();
                    db.Owners.Load();
                    dataView.ItemsSource = db.Owners.Local.ToBindingList();
                    ClearOwner();
                }
                else
                {
                    MessageBox.Show("Введенный PassportNumber существует/не корректен!");
                }
            }
                else
                {
                    MessageBox.Show("Данные не введены!");
                }
            
        }

        private async void GetAllOwners_Click(object sender, RoutedEventArgs e)
        {

            var allOwners = await db.Owners.SqlQuery("begin tran SELECT * FROM Owners; commit tran;").ToListAsync();
            dataView.ItemsSource = allOwners;
        
        }

        private async void GetAllChecks_Click(object sender, RoutedEventArgs e)
        {
            var allChecks = await db.Checks.SqlQuery("begin tran SELECT * FROM ClientChecks; commit tran;").ToListAsync();
            dataView.ItemsSource = allChecks;
        }

        private void ValidateBalance(object sender, TextCompositionEventArgs e)
        {
            BalanceValue.MaxLength = 15;
            if (!Char.IsDigit(e.Text, 0) && e.Text != "," && e.Text != "-") e.Handled = true;
        }

        private void ValidateOwnerNum(object sender, TextCompositionEventArgs e)
        {
            PrevNumber.MaxLength = 15;
            Client.MaxLength = 15;
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void AddCheck_Click(object sender, RoutedEventArgs e)
        {
                if (ValidateCheckData())
                {
                    int clientId = Convert.ToInt32(Client.Text);
                    bool isClientIdExists = db.Owners.Any(o => o.ID == clientId);

                    if (isClientIdExists)
                    {
                        check = new ClientCheck()
                        {
                            CheckType = Type.Text,
                            Balance = Convert.ToDouble(BalanceValue.Text),
                            ClientID = clientId,
                        };

                        db.Checks.Add(check);
                        db.SaveChanges();
                        dataView.ItemsSource = db.Checks.Local.ToBindingList();
                        ClearCheck();
                    }
                    else
                    {
                        MessageBox.Show("Введенный ClientID не существует!");
                    }
                }
                else
                {
                    MessageBox.Show("Введены не все данные!");
                }
  
        }

        private async void FindOwner_Click(object sender, RoutedEventArgs e)
        {

            var owners = await db.Owners.Where(o => o.Name.Contains(NameFind.Text) && o.Surname.Contains(SurnameFind.Text)).ToListAsync();
            dataView.ItemsSource = owners;
            NameFind.Clear();
            SurnameFind.Clear();
        }

        private async void FIndCheck_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ClientId = Convert.ToInt32(ClientFind.Text);
                var checks = await db.Checks.Where(c => c.ClientID == ClientId && c.CheckType.Contains(TypeFind.Text)).ToListAsync();
                dataView.ItemsSource = checks;
                ClientFind.Clear();
                TypeFind.Clear();   
            }
            catch(FormatException)
            {
                MessageBox.Show("Неверный формат");
                db.Checks.Load();
                dataView.ItemsSource = db.Checks.Local.ToBindingList();
            }
        }


        // SORT CHECKS

        private async void SortCheckByNumber(object sender, RoutedEventArgs e)
        {
            var checks = await db.Checks.OrderByDescending(c => c.Number).ToListAsync();
            dataView.ItemsSource = checks;
        }

        private async void SortCheckByClient(object sender, RoutedEventArgs e)
        {
            var checks = await db.Checks.OrderBy(c => c.ClientID).ToListAsync();
            dataView.ItemsSource = checks;
        }

        private async void SortCheckByType_Click(object sender, RoutedEventArgs e)
        {
            var checks = await db.Checks.OrderBy(c => c.CheckType).ToListAsync();
            dataView.ItemsSource = checks;
        }

        private async void SortCheckByBalance(object sender, RoutedEventArgs e)
        {
            var checks = await db.Checks.OrderBy(c => c.Balance).ToListAsync();
            dataView.ItemsSource = checks;
        }


        // SORT OWNERS

        private async void SortOwnerByName(object sender, RoutedEventArgs e)
        {
            var owners = await db.Owners.OrderBy(c => c.Name).ToListAsync();
            dataView.ItemsSource = owners;
        }

        private async void SortOwnerBySurname(object sender, RoutedEventArgs e)
        {
            var owners = await db.Owners.OrderBy(c => c.Surname).ToListAsync();
            dataView.ItemsSource = owners;
        }

        private async void SortOwnerByFathername(object sender, RoutedEventArgs e)
        {
            var owners = await db.Owners.OrderBy(c => c.Fathername).ToListAsync();
            dataView.ItemsSource = owners;
        }

        private async void SortOwnerByBirth(object sender, RoutedEventArgs e)
        {
            var owners = await db.Owners.OrderBy(c => c.Birth).ToListAsync();
            dataView.ItemsSource = owners;
        }

        private async void SortOwnerByPassNum(object sender, RoutedEventArgs e)
        {
            var owners = await db.Owners.OrderBy(c => c.PassportNumber).ToListAsync();
            dataView.ItemsSource = owners;
        }

        private async void SortOwnerByPassSer(object sender, RoutedEventArgs e)
        {
            var owners = await db.Owners.OrderBy(c => c.PassportSeries).ToListAsync();
            dataView.ItemsSource = owners;
        }

        private void DelOwner_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int _id = Convert.ToInt32(OwnerID.Text);
                db.DeleteOwner(_id);
                OwnerID.Clear();
                var allOwners = db.Owners.SqlQuery("begin tran SELECT * FROM Owners; commit tran;").ToList();
                dataView.ItemsSource = allOwners;
                db.SaveChanges();

            }
            catch (FormatException)
            {
                MessageBox.Show("Неправильный формат!");
            }
        }

        private void DelCheck_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var parameter = new SqlParameter("@Number", CheckID.Text);
                var checks = db.Checks.SqlQuery("begin tran DELETE FROM ClientChecks WHERE Number = @Number; commit tran;", parameter).ToList();
                db.SaveChanges();

            }
            catch
            {
                CheckID.Clear();
                var allChecks = db.Checks.SqlQuery("begin tran SELECT * FROM ClientChecks; commit tran;").ToList();
                dataView.ItemsSource = allChecks;
            }
        }

        private void UpdateOwner_Click(object sender, RoutedEventArgs e)
        {
            if(PrevOwner != null && !string.IsNullOrEmpty(PrevOwner.Text))
            {
                Owner ownerToUpdate = db.Owners.Find(Convert.ToInt32(PrevOwner.Text));
                if(ownerToUpdate != null)
                {
                    ownerToUpdate.Name = !string.IsNullOrEmpty(NewName.Text) ? NewName.Text : ownerToUpdate.Name;
                    ownerToUpdate.Surname = !string.IsNullOrEmpty(NewSurname.Text) ? NewSurname.Text : ownerToUpdate.Surname;
                    ownerToUpdate.Fathername = !string.IsNullOrEmpty(NewFathername.Text) ? NewFathername.Text : ownerToUpdate.Fathername;
                    if (!string.IsNullOrEmpty(NewBirth.Text))
                    {
                        ownerToUpdate.Birth = Convert.ToDateTime(NewBirth.Text);
                    }
                    ownerToUpdate.PassportSeries = !string.IsNullOrEmpty(NewPassSeries.Text) ? NewPassSeries.Text : ownerToUpdate.PassportSeries;
                    if (!string.IsNullOrEmpty(NewPassNum.Text))
                    {
                        ownerToUpdate.PassportNumber = Convert.ToInt32(NewPassNum.Text);
                    }

                    db.SaveChanges();
                    ClearOwner();
                }
                else
                {
                    MessageBox.Show("Владелец не найден!");
                }
            }
            else
            {
                MessageBox.Show("Введите номер владельца!");
            }
        }

        private void UpdateCheck_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PrevNumber != null && !string.IsNullOrEmpty(PrevNumber.Text))
                {
                    ClientCheck ownerToUpdate = db.Checks.Find(Convert.ToInt32(PrevNumber.Text));
                    if (ownerToUpdate != null)
                    {
                        int _cid = string.IsNullOrEmpty(NewClient.Text) ? ownerToUpdate.ClientID : Convert.ToInt32(NewClient.Text);
                        bool isExist = db.Owners.Any(o => o.ID == _cid);
                        if (isExist)
                        {
                            ownerToUpdate.CheckType = !string.IsNullOrEmpty(NewType.Text) ? NewType.Text : ownerToUpdate.CheckType;
                            ownerToUpdate.Balance = !string.IsNullOrEmpty(NewBalance.Text) ? Convert.ToDouble(NewBalance.Text) : ownerToUpdate.Balance;
                            ownerToUpdate.ClientID = !string.IsNullOrEmpty(NewClient.Text) ? Convert.ToInt32(NewClient.Text) : ownerToUpdate.ClientID;
                            db.SaveChanges();
                            ClearCheck();
                        }
                        else
                        {
                            MessageBox.Show("Владельца с таким ID не существует!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Счёт не найден!");
                    }
                }
                else
                {
                    MessageBox.Show("Введите номер счёта!");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат!");
            }
        }
    }
}
