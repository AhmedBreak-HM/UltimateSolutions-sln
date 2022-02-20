namespace UltimateSolutions.Application.Queries.User.GetUserByName
{
    public class UserForReturnDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Token { get; set; }
    }
}