using System.Collections.Generic;

namespace harbour.model__views
{
    public class ResponseViewModel<T>
    {
        public string Message { get; set; }
        public int Code { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}