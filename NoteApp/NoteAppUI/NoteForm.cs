﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{

    public partial class NoteForm : Form
    {
        private Note _note = new Note();

        /// <summary>
        /// Возвращает и задает данные формы
        /// </summary>
        public Note Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = (Note)value.Clone();
                DisplayNote();
            }
        }

        public NoteForm()
        {
            InitializeComponent();

            CategoryComboBox.DataSource = Enum.GetValues(typeof(NoteCategory));
        }

        /// <summary>
        /// Отображение данных в заметке.
        /// </summary>
        public void DisplayNote()
        {
            if (_note == null)
            {
                CreatedDateTimePicker.Value = DateTime.Now;
                ModifiedDateTimePicker.Value = DateTime.Now;
                return;
            }

            TitleTextBox.Text = _note.Name;
            CategoryComboBox.SelectedItem = _note.Category;
            TextBox.Text = _note.Text;
            CreatedDateTimePicker.Value = _note.TimeOfCreation;
            ModifiedDateTimePicker.Value = _note.TimeOfEdit;
        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _note.Name = TitleTextBox.Text;
            }
            catch (Exception exceptionText)
            {
                MessageBox.Show(exceptionText.Message, "Превышение длины строки", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TitleTextBox.Text = _note.Name;
            }
        }

        /// <summary>
        /// Обработка события выбора новой категории из списка.
        /// </summary>
        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoryComboBox.SelectedIndex == -1) return;
            this._note.Category = (NoteCategory)CategoryComboBox.SelectedItem;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            _note.Text = TextBox.Text;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}