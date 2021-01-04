namespace Edu.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderPhoto")]
    public partial class OrderPhoto
    {
        /// <summary>
        /// 
        /// </summary>
        public OrderPhoto()
        {
        }

        private System.Int32 _ID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ID { get { return this._ID; } set { this._ID = value; } }

        private System.String _OrderID;
        /// <summary>
        /// 
        /// </summary>
        public System.String OrderID { get { return this._OrderID; } set { this._OrderID = value; } }

        private System.String _MealType;
        /// <summary>
        /// 
        /// </summary>
        public System.String MealType { get { return this._MealType; } set { this._MealType = value; } }

        private System.String _PhotoPath;
        /// <summary>
        /// 
        /// </summary>
        public System.String PhotoPath { get { return this._PhotoPath; } set { this._PhotoPath = value; } }

        private System.String _PhotoServerPath;
        /// <summary>
        /// 
        /// </summary>
        public System.String PhotoServerPath { get { return this._PhotoServerPath; } set { this._PhotoServerPath = value; } }

        private System.String _CreatDate;
        /// <summary>
        /// 
        /// </summary>
        public System.String CreatDate { get { return this._CreatDate; } set { this._CreatDate = value; } }

        private System.String _EqID;
        /// <summary>
        /// 
        /// </summary>
        public System.String EqID { get { return this._EqID; } set { this._EqID = value; } }

        private System.String _Status;
        /// <summary>
        /// 
        /// </summary>
        public System.String Status { get { return this._Status; } set { this._Status = value; } }
    }
}