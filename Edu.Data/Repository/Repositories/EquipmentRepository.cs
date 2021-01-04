using Edu.Entity;
namespace Edu.Data
{

    public partial class DEquipment : GenericRepository<Equipment>
	{
		EduContext db;
		public DEquipment(EduContext DbContext)
			: base(DbContext)
		{
			db = DbContext;
		}
	}
}
 