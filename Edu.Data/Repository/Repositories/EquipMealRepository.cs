using Edu.Entity;
namespace Edu.Data
{

    public partial class DEquipMeal : GenericRepository<EquipMeal>
	{
		EduContext db;
		public DEquipMeal(EduContext DbContext)
			: base(DbContext)
		{
			db = DbContext;
		}
	}
}
 