
namespace Edu.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhotoBorder")]
    public partial class PhotoBorder
    {

      
        /// <summary>
        /// 
        /// </summary>
        public PhotoBorder()
        {
        }

        private System.Int32 _ID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ID { get { return this._ID; } set { this._ID = value; } }

        private System.String _BorderName;
        /// <summary>
        /// 边框名称
        /// </summary>
        public System.String BorderName { get { return this._BorderName; } set { this._BorderName = value; } }

        private System.String _BorderPath;
        /// <summary>
        /// 路径
        /// </summary>
        public System.String BorderPath { get { return this._BorderPath; } set { this._BorderPath = value; } }

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

        private System.String _Des;
        /// <summary>
        /// 描述
        /// </summary>
        public System.String Des { get { return this._Des; } set { this._Des = value; } }
    }
}
