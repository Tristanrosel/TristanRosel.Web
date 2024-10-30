using TristanRosel.Contracts;
using TristanRosel.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TristanRosel.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IRepository<Library> _repository;

        public LibraryService(IRepository<Library> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Library>> GetAllAsync()
        {
            return await _repository.All().ToListAsync();
        }

        public async Task<Library?> GetByIdAsync(Guid id)
        {
            return await _repository.Find(l => l.LibraryId == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Library library)
        {
            await _repository.AddAsync(library);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Library library)
        {
            _repository.Update(library);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var library = await GetByIdAsync(id);
            if (library != null)
            {
                _repository.Delete(library);
                await _repository.SaveChangesAsync();
            }
        }
    }
}
