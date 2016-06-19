using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using LocalDb.Annotations;

namespace LocalDb.ViewModel
{
    /// <summary>
    /// Базовая модель поведения для представлений.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class BaseViewModel:INotifyPropertyChanged
    {
        /// <summary>
        /// Событие для отслеживания изменения свойства модели.
        /// </summary>
       public event PropertyChangedEventHandler PropertyChanged;


       /// <summary>
       /// Базовый конструктор.
       /// </summary>
        protected BaseViewModel()
        {
            
        }

        /// <summary>
        /// Базовый объект директории приложения.
        /// </summary>
        public DirectoryInfo BaseDiewctory
        {
            get { return new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory); }
        }


        /// <summary>
        /// Вызывающий метод для изменивщегося свойства.
        /// </summary>
        /// <param name="propertyName">Название совойства.</param>
       [NotifyPropertyChangedInvocator]
       protected virtual void OnPropertyChanged(string propertyName)
       {
           var handler = PropertyChanged;
           if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
       }
    }
}
