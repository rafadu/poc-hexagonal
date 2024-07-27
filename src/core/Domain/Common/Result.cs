namespace Domain.Common
{
    public struct Result<T>
    {
        public T Data {get; private set;}
        public bool Success {get; private set;}
        public string Message {get; private set;}
        public Exception Exception {get; private set;}

        public Result(T data){
            Success = true;
            Data = data;
            Message = string.Empty;
            Exception = null!;
        }

        public Result(Exception exception){
            Success = false;
            Data = default!;
            Message = exception.Message;
            Exception = exception;
        }

        public Result(string message, bool isError){
            if(!isError){
                var mensagem = "Use Result<string>(string) como construtor para resultados de sucesso.";
                throw new ArgumentException(mensagem,nameof(isError));
            }

            Success = false;
            Data = default!;
            Exception = default!;
            Message = message;
        }

        public bool IsSuccess() => Success;
        public bool HasException() => Exception != null;
    }
}