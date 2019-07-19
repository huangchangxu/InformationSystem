

namespace InformationPlat.Id4Server.Entities
{
    public class ClientPostLogoutRedirectUri
    {
        public int Id { get; set; }
        public string PostLogoutRedirectUri { get; set; }
        public Client Client { get; set; }
    }
}