using Edu.Entity;
namespace Edu.Data
{

    public partial class DOrderPhoto : GenericRepository<OrderPhoto>
	{
		EduContext db;
		public DOrderPhoto(EduContext DbContext)
			: base(DbContext)
		{
			db = DbContext;
		}
	}
}
 