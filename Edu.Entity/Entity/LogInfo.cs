using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Entity
{
    public class LogInfo
    {

        /// <summary>
        /// 日志表（上下架单独有日志表）
        /// </summary>
        public LogInfo()
        {
        }

        private System.Int32 _ID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 ID { get { return this._ID; } set { this._ID = value; } }

        private System.String _Name;
        /// <summary>
        /// 名称
        /// </summary>
        public System.String Name { get { return this._Name; } set { this._Name = value; } }

        private System.String _TableName;
        /// <summary>
        /// 操作表
        /// </summary>
        public System.String TableName { get { return this._TableName; } set { this._TableName = value; } }

        private System.String _OpName;
        /// <summary>
        /// 操作表
        /// </summary>
        public System.String OpName { get { return this._OpName; } set { this._OpName = value; } }

        private System.String _Url;
        /// <summary>
        /// 操作地址
        /// </summary>
        public System.String Url { get { return this._Url; } set { this._Url = value; } }

        private System.String _BeforContent;
        /// <summary>
        /// 操作前内容
        /// </summary>
        public System.String BeforContent { get { return this._BeforContent; } set { this._BeforContent = value; } }

        private System.String _AfterContent;
        /// <summary>
        /// 操作后内容
        /// </summary>
        public System.String AfterContent { get { return this._AfterContent; } set { this._AfterContent = value; } }

        private System.Int32 _Creator;
        /// <summary>
        /// 操作人
        /// </summary>
        public System.Int32 Creator { get { return this._Creator; } set { this._Creator = value; } }

        private System.DateTime _CreateDate;
        /// <summary>
        /// 操作时间
        /// </summary>
        public System.DateTime CreateDate { get { return this._CreateDate; } set { this._CreateDate = value; } }

        private System.String _CreatorIP;
        /// <summary>
        /// 操作IP
        /// </summary>
        public System.String CreatorIP { get { return this._CreatorIP; } set { this._CreatorIP = value; } }
    }
}
