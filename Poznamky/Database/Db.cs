using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Poznamky.Model;
using SQLite;

namespace Poznamky.Database
{
    class Db
    {
        private SQLiteConnection db;

        public Db()
        {
            db = new SQLiteConnection(
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                    "poznamky.db3"
                )
            );

            db.CreateTable<Note>();
        }

        public TableQuery<Note> getAll()
        {
            return db.Table<Note>();
        }

        public List<Note> getById(int id)
        {
            return db.Query<Note>("SELECT * FROM poznamky WHERE id = ?", id);
        }

        public int add(string name, string text)
        {
            Note note = new Note();

            note.Name = name;
            note.Text = text;
            note.Creation_Date = DateTime.Now;
            note.Edit_Date = null;

            return db.Insert(note);
        }

        public int edit(int id, string name, string text, DateTime creation_date)
        {
            Note note = new Note();

            note.ID = id;
            note.Name = name;
            note.Text = text;
            note.Creation_Date = creation_date;
            note.Edit_Date = DateTime.Now;

            return db.Update(note);
        }

        public int delete(int id)
        {
            Note note = new Note();

            note.ID = id;

            return db.Delete(note);
        }
    }
}
