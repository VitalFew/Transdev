namespace VitalFew.Transdev.Australasia.Data.Core.Result
{
    public class QueryResult<T>
    {
        public T Result { get; set; }

        public int RecordCount { get; set; }
    }
}
