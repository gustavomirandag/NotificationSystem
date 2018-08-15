using StorageService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiverConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Crio o objeto que irá acessar o serviço de fila
            QueueService queueService;
            queueService = new QueueService();

            string message;
            do
            {
                message = queueService.GetMessage("gustavo");
                Console.WriteLine(message);
            } while (!String.IsNullOrEmpty(message));

            //Aguarda o ENTER...
            Console.ReadLine();

        }
    }
}
