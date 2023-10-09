using Sunday.DTO;
using Sunday.Models;

namespace Sunday.REPOS
{
    public interface ISunday
    {

       Task<List <Dipps>> GetAllDipps();
        Task<Dipps> GetDippsByID(int  id);  
        Task<DippsDTO> AddDipps(DippsDTO dto);
        Task<DippsDTO> UpdateDipps(int id, DippsDTO dipps);
        Task<String> DeleteDipps(int id);    

    }
}
