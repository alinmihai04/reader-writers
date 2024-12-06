using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiThread.Data
{
    public class SharedDatabase
    {
        private List<Entry> buffer;

        public SharedDatabase(int size, int blockSize, int readDuration, int writeDuration)
        {
            buffer = Enumerable.Range(0, size)
                .Select(e => new Entry(blockSize, readDuration, writeDuration))
                .ToList();
        }

        private void SetData(int index, byte[] data)
        {
            buffer.ElementAt(index).SetContent(data);
        }

        public EntryResult AddData(int index, string data)
        {
            SetData(index, Encoding.UTF8.GetBytes(data));

            return GetData(index);
        }

        private byte[] GetBytes(int index)
        {
            return buffer.ElementAt(index).GetContent();
        }

        public EntryResult GetData(int index)
        {
            return new EntryResult
            {
                Index = index,
                Data = Encoding.UTF8.GetString(GetBytes(index)),
                Sequence = buffer.ElementAt(index).GetSequence()
            };
        }

        public int GetSize()
        {
            return buffer.Count;
        }
    }
}
