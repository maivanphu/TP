using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.ComponentModel;

namespace WpfApplicationINotifyPropertyChanged
{
    public class ClassSongVM : INotifyPropertyChanged
    {
        public Song _song { get; set; }
        public string _artistName
        {
            get
            {
                return _song.ArtistName;
            }
            set
            {
                if ((_song.ArtistName != value))
                {
                    _song.ArtistName = value;
                    RaisePropertyChanged("_artistName");
                }
            }
        }
        public ClassSongVM()
        {
            _song = new Song() { ArtistName = "Michel", SongTitle = "Thriller" };
        }


        // Implémenter l'interface INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            //PropertyChangedEventHandler handler;

            //if (handler == null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}