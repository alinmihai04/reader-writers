package org.apd.executor;

import org.apd.storage.EntryResult;
import org.apd.storage.SharedDatabase;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;
public class TaskExecutor {
    private static SharedDatabase sharedDatabase;

    public TaskExecutor(int storageSize, int blockSize, long readDuration, long writeDuration) {
        sharedDatabase = new SharedDatabase(storageSize, blockSize, readDuration, writeDuration);
    }

    public List<EntryResult> ExecuteWork(int numberOfThreads, List<StorageTask> tasks, LockType lockType) {
        var results = new ArrayList<EntryResult>();
        ExecutorService threadPool = Executors.newFixedThreadPool(numberOfThreads);
        ReadPreferredExecutor executor = new ReadPreferredExecutor(sharedDatabase);

        var beforeRunMs = System.currentTimeMillis();

        for (StorageTask storageTask : tasks) {
            if (storageTask.isWrite()) {
                threadPool.submit(() -> executor.write(storageTask.index(), storageTask.data()));
            } else {
                threadPool.submit(() -> executor.read(storageTask.index()));
            }
        }

        try {
            threadPool.awaitTermination(10, TimeUnit.SECONDS);

        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        threadPool.shutdown();

        return results;
    }
}
