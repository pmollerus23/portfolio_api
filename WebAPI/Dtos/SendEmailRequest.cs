namespace WebAPI.Dtos
{
    public record SendEmailRequest
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

}

