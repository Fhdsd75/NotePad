using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ToolStripMenuItem menuItemFile = new ToolStripMenuItem("Файл");

            ToolStripMenuItem menuItemSave = new ToolStripMenuItem("Сохранить");
            menuItemSave.ShortcutKeys = Keys.Control | Keys.S;
            menuItemSave.Click += new EventHandler(menuItemSave_Click);

            ToolStripMenuItem menuItemOpen = new ToolStripMenuItem("Открыть");
            menuItemOpen.ShortcutKeys = Keys.Control | Keys.A;
            menuItemOpen.Click += new EventHandler(menuItemOpen_Click);

            ToolStripMenuItem menuItemNew = new ToolStripMenuItem("Новый файл");
            menuItemNew.ShortcutKeys = Keys.Control | Keys.D;
            menuItemNew.Click += new EventHandler(menuItemNew_Click);

            ToolStripMenuItem menuItemCalk = new ToolStripMenuItem("Калькулятор");
            menuItemCalk.ShortcutKeys = Keys.Control | Keys.B;
            menuItemCalk.Click += new EventHandler(menuItemCalculator_Click);


            menuStrip1.Items.Add(menuItemFile);


            menuItemFile.DropDownItems.Add(menuItemSave);
            menuItemFile.DropDownItems.Add(menuItemOpen);
            menuItemFile.DropDownItems.Add(menuItemNew);
            menuItemFile.DropDownItems.Add(menuItemCalk);
       
            ToolStripMenuItem menuItemEdit = new ToolStripMenuItem("Редактировать");


            ToolStripMenuItem menuItemCopy = new ToolStripMenuItem("Копировать");
            menuItemCopy.ShortcutKeys = Keys.Control | Keys.C;
            menuItemCopy.Click += new EventHandler(menuItemCopy_Click);

            ToolStripMenuItem menuItemCut = new ToolStripMenuItem("Вырезать");
            menuItemCut.ShortcutKeys = Keys.Control | Keys.X;
            menuItemCut.Click += new EventHandler(menuItemCut_Click);

            ToolStripMenuItem menuItemPaste = new ToolStripMenuItem("Вставить");
            menuItemPaste.ShortcutKeys = Keys.Control | Keys.V;
            menuItemPaste.Click += new EventHandler(menuItemPaste_Click);


            menuStrip1.Items.Add(menuItemEdit);

  
            ToolStripMenuItem menuItemFont = new ToolStripMenuItem("Шрифт");
            menuItemFont.Click += new EventHandler(menuItemFont_Click);

            ToolStripMenuItem menuItemColor = new ToolStripMenuItem("Цвет");
            menuItemColor.Click += new EventHandler(menuItemColor_Click);

            menuStrip1.Items.Add(menuItemFont);
            menuStrip1.Items.Add(menuItemColor);

     
            this.Controls.Add(menuStrip1);

     
            menuItemEdit.DropDownItems.Add(menuItemCopy);
            menuItemEdit.DropDownItems.Add(menuItemCut);
            menuItemEdit.DropDownItems.Add(menuItemPaste);
            menuItemEdit.DropDownItems.Add(menuItemFont);
            menuItemEdit.DropDownItems.Add(menuItemColor);


        }

     
        private void menuItemCopy_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                richTextBox1.Copy();
            }
            else
            {
                MessageBox.Show("Нет выделенного текста для копирования!");
            }
        }


        private void menuItemCut_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                richTextBox1.Cut();
            }
            else
            {
                MessageBox.Show("Нет выделенного текста для вырезания!");
            }
        }


        private void menuItemPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                richTextBox1.Paste();
            }
            else
            {
                MessageBox.Show("Буфер обмена пуст!");
            }
        }


        private void menuItemFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog.Font;
            }
        }


        private void menuItemColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog.Color;
            }
        }


        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                richTextBox1.LoadFile(openFileDialog1.FileName);
            }
            catch
            {
                MessageBox.Show("Файл не выбран!");
            }
        }


        private void menuItemSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (!string.IsNullOrEmpty(saveFileDialog1.FileName))
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
            }
        }


        private void menuItemNew_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void menuItemCalculator_Click(object sender, EventArgs e)
        {

            string calculatorPath = @"C:\Users\Arman\source\repos\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\calkulate.exe";

            try
            {
                System.Diagnostics.Process.Start(calculatorPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при запуске калькулятора: {ex.Message}");
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
