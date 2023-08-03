using _3rd_TEAM_PROJECT.Models.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.InterFace
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();
        Task<Item> AddAsync(Item item);
        Task<Item?> UpdateAsync(Item item);
        Task<Item?> DeleteAsync(int item);

        Task<IEnumerable<Item>> CodeAsync(string search);
        Task<IEnumerable<Item>> NameAsync(string search);
        Task<IEnumerable<Item>> ConstAsync(string search);
        Task<IEnumerable<Item>> ModiAsync(string search);
        Task<IEnumerable<Item>> TypeAsync(string search);
    }
}
