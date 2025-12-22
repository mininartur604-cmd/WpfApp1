using Microsoft.VisualBasic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public int score;
    public MainWindow()
    {
        InitializeComponent();
    }


    private void Button_Click(object sender, RoutedEventArgs e)
    {
        int[] answers_true = { 3, 1, 3, 3, 2, 1, 2, 4, 3, 1, 1, 3, 1, 1, 4 };
        int[] answers_user = new int[15];
        score = 0;
        for (int i = 0; i < answers_user.Length; i++)
        {
            bool answerFound = false;

            for (int j = 0; j < 4; j++)
            {
                string answer = $"q{i + 1}_a{j + 1}";

                if (i < 8)
                {

                    RadioButton rb = FindName(answer) as RadioButton;
                    if (rb != null && rb.IsChecked == true)
                    {
                        answers_user[i] = j + 1;
                        answerFound = true;
                        break;
                    }
                }
                else
                {
                    answer = $"q{i + 1}";

                    ComboBox cb = FindName(answer) as ComboBox;
                    if (cb != null && cb.SelectedItem != null)
                    {
                        if (cb.SelectedIndex >= 0)
                        {
                            answers_user[i] = cb.SelectedIndex + 1;
                            answerFound = true;
                        }
                    }
                }
            }
            if (!answerFound)
            {
                answers_user[i] = 0;
            }
        }
        string answerInFile = null;
        for (int i = 0; i < answers_true.Length; i++)
        {
            if (answers_user[i] == answers_true[i])
            {
                score++;
                answerInFile = answerInFile + $"{i+1} Правильный ответ\n";
            }
            else
            {
                answerInFile = answerInFile + $"{i+1} Не правильный ответ\n";
            }
        }

        result.Text = $"Вы набрали {score} правильных ответов из 15 ";

        string imageName;
        if (score == 15)
        {
            imageName = @"D:\С#\WpfApp1\WpfApp1\images\15.jpg";
        }
        else
        {
            imageName = @"D:\С#\WpfApp1\WpfApp1\images\1.jpg";
        }


        try
        {
            // Создаем URI для картинки
            Uri imageUri = new Uri(imageName, UriKind.RelativeOrAbsolute);

            // Загружаем картинку
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = imageUri;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();

            image1.Source = bitmap;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка загрузки картинки: {ex.Message}\nПуть: {imageName}");
            //Константин Олегович у всех кто не я будет ошибка потому что не относительный путь
            image1.Source = null;
        }

        SaveFileDialog saveDialog = new SaveFileDialog();
        saveDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
        saveDialog.Title = "Сохранить файл как";
        saveDialog.OverwritePrompt = true; // Спрашивать о перезаписи

        if (saveDialog.ShowDialog() == true)
        {
            try
            {
                File.WriteAllText(saveDialog.FileName, answerInFile);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка записи: {ex.Message}");
            }


        }
    }
}