using ProductBase.Server.RequestDTO;

namespace ProductBase.Server.Repositories
{
    public interface ILoginRepo
    {
        string LoginDetails(LoginDTO loginDTO);

    }
}
