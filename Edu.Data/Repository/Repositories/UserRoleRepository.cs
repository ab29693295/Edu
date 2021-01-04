using Edu.Entity;
namespace Edu.Data
{

    public partial class DRoleInfo : GenericRepository<RoleInfo>
	{
		EduContext db;
		public DRoleInfo(EduContext DbContext)
			: base(DbContext)
		{
			db = DbContext;
		}
	}
}
 