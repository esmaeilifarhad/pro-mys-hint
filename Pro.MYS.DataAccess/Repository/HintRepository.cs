using Microsoft.EntityFrameworkCore;
using Pro.MYS.Application.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pro.MYS.DataAccess.Repository
{
    public class HintRepository : RepositoryGeneric<Domains.Hint>,  IHintRepository
    {

        private readonly DbSet<Domains.Hint> _entitiesPersonelnfo;
        public virtual IQueryable<Domains.Hint> TableNoTracking => _entitiesPersonelnfo.AsNoTracking();

        public DatabaseContext _context { get; }
        public HintRepository(DatabaseContext context) : base(context)
        {
            _context = context;
            _entitiesPersonelnfo = context.Set<Domains.Hint>();
        }

    }
}
