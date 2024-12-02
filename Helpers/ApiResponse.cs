namespace CarRentalAPI.Helpers
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T? Payload { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new List<string>();
    }
}
