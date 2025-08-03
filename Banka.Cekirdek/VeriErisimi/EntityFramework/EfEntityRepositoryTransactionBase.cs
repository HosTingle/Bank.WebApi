using Banka.Cekirdek.Varlıklar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Banka.Cekirdek.VeriErisimi.EntityFramework
{
    public class EfEntityRepositoryTransactionBase<TEntity> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;

        public EfEntityRepositoryTransactionBase(DbContext context)
        {
            _context = context;
        } 

        public async Task Ekle(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
        public async Task Sil(TEntity entity)
        {

                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
 
        }

        public async Task Guncelle(TEntity entity)
        {


            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
        public async Task GuncelleTransaction(TEntity entity)
        {
     
      

            _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
    
        }
        public async Task<TEntity> Getir(Expression<Func<TEntity, bool>> filter = null)
        {
        
                return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
       
        }

        public async Task<List<TEntity>> HepsiniGetir(Expression<Func<TEntity, bool>> filter = null)
        {
 
                return filter == null
                    ? await _context.Set<TEntity>().ToListAsync()
                    : await _context.Set<TEntity>().Where(filter).ToListAsync();
      
        }
    }
}
