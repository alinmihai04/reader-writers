using System;
using System.Diagnostics;
using MultiThread.Data;
using System.Threading;

namespace MultiThread
{
    public class ReadPreferredExecutor
    {
        private readonly SharedDatabase _sharedDatabase;

        private static readonly SemaphoreSlim resourceLock = new SemaphoreSlim(1, 1);
        private static readonly SemaphoreSlim readersSemaphore = new SemaphoreSlim(1, 1);
        private static int readerCount = 0;

        public ReadPreferredExecutor(SharedDatabase sharedDatabase)
        {
            _sharedDatabase = sharedDatabase;
        }

        public void Read(int index)
        {
            try
            {
                readersSemaphore.Wait();

                if (++readerCount == 1)
                {
                    resourceLock.Wait();
                }

                readersSemaphore.Release();

                _sharedDatabase.GetData(index);

                readersSemaphore.Wait();
                if (--readerCount == 0)
                {
                    resourceLock.Release();
                }

                readersSemaphore.Release();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Write(int index, string data)
        {
            try
            {
                resourceLock.Wait();

                _sharedDatabase.AddData(index, data);

                resourceLock.Release();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}