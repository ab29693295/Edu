namespace Edu.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EquipMeal")]
    public partial class EquipMeal
    {

        /// <summary>
        /// 
        /// </summary>
        public EquipMeal()
        {
        }


        private System.Int32 _ID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ID { get { return this._ID; } set { this._ID = value; } }

        private System.String _EqCode;
        /// <summary>
        /// 
        /// </summary>
        public System.String EqCode { get { return this._EqCode; } set { this._EqCode = value; } }

        private System.String _MealName;
        /// <summary>
        /// 
        /// </summary>
        public System.String MealName { get { return this._MealName; } set { this._MealName = value; } }

        private System.Double? _MealPrice;
        /// <summary>
        /// 
        /// </summary>
        public System.Double? MealPrice { get { return this._MealPrice; } set { this._MealPrice = value; } }

        private System.DateTime? _CreatDate;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? CreatDate { get { return this._CreatDate; } set { this._CreatDate = value; } }

        private System.Int32? _Status;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? Status { get { return this._Status; } set { this._Status = value; } }

        private System.Int32? _EqID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? EqID { get { return this._EqID; } set { this._EqID = value; } }
    }
}
