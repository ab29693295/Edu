using Edu.Entity;
namespace Edu.Data
{

    public partial class DPhotoBorder : GenericRepository<PhotoBorder>
	{
		EduContext db;
		public DPhotoBorder(EduContext DbContext)
			: base(DbContext)
		{
			db = DbContext;
		}
	}
}
 