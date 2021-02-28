namespace Edu.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EquipMB")]
    public partial class EquipMB
    {

        /// <summary>
        /// 
        /// </summary>
        public EquipMB()
        {
        }

        private System.Int32 _ID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ID { get { return this._ID; } set { this._ID = value; } }

        private System.Int32? _EqID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? EqID { get { return this._EqID; } set { this._EqID = value; } }

        private System.Int32? _BeaMB;
        /// <summary>
        /// 美白
        /// </summary>
        public System.Int32? BeaMB { get { return this._BeaMB; } set { this._BeaMB = value; } }

        private System.Int32? _BeaMP;
        /// <summary>
        /// 磨皮
        /// </summary>
        public System.Int32? BeaMP { get { return this._BeaMP; } set { this._BeaMP = value; } }

        private System.Int32? _BeaDY;
        /// <summary>
        /// 大眼
        /// </summary>
        public System.Int32? BeaDY { get { return this._BeaDY; } set { this._BeaDY = value; } }

        private System.Int32? _BeaYD;
        /// <summary>
        /// 眼袋
        /// </summary>
        public System.Int32? BeaYD { get { return this._BeaYD; } set { this._BeaYD = value; } }

        private System.Int32? _BeaBL;
        /// <summary>
        /// 鼻梁
        /// </summary>
        public System.Int32? BeaBL { get { return this._BeaBL; } set { this._BeaBL = value; } }

        private System.Int32? _BeaQB;
        /// <summary>
        /// 雀斑
        /// </summary>
        public System.Int32? BeaQB { get { return this._BeaQB; } set { this._BeaQB = value; } }

        private System.Int32? _BeaMC;
        /// <summary>
        /// 美唇
        /// </summary>
        public System.Int32? BeaMC { get { return this._BeaMC; } set { this._BeaMC = value; } }

        private System.Int32? _BeaLY;
        /// <summary>
        /// 亮眼
        /// </summary>
        public System.Int32? BeaLY { get { return this._BeaLY; } set { this._BeaLY = value; } }

        private System.Int32? _BeaZDQB;
        /// <summary>
        /// 自动雀斑
        /// </summary>
        public System.Int32? BeaZDQB { get { return this._BeaZDQB; } set { this._BeaZDQB = value; } }

        private System.String _EqCode;
        /// <summary>
        /// 
        /// </summary>
        public System.String EqCode { get { return this._EqCode; } set { this._EqCode = value; } }

        private System.Int32? _BeaSL;
        /// <summary>
        /// 瘦脸
        /// </summary>
        public System.Int32? BeaSL { get { return this._BeaSL; } set { this._BeaSL = value; } }
    }
}
