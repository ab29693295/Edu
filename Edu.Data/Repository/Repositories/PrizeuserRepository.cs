using Edu.Entity;
namespace Edu.Data
{

    public partial class DPrizeuser : GenericRepository<Prizeuser>
	{
		EduContext db;
		public DPrizeuser(EduContext DbContext)
			: base(DbContext)
		{
			db = DbContext;
		}
	}
}
 