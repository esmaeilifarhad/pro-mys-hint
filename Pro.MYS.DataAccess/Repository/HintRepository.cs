using Microsoft.EntityFrameworkCore;
using Pro.MYS.Application.Dto;
using Pro.MYS.Application.IRepository;
using Pro.MYS.Domains;

namespace Pro.MYS.DataAccess.Repository
{
    public class HintRepository : RepositoryGeneric<Domains.Hint>,  IHintRepository
    {

        private readonly DbSet<Domains.Hint> _entities;
        public virtual IQueryable<Domains.Hint> TableNoTracking => _entities.AsNoTracking();

        public DatabaseContext _context { get; }
        public HintRepository(DatabaseContext context) : base(context)
        {
            _context = context;
            _entities = context.Set<Domains.Hint>();
        }

        //public Task<PaginationOutDto<Hint>> ListHintPagination(PaginationParamDto param)
        //{
        //    throw new NotImplementedException();
        //}



        public async Task<PaginationOutDto<Hint>> ListHintPagination(PaginationParamDto param)
        {
            PaginationOutDto<Hint> data = new PaginationOutDto<Hint>();

            var query = TableNoTracking.
                   Where(q => q.Title.Contains(param.Search) || q.Description.Contains(param.Search));

            data.CountRecord = await query.CountAsync();
            data.ListData = await query.OrderBy(q => (q.RefreshDate)).
                    ThenBy(q => q.Created).
                    Skip(param.Skip * param.Take).
                            Take(param.Take).
                            ToListAsync();


            return data;
        }


    }


 
}
