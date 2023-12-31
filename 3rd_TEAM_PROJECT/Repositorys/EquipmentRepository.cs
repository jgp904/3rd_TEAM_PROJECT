﻿using _3rd_TEAM_PROJECT.Data;
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
    public class EquipmentRepository : IEquipmentRepository
    {

        private readonly MProcessDbcontext mprocessdb;      

        public EquipmentRepository()
        {
            mprocessdb = Program.mprocessdb;
        }

        public async Task<Equipment> AddAsync(Equipment equip)
        {
            await mprocessdb.Equipments.AddAsync(equip);
            await mprocessdb.SaveChangesAsync();
            var equipHis = new EquipHis
            {
                ProcessCode = equip.ProcessCode,
                Code = equip.Code,
                Name = equip.Name,
                Comment = equip.Comment,
                Status = equip.Status,
                Event = equip.Event,
                History = "Create",
                Constructor = equip.Constructor,
                RegDate = equip.RegDate,
            };
            await mprocessdb.EquipHis.AddAsync(equipHis);
            await mprocessdb.SaveChangesAsync();
            return equip;
        }

        public async Task<EquipHis?> DeleteHisAsync(int equipment)
        {
            var existingEquip = await mprocessdb.EquipHis.FindAsync(equipment);
            if (existingEquip == null) return null;
            
            mprocessdb.EquipHis.Remove(existingEquip);
            await mprocessdb.SaveChangesAsync();    
            return existingEquip;
        }
        public async Task<Equipment?> DeleteAsync(int equip)
        {
            var existingEquip = await mprocessdb.Equipments.FindAsync(equip);
            if (existingEquip == null) return null;
            var equipHis = new EquipHis
            {
                ProcessCode = existingEquip.ProcessCode,
                Code = existingEquip.Code,
                Name = existingEquip.Name,
                Comment = existingEquip.Comment,
                Status = existingEquip.Status,
                Event = existingEquip.Event,
                History = "Delete",
                Constructor = existingEquip.Constructor,
                RegDate = existingEquip.RegDate,
                Modifier = existingEquip.Modifier,
                ModDate = existingEquip.ModDate,
            };
            await mprocessdb.EquipHis.AddAsync(equipHis);
            mprocessdb.Equipments.Remove(existingEquip);
            await mprocessdb.SaveChangesAsync();
            return existingEquip;
        }

        public async Task<IEnumerable<Equipment>> GetAllAsync()
        {
            var equip = await mprocessdb.Equipments.ToListAsync();
            return equip.OrderBy(x => x.Id).ToList();
        }
        public async Task<IEnumerable<EquipHis>> GetAllHisAsync()//이력조회
        {
            var equipHis = await mprocessdb.EquipHis.ToListAsync();
            return equipHis.OrderByDescending(x => x.Id).ToList();
        }

        public async Task<Equipment?> UpdateAsync(Equipment equip)
        {
            var existingEquip = await mprocessdb.Equipments.FindAsync(equip.Id);
            if (existingEquip == null) return null;

            existingEquip.ProcessCode = equip.ProcessCode;
            existingEquip.Code = equip.Code;
            existingEquip.Name = equip.Name;
            existingEquip.Comment = equip.Comment;
            existingEquip.Status = equip.Status;
            existingEquip.Event = equip.Event;

            existingEquip.Modifier = equip.Modifier;
            existingEquip.ModDate = equip.ModDate;
            await mprocessdb.SaveChangesAsync();
            
            var equipHis = new EquipHis
            {
                ProcessCode = existingEquip.ProcessCode,
                Code = existingEquip.Code,
                Name = existingEquip.Name,
                Comment = existingEquip.Comment,
                Status = existingEquip.Status,
                Event = existingEquip.Event,
                History = "Update",
                Constructor = existingEquip.Constructor,
                RegDate = existingEquip.RegDate,
                Modifier = existingEquip.Modifier,
                ModDate = existingEquip.ModDate,
            };
            await mprocessdb.EquipHis.AddAsync(equipHis);
            await mprocessdb.SaveChangesAsync();
            return existingEquip;
        }
        

        public async Task<IEnumerable<Equipment>> CodeAsync(string search)
        {
            return await mprocessdb.Equipments
                .Where(x => (x.Code != null && x.Code.Contains(search)))
                .OrderBy(x => x.Id)
                .ToListAsync();
        }
        public async Task<IEnumerable<EquipHis>> HisAsync(string search)
        {
            return await mprocessdb.EquipHis
                .Where(x => (x.Code != null && x.Code.Contains(search)))
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Equipment>> NameAsync(string search)
        {
            return await mprocessdb.Equipments
                .Where(x => (x.Name != null && x.Name.Contains(search)))
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Equipment>> StatusAsync(string search)
        {
            return await mprocessdb.Equipments
                .Where(x => (x.Status != null && x.Status.Contains(search)))
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Equipment>> EventAsync(string search)
        {
            return await mprocessdb.Equipments
                .Where(x => (x.Event != null && x.Event.Contains(search)))
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Equipment>> ConstAsync(string search)
        {
            return await mprocessdb.Equipments
                .Where(x => (x.Constructor != null && x.Constructor.Contains(search)))
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Equipment>> ModiAsync(string search)
        {
            return await mprocessdb.Equipments
                .Where(x => (x.Modifier != null && x.Modifier.Contains(search)))
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Equipment>> ProcessCodeAsync(string search)
        {
            return await mprocessdb.Equipments
                .Where(x => (x.ProcessCode != null && x.ProcessCode.Contains(search)))
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<EquipHis>> DeleteHis(string search)
        {
            return await mprocessdb.EquipHis
                .Where(x=>x.History != null && x.History.Contains(search))
                .OrderBy(x=>x.Id)
                .ToListAsync();
        }

        
    }
}
