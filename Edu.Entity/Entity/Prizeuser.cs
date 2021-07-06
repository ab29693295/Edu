namespace Edu.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prizeuser")]
    public partial class Prizeuser
    {
        /// <summary>
        /// 
        /// </summary>
        public Prizeuser()
        {
        }

        private System.Int32 _ID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ID { get { return this._ID; } set { this._ID = value; } }

        private System.String _UserName;
        /// <summary>
        /// 
        /// </summary>
        public System.String UserName { get { return this._UserName; } set { this._UserName = value; } }

        private System.String _UserPhone;
        /// <summary>
        /// 
        /// </summary>
        public System.String UserPhone { get { return this._UserPhone; } set { this._UserPhone = value; } }

        private System.String _UserAddress;
        /// <summary>
        /// 
        /// </summary>
        public System.String UserAddress { get { return this._UserAddress; } set { this._UserAddress = value; } }

        private System.Int32? _PrizeID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? PrizeID { get { return this._PrizeID; } set { this._PrizeID = value; } }

        private System.String _PrizeName;
        /// <summary>
        /// 
        /// </summary>
        public System.String PrizeName { get { return this._PrizeName; } set { this._PrizeName = value; } }

        private System.DateTime? _Create_Time;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? Create_Time { get { return this._Create_Time; } set { this._Create_Time = value; } }
    }
}