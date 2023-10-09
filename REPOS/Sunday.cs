using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Sunday.DTO;
using Sunday.Models;

namespace Sunday.REPOS
{
    public class Sunday : ISunday
    { private readonly AppDbContext _context;
        public Sunday(AppDbContext context)
        {
            _context = context; 
        }

        public async Task<DippsDTO> AddDipps(DippsDTO dto)
        {
           Dipps dipps = new Dipps();
            {

                dipps.Name = dto.Name;
                dipps.Description = dto.Description;
                dipps.Age = dto.Age;

            };
              _context.Olawale.Add(dipps);
              await _context.SaveChangesAsync(); 
              return dto; 
           
           
        }

        public async Task<String> DeleteDipps(int id)
        {
           var Dipo = _context.Olawale.FirstOrDefault(x => x.Id == id);
            if (Dipo != null)
            {
                _context.Olawale.Remove(Dipo);
                await _context.SaveChangesAsync();
                return "Deleted Successfully";
            }
            return null;
        }

        public async Task<List<Dipps>> GetAllDipps()
        {
            await _context.SaveChangesAsync();
            return _context.Olawale.ToList();
        }

        public async Task<Dipps> GetDippsByID(int Dippsid)
        {
            var shola = await _context.Olawale.FindAsync(Dippsid);

            if(shola != null)
            {

                return shola;
            }

            return null;
        }



        public async Task<DippsDTO> UpdateDipps(int id, DippsDTO dipps)
        {
            var Akoka =  await _context.Olawale.Where(x=> x.Id ==  id).FirstOrDefaultAsync();   
            if (Akoka == null)
            {
               return null;
            }

            Akoka.Description = dipps.Description;
            Akoka.Name = dipps.Name;
            Akoka.Age = dipps.Age;
            Akoka.Id = dipps.id;
            _context.SaveChanges();

            var updatedAkoka = new DippsDTO
            {
                id = Akoka.Id,
                Description = Akoka.Description,
                Name = Akoka.Name,
                Age = Akoka.Age,

            };

            return updatedAkoka;


           


        }
    }
}
