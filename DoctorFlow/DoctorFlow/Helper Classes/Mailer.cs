using RestSharp;

namespace DoctorFlow
{
    public static class Mailer
    {
        public static IRestResponse SendSimpleMessage(string email, string message)
        {
            var client = new RestClient
            {
                BaseUrl = "https://api.mailgun.net/v2",
                Authenticator = new HttpBasicAuthenticator(
                    "api", "key-5sbcxpwm9avrbeds-35y2i5hmda4y8k1")
            };
            var request = new RestRequest();
            request.AddParameter("domain",
                "sandbox37840.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Doctor Flow <Drflow@sandbox37840.mailgun.org>");
            request.AddParameter("to", email);
            request.AddParameter("subject", "Recuperacion de contraseña");
            request.AddParameter("text", message);
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}