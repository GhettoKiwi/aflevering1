using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace Afleveringsopgaven
{
    class User
    {
        private int id;
        private String name;
        private int age;
        private int score;

        public int ID
        {   
            set { id = value; }
            get { return id; }
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public int Age
        {
            set { age = value; }
            get { return age; }
        }

        public int Score
        {
            set { score = value; }
            get { return score; }
        }


        public User(string person)
        {
            string[] s = person.Split(';');
            this.id = int.Parse(s[0]);
            this.name = s[1];
            this.age = int.Parse(s[2]);
            this.score = int.Parse(s[3]);
        }

        override public string ToString()
        {
            return String.Format("{0, -5} {1, -4}", id, name);
        }
    }
}
