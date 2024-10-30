using TristanRosel.Contracts;
using TristanRosel.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TristanRosel.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _repository;

        public BookService(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            
            return await _repository.All().Include(b => b.Library).ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            return await _repository.Find(b => b.BookId == id).Include(b => b.Library).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Book book)
        {
            await _repository.AddAsync(book);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _repository.Update(book);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var book = await GetByIdAsync(id);
            if (book != null)
            {
                _repository.Delete(book);
                await _repository.SaveChangesAsync();
            }
        }
    }
}
