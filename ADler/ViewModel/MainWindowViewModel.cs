using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using ADler.Infrastructure;
using ADler.Model;

namespace ADler.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        Client _currentClient;
        public Client CurrentClient
        {
            get
            {
                if (_currentClient == null)
                    _currentClient = new Client();
                return _currentClient;
            }
            set
            {
                _currentClient = value;
                OnPropertyChanged("CurrentClient");
            }
        }

        ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get
            {
                if (_clients == null)
                    _clients = ClientRepository.AllClients;
                return _clients;
            }
        }

        RelayCommand _addClientCommand;
        public ICommand AddClient
        {
            get
            {
                if (_addClientCommand == null)
                    _addClientCommand = new RelayCommand(ExecuteAddClientCommand, CanExecuteAddClientCommand);
                return _addClientCommand;
            }
        }

        private RelayCommand _mouseDown;

        public ICommand MouseDown
        {
            get
            {
                if (_mouseDown == null)
                    _mouseDown = new RelayCommand(ExecuteMouseDownCommand);
                return _mouseDown;
            }
        }

        private RelayCommand _mouseUp;
        public ICommand MouseUp
        {
            get
            {
                if (_mouseUp == null)
                    _mouseUp = new RelayCommand(ExecuteMouseUpCommand);
                return _mouseUp;
            }
        }

        private RelayCommand _mouseMove;
        public ICommand MouseMove
        {
            get
            {
                if (_mouseMove == null)
                    _mouseMove = new RelayCommand(ExecuteMouseMoveCommand);
                return _mouseMove;
            }
        }

        public void ExecuteAddClientCommand(object parameter)
        {
            Clients.Add(CurrentClient);
            CurrentClient = null;
        }

        public bool CanExecuteAddClientCommand(object parameter)
        {
            if (string.IsNullOrEmpty(CurrentClient.FirstName) ||
                string.IsNullOrEmpty(CurrentClient.LastName))
                return false;
            return true;
        }

        // Обработчик на нажатие левой клавишей мыши по поверхности, на которой отображаются квадраты.
        //private void ExecuteMouseDownCommand(object sender, MouseButtonEventArgs e)
        private void ExecuteMouseDownCommand(object sender)
        {
            // Получение координат мыши.
        //    Point pointClicked = e.GetPosition();
            Point mousePos = Mouse.GetPosition((IInputElement) sender);
            //Console.WriteLine(mousePos);
            
            // Если выбран RadioButton "Выбрать/Двигать"
            
               /* DrawingVisual visual = drawingSurface.GetVisual(pointClicked); // Получаем объект по указанным координатам.
                if (visual != null)
                {
                    // Подсчет координат верхнего левого угла квадрата
                    Point topLeftCorner = new Point(
                        visual.ContentBounds.TopLeft.X + drawingPen.Thickness / 2,
                        visual.ContentBounds.TopLeft.Y + drawingPen.Thickness / 2);
                    DrawSquare(visual, topLeftCorner, true);

                    // Получение смещения координат.
                    clickOffset = topLeftCorner - pointClicked;
                    isDragging = true;

                    if (selectedVisual != null && selectedVisual != visual)
                    {
                        // Очистка предыдущего выбора.
                        ClearSelection();
                    }
                    selectedVisual = visual;
                  }*/
            Clients[0].X = mousePos.X.ToString();
            Clients[0].Y = mousePos.Y.ToString();

            return;

        }

        private void ExecuteMouseUpCommand(object sender)
        {
            return;
        }

        private void ExecuteMouseMoveCommand(object sender)
        {
            return;
        }


        protected override void OnDispose()
        {
            this.Clients.Clear();
        }
    }

}
