namespace Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T> where T : class
    {
        protected readonly ApplicationDBContext _context;
        public EfRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
