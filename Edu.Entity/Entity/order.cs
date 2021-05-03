namespace Edu.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        /// <summary>
        /// 
        /// </summary>
        public Order()
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

        private System.Int32? _MealType;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? MealType { get { return this._MealType; } set { this._MealType = value; } }

        private System.String _MealName;
        /// <summary>
        /// 
        /// </summary>
        public System.String MealName { get { return this._MealName; } set { this._MealName = value; } }

        private System.String _Price;
        /// <summary>
        /// 
        /// </summary>
        public System.String Price { get { return this._Price; } set { this._Price = value; } }

        private System.String _WxID;
        /// <summary>
        /// 
        /// </summary>
        public System.String WxID { get { return this._WxID; } set { this._WxID = value; } }

        private System.Int32? _PayStatus;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? PayStatus { get { return this._PayStatus; } set { this._PayStatus = value; } }

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

        private System.Int32? _EqUserID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? EqUserID { get { return this._EqUserID; } set { this._EqUserID = value; } }

        private System.DateTime? _CreatDate;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? CreatDate { get { return this._CreatDate; } set { this._CreatDate = value; } }

        private System.String _EquipID;
        /// <summary>
        /// 
        /// </summary>
        public System.String EquipID { get { return this._EquipID; } set { this._EquipID = value; } }

        private System.String _out_trade_no;
        /// <summary>
        /// 
        /// </summary>
        public System.String out_trade_no { get { return this._out_trade_no; } set { this._out_trade_no = value; } }

        private System.String _transaction_id;
        /// <summary>
        /// 
        /// </summary>
        public System.String transaction_id { get { return this._transaction_id; } set { this._transaction_id = value; } }
        

    }
}