using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageService
{
    public class QueueService
    {
        public void AddMessage(string messageText, string queueName)
        {
            //Cria o objeto de acesso ao storage
            CloudStorageAccount storageAccount;
            storageAccount = CloudStorageAccount
                .Parse(StorageService
                .Properties.Settings.Default
                .AzureStorageServiceConnectionString);

            //Cliente de serviços de queue
            CloudQueueClient queueClient = storageAccount
                .CreateCloudQueueClient();

            //Cria um objeto CloudQueue que faz referência a uma fila específica
            CloudQueue queue = queueClient.GetQueueReference(queueName);

            //Cria a fila se ela não existe
            queue.CreateIfNotExists();

            //Adiciono a mensagem na fila
            queue.AddMessage(new CloudQueueMessage(messageText));
        }

        public string GetMessage(string queueName)
        {
            //Cria o objeto de acesso ao storage
            CloudStorageAccount storageAccount;
            storageAccount = CloudStorageAccount
                .Parse(StorageService
                .Properties.Settings.Default
                .AzureStorageServiceConnectionString);

            //Cliente de serviços de queue
            CloudQueueClient queueClient = storageAccount
                .CreateCloudQueueClient();

            //Cria um objeto CloudQueue que faz referência a uma fila específica
            CloudQueue queue = queueClient.GetQueueReference(queueName);

            //Obtem uma referência a mensagem
            var queueMessage = queue.GetMessage();

            //Verifica se não existe mais nenhuma mensagem
            if (queueMessage == null)
                return null;

            //Retorna a mensagem como uma string
            return queueMessage.AsString;
        }
        
    }
}
