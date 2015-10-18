using AzureStorageLayer.StorageManagerExceptions;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageLayer.CloudStorageManager
{
    public partial class AzureStorageManager
    {
        /// <summary>
        /// adds the message to your cloud queue.
        /// </summary>
        /// <param name="queueName">cloud queue name</param>
        /// <param name="Message">queue message. if you are passing object as message then please convert to json.</param>
        public void AddQueueMessage(string queueName, string Message)
        {
            try
            {
                CloudQueue queue = getQueue(queueName);
                CloudQueueMessage queueMessage = new CloudQueueMessage(Message);
                queue.AddMessage(queueMessage);
            }
            catch (Exception ex)
            {
                throw new StorageOperationException("Queue Message Exception. for more details please see the inner exception.", ex);
            }
        }

        /// <summary>
        /// returns cloud queue and creates if not exsistes.
        /// </summary>
        /// <param name="queueName">cloud queue name</param>
        /// <returns>cloud queue object</returns>
        public CloudQueue getQueue(string queueName)
        {
            try
            {
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                CloudQueue queue = queueClient.GetQueueReference(queueName);
                queue.CreateIfNotExists();
                return queue;
            }
            catch (Exception ex)
            {
                throw new StorageOperationException("Queue not found. for more details please see the inner exception.", ex);
            }
        }

        /// <summary>
        /// updates the queue message
        /// </summary>
        /// <param name="queueName">sotrage queue name.</param>
        /// <param name="UpdatedMessage">updated content of the queue.</param>
        /// <param name="timeSpan">timespan of updation.</param>
        public void UpdateQueueMessage(string queueName
            , string UpdatedMessage
            , TimeSpan timeSpan)
        {

            try
            {
                if (timeSpan == null)
                    timeSpan = TimeSpan.FromSeconds(0.0);
                CloudQueue queue = getQueue(queueName);
                CloudQueueMessage queueMessage = queue.GetMessage();
                queueMessage.SetMessageContent(UpdatedMessage);
                queue.UpdateMessage(queueMessage
                    , timeSpan
                    , MessageUpdateFields.Content | MessageUpdateFields.Visibility);
            }
            catch (Exception ex)
            {
                throw new StorageOperationException("Queue Message Update Exception. for more details please see the inner exception.", ex);
            }
        }
    }
}
