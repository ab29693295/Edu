using Edu.Entity;
namespace Edu.Data
{

    public partial class DOrder : GenericRepository<Order>
	{
		EduContext db;
		public DOrder(EduContext DbContext)
			: base(DbContext)
		{
			db = DbContext;
		}
	}
}
 