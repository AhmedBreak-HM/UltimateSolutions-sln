using MediatR;

namespace UltimateSolutions.Application.Queries.User.GetUserByName
{
    public class GetUserByNameQuery : IRequest<UserForReturnDto>
    {
        public string UserName { get; set; }
    }
}