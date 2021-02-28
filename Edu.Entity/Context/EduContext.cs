namespace Edu.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EduContext : DbContext
    {
        public EduContext()
            : base("name=EduContext")
        {
        }
        public virtual DbSet<EquipMeal> EquipMeal { get; set; }
        public virtual DbSet<EquipMB> EquipMB { get; set; }
        public virtual DbSet<PhotoBorder> PhotoBorder { get; set; }
        public virtual DbSet<OrderPhoto> OrderPhoto { get; set; }
        public virtual DbSet<LogInfo> LogInfo { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<RoleInfo> RoleInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
