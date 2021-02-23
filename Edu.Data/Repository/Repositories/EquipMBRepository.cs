using Edu.Entity;
namespace Edu.Data
{

    public partial class DEquipMB : GenericRepository<EquipMB>
	{
		EduContext db;
		public DEquipMB(EduContext DbContext)
			: base(DbContext)
		{
			db = DbContext;
		}
	}
}
 