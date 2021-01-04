
using Edu.Data;
using Edu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Edu.Service
{
    public partial class UnitOfWork : IDisposable
    {
	
		private DEduContext _DEduContext;
      
        public DEduContext DEduContext
        {
            get
            {
                if (this._DEduContext == null)
                {
                    this._DEduContext = new DEduContext(context);
                }
                return _DEduContext;
            }
        }

		
		private DEquipment _DEquipment;
      
        public DEquipment DEquipment
        {
            get
            {
                if (this._DEquipment == null)
                {
                    this._DEquipment = new DEquipment(context);
                }
                return _DEquipment;
            }
        }

		
		private DMenu _DMenu;
      
        public DMenu DMenu
        {
            get
            {
                if (this._DMenu == null)
                {
                    this._DMenu = new DMenu(context);
                }
                return _DMenu;
            }
        }

		
		private DOrder _DOrder;
      
        public DOrder DOrder
        {
            get
            {
                if (this._DOrder == null)
                {
                    this._DOrder = new DOrder(context);
                }
                return _DOrder;
            }
        }

		
		private DOrderPhoto _DOrderPhoto;
      
        public DOrderPhoto DOrderPhoto
        {
            get
            {
                if (this._DOrderPhoto == null)
                {
                    this._DOrderPhoto = new DOrderPhoto(context);
                }
                return _DOrderPhoto;
            }
        }

		
		private DRoleInfo _DRoleInfo;
      
        public DRoleInfo DRoleInfo
        {
            get
            {
                if (this._DRoleInfo == null)
                {
                    this._DRoleInfo = new DRoleInfo(context);
                }
                return _DRoleInfo;
            }
        }

		
		private DUserInfo _DUserInfo;
      
        public DUserInfo DUserInfo
        {
            get
            {
                if (this._DUserInfo == null)
                {
                    this._DUserInfo = new DUserInfo(context);
                }
                return _DUserInfo;
            }
        }

	
    }
}