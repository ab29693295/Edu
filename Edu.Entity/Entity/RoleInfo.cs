namespace Edu.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleInfo")]
    public partial class RoleInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public RoleInfo()
        {
        }

        private System.Int32 _ID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ID { get { return this._ID; } set { this._ID = value; } }

        private System.String _RoleName;
        /// <summary>
        /// 
        /// </summary>
        public System.String RoleName { get { return this._RoleName; } set { this._RoleName = value; } }

        private System.String _Menus;
        /// <summary>
        /// 
        /// </summary>
        public System.String Menus { get { return this._Menus; } set { this._Menus = value; } }

        private System.Int32? _Status;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? Status { get { return this._Status; } set { this._Status = value; } }
    }
}