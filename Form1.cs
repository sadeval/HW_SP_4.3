using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_SP_4._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string word = txtWord.Text;
            string directory = txtDirectory.Text;

            if (string.IsNullOrWhiteSpace(word) || string.IsNullOrWhiteSpace(directory))
            {
                MessageBox.Show("Введите слово и выберите директорию.");
                return;
            }

            if (!Directory.Exists(directory))
            {
                MessageBox.Show("Директория не существует.");
                return;
            }

            txtResult.Clear();

            try
            {
                await SearchFilesAsync(word, directory);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private async Task SearchFilesAsync(string word, string directory)
        {
            var files = Directory.EnumerateFiles(directory, "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                await Task.Run(() => SearchWordInFile(word, file));
            }
        }

        private void SearchWordInFile(string word, string file)
        {
            try
            {
                string content = File.ReadAllText(file);
                int count = content.Split(new[] { word }, StringSplitOptions.None).Length - 1;

                if (count > 0)
                {
                    Invoke(new Action(() =>
                    {
                        txtResult.AppendText($"Название файла: {Path.GetFileName(file)}\r\n");
                        txtResult.AppendText($"Путь к файлу: {file}\r\n");
                        txtResult.AppendText($"Количество вхождений слова: {count}\r\n");
                        txtResult.AppendText(new string('-', 50) + "\r\n");
                    }));
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    txtResult.AppendText($"Ошибка при чтении файла {file}: {ex.Message}\r\n");
                    txtResult.AppendText(new string('-', 50) + "\r\n");
                }));
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDirectory.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }
    }
}
