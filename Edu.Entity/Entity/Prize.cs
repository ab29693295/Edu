namespace Edu.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prize")]
    public partial class Prize
    {
        /// <summary>
        /// 
        /// </summary>
        public Prize()
        {
        }

        private System.Int32 _ID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ID { get { return this._ID; } set { this._ID = value; } }

        private System.String _PrizeName;
        /// <summary>
        /// 
        /// </summary>
        public System.String PrizeName { get { return this._PrizeName; } set { this._PrizeName = value; } }

        private System.Int32? _PrizeCount;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? PrizeCount { get { return this._PrizeCount; } set { this._PrizeCount = value; } }

        private System.String _PrizeDes;
        /// <summary>
        /// 
        /// </summary>
        public System.String PrizeDes { get { return this._PrizeDes; } set { this._PrizeDes = value; } }

        private System.Int32? _PrizeStatus;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? PrizeStatus { get { return this._PrizeStatus; } set { this._PrizeStatus = value; } }
    }
}