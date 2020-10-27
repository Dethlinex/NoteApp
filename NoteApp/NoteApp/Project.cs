﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Класс проекта.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Список всех заметок в приложении.
        /// </summary>
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();
    }
}