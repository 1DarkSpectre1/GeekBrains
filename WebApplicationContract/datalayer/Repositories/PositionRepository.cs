using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationContract_GB_.Entitys;

namespace datalayer.Repositories
{
        public class PositionRepository
        {
            private ApplicationDataContext _context;

            public PositionRepository(ApplicationDataContext context)
            {
                _context = context;
            }
        
            public async Task<IEnumerable<Position>> GetPositionAsync()
            {
                return await _context.Positions.Where(p => p.Id > 0).ToArrayAsync();
            }
            public async Task<IEnumerable<Position>> GetPositionById(int id)
            {
                return await _context.Positions.Where(p => p.Id == id).ToArrayAsync();
            }
            public async Task<int> PostPosition(Position Position)
            {
                Position UpdPosition = _context.Positions.Where(p => p.Id == Position.Id).FirstOrDefault();
                UpdPosition = Position;
                return await _context.SaveChangesAsync();
            }
            public async Task<int> PutPosition(Position Position)
            {
                _context.Positions.Remove(Position);
                return await _context.SaveChangesAsync();
            }
            public async Task<int> DeletePosition(int id)
            {
                Position DeletePosition = _context.Positions.Where(p => p.Id == id).FirstOrDefault();
                _context.Positions.Remove(DeletePosition);
                return await _context.SaveChangesAsync();
            }
        }
}
