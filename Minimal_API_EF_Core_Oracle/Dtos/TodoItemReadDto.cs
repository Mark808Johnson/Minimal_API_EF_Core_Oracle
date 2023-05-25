namespace Minimal_API_EF_Core_Oracle.Dtos
{
    public class TodoItemReadDto
    {
        public decimal Id { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreationTs { get; set; }

        public bool Done { get; set; }
    }
}
