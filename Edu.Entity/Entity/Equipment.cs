namespace Edu.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Equipment")]
    public partial class Equipment
    {
        /// <summary>
        /// 
        /// </summary>
        public Equipment()
        {
        }

        private System.Int32 _ID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ID { get { return this._ID; } set { this._ID = value; } }

        private System.String _EqName;
        /// <summary>
        /// 
        /// </summary>
        public System.String EqName { get { return this._EqName; } set { this._EqName = value; } }

        private System.String _EqCode;
        /// <summary>
        /// 
        /// </summary>
        public System.String EqCode { get { return this._EqCode; } set { this._EqCode = value; } }

        private System.String _EqType;
        /// <summary>
        /// 
        /// </summary>
        public System.String EqType { get { return this._EqType; } set { this._EqType = value; } }

        private System.DateTime? _StartDate;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? StartDate { get { return this._StartDate; } set { this._StartDate = value; } }

        private System.DateTime? _EndDate;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? EndDate { get { return this._EndDate; } set { this._EndDate = value; } }

        private System.Int32? _UserID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? UserID { get { return this._UserID; } set { this._UserID = value; } }

        private System.String _Address;
        /// <summary>
        /// 
        /// </summary>
        public System.String Address { get { return this._Address; } set { this._Address = value; } }

        private System.Int32? _EqRunStatus;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? EqRunStatus { get { return this._EqRunStatus; } set { this._EqRunStatus = value; } }

        private System.Int32? _EqStatus;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? EqStatus { get { return this._EqStatus; } set { this._EqStatus = value; } }

        private System.String _TrueName;
        /// <summary>
        /// 
        /// </summary>
        public System.String TrueName { get { return this._TrueName; } set { this._TrueName = value; } }

        private System.DateTime? _CreatDate;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? CreatDate { get { return this._CreatDate; } set { this._CreatDate = value; } }

        private System.DateTime? _LoginDate;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? LoginDate { get { return this._LoginDate; } set { this._LoginDate = value; } }


        
    }
}