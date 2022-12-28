namespace Kiosco.App.Data
{
    public class MailModel
    {
        public string BodyMessage { get; set; }

        public string From { get; set; }

        public string Subject { get; set; }

        public string CarbonCopy { get; set; }

        public string ToMail { get; set; }

        public string[] Attachtments { get; set; }

        public bool UseHtml { get; set; }

        public string TemplateName { get; set; }
    }
}
