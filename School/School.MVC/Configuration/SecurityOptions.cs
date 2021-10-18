namespace School.MVC.Configuration
{
    public class SecurityOptions
    {
        public const string SectionTitle = "Security";
        public string AdminUserEmail { get; set; }
        public string ManagerUserEmail { get; set; }
    }
}