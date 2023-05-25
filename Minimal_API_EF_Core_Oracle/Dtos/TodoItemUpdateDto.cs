namespace Minimal_API_EF_Core_Oracle.Dtos
{
    public class TodoItemUpdateDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool? Done { get; set; }
    }
}
