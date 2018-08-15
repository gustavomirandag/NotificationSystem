using StorageService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifierConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Crio o serviço de fila
            QueueService queueService;
            queueService = new QueueService();

            Console.WriteLine("Digite a notificação:");
            string message = Console.ReadLine();

            queueService.AddMessage(message,"gustavo");
        }
    }
}
