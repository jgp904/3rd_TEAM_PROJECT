using _3rd_TEAM_PROJECT.Data;
using _3rd_TEAM_PROJECT.InterFace;
using _3rd_TEAM_PROJECT.Models.Process;
using _3rd_TEAM_PROJECT_Desk;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Repositorys
{
    public class ItemRepository : IItemRepository
    {
        private readonly MProcessDbcontext mprocessdb;

        public ItemRepository()
        {
            mprocessdb = Program.mprocessdb;
        }
        public async Task<Item> AddAsync(Item item)
        {
            await mprocessdb.Items.AddAsync(item);
            await mprocessdb.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<Item>> CodeAsync(string search)
        {
            return await mprocessdb.Items
            .Where(x => (x.Code != null && x.Code.Contains(search)))
            .OrderBy(x => x.Id)
            .ToListAsync();
        }

        public async Task<IEnumerable<Item>> ConstAsync(string search)
        {
            return await mprocessdb.Items
            .Where(x => (x.Constructor != null && x.Constructor.Contains(search)))
            .OrderBy(x => x.Id)
            .ToListAsync();
        }

        public async Task<Item?> DeleteAsync(int item)
        {
            var exsistingItem = await mprocessdb.Items.FindAsync(item);
            if (exsistingItem == null) return null;

            mprocessdb.Items.Remove(exsistingItem);
            await mprocessdb.SaveChangesAsync();
            return exsistingItem;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            var items = await mprocessdb.Items.ToListAsync();
            return items.OrderBy(x => x.Id).ToList();
        }

        public async Task<IEnumerable<Item>> ModiAsync(string search)
        {
            return await mprocessdb.Items
            .Where(x => (x.Modifier != null && x.Modifier.Contains(search)))
            .OrderBy(x => x.Id)
            .ToListAsync();
        }

        public async Task<IEnumerable<Item>> NameAsync(string search)
        {
            return await mprocessdb.Items
            .Where(x => (x.Name != null && x.Name.Contains(search)))
            .OrderBy(x => x.Id)
            .ToListAsync();
        }

        public async Task<IEnumerable<Item>> TypeAsync(string search)
        {
            return await mprocessdb.Items
            .Where(x => (x.Type != null && x.Type.Contains(search)))
            .OrderBy(x => x.Id)
            .ToListAsync();
        }

        public async Task<Item?> UpdateAsync(Item item)
        {
            var exsistingItem = await mprocessdb.Items.FindAsync(item.Id);
            if (exsistingItem == null) return null;

            exsistingItem.Code = item.Code;
            exsistingItem.Name = item.Name;
            exsistingItem.Comment = item.Comment;
            exsistingItem.Type = item.Type;

            exsistingItem.Modifier = item.Modifier;
            exsistingItem.ModDate = item.ModDate;

            await mprocessdb.SaveChangesAsync();
            return exsistingItem;
        }
    }
}
