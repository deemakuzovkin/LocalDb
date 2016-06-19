using System.Collections.ObjectModel;
using System.Linq;
using Commands.Base;
using LocalDb.Data.Context;
using LocalDb.Data.Entities;
using LocalDb.Data.SqlCommand;

namespace LocalDb.ViewModel
{
    /// <summary>
    /// Модель поведения главного окна программы.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Car> _cars;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public MainViewModel()
        {
            LoadDbCommand = new BaseDelegateCommand(LoadDb, x => true);
            CreateDataCommand = new BaseDelegateCommand(CreateData, x => true);
            LoadDataCommand = new BaseDelegateCommand(LoadData, x => true);
        }

        /// <summary>
        /// Множество объектов из сущности.
        /// </summary>
        public ObservableCollection<Car> Cars
        {
            get { return _cars; }
            set
            {
                if (Equals(value, _cars)) return;
                _cars = value;
                OnPropertyChanged("Cars");
            }
        }

        /// <summary>
        /// Делегат загрузки локальной базы данных.
        /// </summary>
        public BaseDelegateCommand LoadDbCommand { get; set; }

        /// <summary>
        /// Делегат создания и наполнения локальной базы данных.
        /// </summary>
        public BaseDelegateCommand CreateDataCommand { get; set; }

        /// <summary>
        /// Делегат загрузки данных из локальной базы данных.
        /// </summary>
        public BaseDelegateCommand LoadDataCommand { get; set; }


        private void LoadDb()
        {
            SqlExecuteCommands.CreateDataBase(BaseDiewctory.FullName, "LDB");
        }

        private void CreateData()
        {
            using (var context = new LocalContext())
            {
                for (var i = 1; i <= 25; i++)
                {
                    context.Cars.Add(
                    new Car()
                    {
                        Id = i,
                        Name = string.Format("Марка - {0}", i),
                        Number = string.Format("АВ{0}{1}{2}Н", i, i + 1, i + i)
                    });
                }
                context.SaveChanges();
            }
        }

        private void LoadData()
        {
            using (var context = new LocalContext())
            {
                Cars = new ObservableCollection<Car>(context.Cars.ToList());
            }
        }
    }
}
