using Microsoft.AspNetCore.Authorization;

namespace FilmesAPI.Authorization
{
    public class IdadeMinimaRequirement : IAuthorizationRequirement
    {
        public IdadeMinimaRequirement(int idadeMinima)
        {
            IdadeMinima = idadeMinima;
        }

        public int IdadeMinima { get; set; }
    }
}
