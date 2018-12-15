namespace Tournament.CrossCutting
{
    public class SwaggerConfiguration
    {
        public string Endpoint { get; set; }
        public string Title { get; set; }

        public string Version { get; set; }
        public string Description { get; set; }
        public string TermsOfService { get; set; }

        public SwaggerContactConfiguration Contact { get; set; }
        public SwaggerLicenseConfiguration License { get; set; }
    }

    public class SwaggerLicenseConfiguration
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class SwaggerContactConfiguration
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
    }
}