package org.apd.executor;

import org.apd.storage.SharedDatabase;

import java.util.concurrent.Semaphore;

public class ReadPreferredExecutor {
    private static Semaphore resourceLock = new Semaphore(1);
    private static Semaphore readersSemaphore = new Semaphore(1);
    private static int readerCount = 0;
    private static SharedDatabase sharedDatabase;

    public ReadPreferredExecutor(SharedDatabase sharedDatabase) {
        this.sharedDatabase = sharedDatabase;
    }

    public void read(int index) {
        try {
            readersSemaphore.acquire();

            if (++readerCount == 1) {
                resourceLock.acquire();
            }

            readersSemaphore.release();

            sharedDatabase.getData(index);

            readersSemaphore.acquire();

            if (--readerCount == 0) {
                resourceLock.release();
            }

            readersSemaphore.release();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }

    public void write(int index, String data) {
        try {
            resourceLock.acquire();

            sharedDatabase.addData(index, data);

            resourceLock.release();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}
