namespace PagingWithDapper.Model
{
    public class ApiResponse
    {
        public bool Sucess { get; set; }    
        public string Message { get; set; }
        public object Data { get; set; }


        public ApiResponse(bool sucess, string message, object data)
        {
              Sucess = sucess;
            Message = message;
            Data = data;
        }
    }
}
