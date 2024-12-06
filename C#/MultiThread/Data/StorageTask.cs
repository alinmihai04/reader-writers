namespace MultiThread.Data
{
    public class StorageTask
    {
        public int Index { get; set; }
        public string Data { get; set; }

        public bool IsWrite()
        {
            return Data != null;
        }
    }
}