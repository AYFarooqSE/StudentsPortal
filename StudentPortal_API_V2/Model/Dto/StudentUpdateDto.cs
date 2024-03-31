namespace StudentsPortal_API.Model.Dto
{
    public class StudentUpdateDto
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? FatherName { get; set; }
        public bool IsDisabled { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
