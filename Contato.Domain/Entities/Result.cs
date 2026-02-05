namespace MedTeste.Domain.Entities
{
    public class Result<T>
    {
        public T Data { get; }
        public bool IsSuccess { get; }
        public string Error { get; }

        private Result(T data, bool isSuccess, string error)
        {
            Data = data;
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result<T> Success(T data) => new Result<T>(data, true, null);
        public static Result<T> Failure(string error) => new Result<T>(default, false, error);

    }
}
