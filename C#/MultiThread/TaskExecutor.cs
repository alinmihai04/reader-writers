using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MultiThread.Data;

namespace MultiThread
{
    public class TaskExecutor
    {
        private SharedDatabase sharedDatabase;

        public TaskExecutor(int storageSize, int blockSize, int readDuration, int writeDuration)
        {
            sharedDatabase = new SharedDatabase(storageSize, blockSize, readDuration, writeDuration);
        }

        public IList<EntryResult> ExecuteWork(int numberOfThreads, List<StorageTask> tasks, LockType lockType)
        {
            var tasksToExecute = new ConcurrentBag<Task>();
            var readWriter = new ReadPreferredExecutor(sharedDatabase);

            ThreadPool.SetMinThreads(numberOfThreads, numberOfThreads);
            ThreadPool.SetMaxThreads(numberOfThreads, numberOfThreads);

            foreach (var storageTask in tasks)
            {
                tasksToExecute.Add(storageTask.IsWrite()
                    ? Task.Run(() => readWriter.Write(storageTask.Index, storageTask.Data))
                    : Task.Run(() => readWriter.Read(storageTask.Index)));
            }

            Task.WaitAll(tasksToExecute.ToArray());

            return new List<EntryResult>();
        }
    }
}