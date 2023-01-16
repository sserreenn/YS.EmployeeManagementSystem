using EMS.Domains.EntityFramework.Business.Repositories;
using EMS.Domains.EntityFramework.Entity.Repositories;
using EMS.Domains.EntityFramework.Entity.Repositories.Base;

namespace EMS.Domains.EntityFramework.Business.Extensions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EMSContext _context;
        public UnitOfWork(EMSContext context)
        {
            _context = context;
        }

        public ICompanyRepository _companies;
        public IBranchRepository _branchs;
        public IEmployeeRepository _employees;
        public ICheckinRepository _checkin;

        public ICompanyRepository Companies
        {
            get { return _companies ??= new CompanyRepository(_context); }
        }

        public IBranchRepository Branchs
        {
            get { return _branchs ??= new BranchRepository(_context); }
        }
        public IEmployeeRepository Employees
        {
            get { return _employees ??= new EmployeeRepository(_context); }
        }

        public ICheckinRepository Checkins
        {
            get { return _checkin??= new CheckinRepository(_context); }
        }

        public int SaveChanges()
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                int res = -1;
                try
                {
                    res = _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message
                    dbContextTransaction.Rollback(); 
                }
                return res;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Task.Run(() => _context.SaveChanges());
        }
    }
}
