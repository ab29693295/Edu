using Edu.Entity;
namespace Edu.Data
{

    public partial class DPrize : GenericRepository<Prize>
	{
		EduContext db;
		public DPrize(EduContext DbContext)
			: base(DbContext)
		{
			db = DbContext;
		}
	}
}
 