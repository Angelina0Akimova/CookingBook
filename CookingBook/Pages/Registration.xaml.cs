using CookingBook.AppData;
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

namespace CookingBook.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверка заполнения обязательных полей
                if (string.IsNullOrWhiteSpace(tbFio.Text) ||
                    string.IsNullOrWhiteSpace(tbLogin.Text) ||
                    string.IsNullOrWhiteSpace(tbPass.Password))
                {
                    MessageBox.Show("Заполните все обязательные поля!", "Ошибка",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Проверка совпадения паролей (если есть повторный ввод)
                //if (tbPass.Password != tbPassRepeat.Password)  // Предположим, что tbPassRepeat - это PasswordBox для повторного пароля
                //{
                //    MessageBox.Show("Пароли не совпадают!", "Ошибка",
                //                  MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return;
                //}

                // Создание нового автора
                var newAuthor = new Authors()
                {
                    AuthorName = tbFio.Text,
                    Login = tbLogin.Text,
                    Password = tbPass.Password,
                    // Добавьте остальные поля, если они есть в БД:
                    //Email = tbEmail.Text,
                    // Phone = tbPhone.Text,
                    // BirthDate = dpBirthDate.SelectedDate,
                };

                // Добавление в БД
                AppConnect.model01.Authors.Add(newAuthor);
                AppConnect.model01.SaveChanges();

                MessageBox.Show("Регистрация успешна!", "Уведомление",
                              MessageBoxButton.OK, MessageBoxImage.Information);

                // Возврат на страницу авторизации
                NavigationService.Navigate(new Autorization());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка регистрации: {ex.Message}", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Пусто (не используется)
        }
    }
}
