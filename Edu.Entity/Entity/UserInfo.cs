namespace Edu.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserInfo")]
    public partial class UserInfo
    {
  /// <summary>
            /// 
            /// </summary>
        public UserInfo()
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

        private System.String _TrueName;
        /// <summary>
        /// 
        /// </summary>
        public System.String TrueName { get { return this._TrueName; } set { this._TrueName = value; } }


        private System.String _Phone;
        /// <summary>
        /// 
        /// </summary>
        public System.String Phone { get { return this._Phone; } set { this._Phone = value; } }

        private System.Int32? _Sex;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? Sex { get { return this._Sex; } set { this._Sex = value; } }

        private System.String _Age;
        /// <summary>
        /// 
        /// </summary>
        public System.String Age { get { return this._Age; } set { this._Age = value; } }

        private System.String _PassWord;
        /// <summary>
        /// 
        /// </summary>
        public System.String PassWord { get { return this._PassWord; } set { this._PassWord = value; } }

        private System.Int32? _RoleID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? RoleID { get { return this._RoleID; } set { this._RoleID = value; } }

        private System.String _NickName;
        /// <summary>
        /// 
        /// </summary>
        public System.String NickName { get { return this._NickName; } set { this._NickName = value; } }

        private System.String _WxID;
        /// <summary>
        /// 
        /// </summary>
        public System.String WxID { get { return this._WxID; } set { this._WxID = value; } }

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

        private System.String _Address;
        /// <summary>
        /// 
        /// </summary>
        public System.String Address { get { return this._Address; } set { this._Address = value; } }

        private System.Int32? _Creator;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32? Creator { get { return this._Creator; } set { this._Creator = value; } }

    }
}