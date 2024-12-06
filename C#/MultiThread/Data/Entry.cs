using System;
using System.Threading;

namespace MultiThread.Data
{
    public class Entry
    {
        private int readDuration;
        private int writeDuration;
        private byte[] block;
        private int size;
        private int sequence;

        public Entry(int blockSize, int readDuration, int writeDuration)
        {
            this.readDuration = readDuration;
            this.writeDuration = writeDuration;
            this.block = new byte[blockSize];
            this.size = 0;
        }

        private static void TryRandomSleep(int duration)
        {
            try
            {
                Thread.Sleep(duration + new Random().Next(-(duration / 10), duration / 10));
            }
            catch (ThreadInterruptedException e)
            {
                throw new Exception(e.Message);
            }
        }

        public void SetContent(byte[] data)
        {
            size = data.Length;
            ++sequence;

            for (int i = 0; i < data.Length; i++)
            {
                block[i] = data[i];
            }

            TryRandomSleep(readDuration);

            if (size != data.Length)
            {
                throw new Exception("Size mismatch");
            }

            for (int i = 0; i < data.Length; i++)
            {
                if (block[i] != data[i])
                {
                    throw new Exception("block mismatch");
                }
            }
        }

        public byte[] GetContent()
        {
            byte[] result = new byte[block.Length];

            Array.Copy(block, result, size);

            return result;
        }

        public int GetSequence()
        {
            return sequence;
        }
    }
}
