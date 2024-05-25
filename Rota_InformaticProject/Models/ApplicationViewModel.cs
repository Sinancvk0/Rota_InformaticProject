namespace Rota_InformaticProject.Models
{
    public class ApplicationViewModel
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public string? CompanyName { get; set; }
        public required string Body { get; set; }
    }
}
