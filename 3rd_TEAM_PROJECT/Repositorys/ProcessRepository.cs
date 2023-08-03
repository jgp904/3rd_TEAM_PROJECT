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
    public class ProcessRepository : IProcessRepository
    {
        private readonly AccountDbContext accountdb;
        private readonly MProcessDbcontext mprocessdb;

        public ProcessRepository()
        {
            mprocessdb = Program.mprocessdb;
            accountdb = Program.accountdb;
        }
        public async Task<MProcess> AddAsync(MProcess process)
        {
            await mprocessdb.MProcesses.AddAsync(process);
            await mprocessdb.SaveChangesAsync();
            
            return process;
        }


        public async Task<MProcess?> DeleteAsync(int process)
        {
            var existingProcess = await mprocessdb.MProcesses.FindAsync(process);
            if (existingProcess == null) return null;

            mprocessdb.MProcesses.Remove(existingProcess);
            await mprocessdb.SaveChangesAsync();
            return existingProcess;
        }

        public async Task<MProcess?> UpdateAsync(MProcess process)
        {
            var existingProcess = await mprocessdb.MProcesses.FindAsync(process.Id);
            if (existingProcess == null) return null;

            existingProcess.FacCode = process.FacCode;
            existingProcess.Code = process.Code;
            existingProcess.Name = process.Name;
            existingProcess.Comment = process.Comment;

          
            existingProcess.StockUnit1 = process.StockUnit1;
            existingProcess.StockUnit2 = process.StockUnit2;

            existingProcess.Modifier = process.Modifier;
            existingProcess.ModDate = process.ModDate;

            await mprocessdb.SaveChangesAsync();
            return existingProcess;
        }
        public async Task<IEnumerable<MProcess>> GetAllAsync()
        {
            var process = await mprocessdb.MProcesses.ToListAsync();
            return process.OrderBy(x => x.Id).ToList();
        }
        public async Task<IEnumerable<MProcess>> CodeAsync(string search)
        {
            return await mprocessdb.MProcesses
                    .Where(x=>(x.Code != null && x.Code.Contains(search)))
                    .OrderBy(x => x.Id)
                    .ToListAsync();
        }

        public async Task<IEnumerable<MProcess>> ConstAsync(string search)
        {
            return await mprocessdb.MProcesses
                    .Where(x => (x.Constructor != null && x.Constructor.Contains(search)))
                    .OrderBy(x => x.Id)
                    .ToListAsync();
        }

        public async Task<IEnumerable<MProcess>> ModiAsync(string search)
        {
            return await mprocessdb.MProcesses
                    .Where(x => (x.Modifier != null && x.Modifier.Contains(search)))
                    .OrderBy(x => x.Id)
                    .ToListAsync();
        }

        public async Task<IEnumerable<MProcess>> NameAsync(string search)
        {
            return await mprocessdb.MProcesses
                    .Where(x => (x.Name != null && x.Name.Contains(search)))
                    .OrderBy(x => x.Id)
                    .ToListAsync();
        }

        public async Task<IEnumerable<MProcess>> FacCodeAsync(string search)
        {
            return await mprocessdb.MProcesses
                    .Where(x => (x.FacCode != null && x.FacCode.Contains(search)))
                    .OrderBy(x => x.Id)
                    .ToListAsync();
        }
    }
}
