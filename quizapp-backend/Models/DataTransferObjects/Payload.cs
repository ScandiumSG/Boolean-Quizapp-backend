namespace quizapp_backend.Models.DataTransferObjects
{
    public class Payload<T> where T : class
    {
        public T data { get; set; }

        public Payload(T data)
        {
            this.data = data;
        }
    }
}
