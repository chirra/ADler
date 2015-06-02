using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADler.Model
{
    public static class ClientRepository
    {
        private static ObservableCollection<Client> _clients;

        public static ObservableCollection<Client> AllClients
        {
            get
            {
                if (_clients == null)
                    _clients = GenerateClientRepository();
                return _clients;
            }
        }

        private static ObservableCollection<Client> GenerateClientRepository()
        {
            ObservableCollection<Client> clients = new ObservableCollection<Client>();
            clients.Add(new Client("10", "20"));
            clients.Add(new Client("50", "50"));
            clients.Add(new Client("20", "20"));
            return clients;
        }
    }

}
