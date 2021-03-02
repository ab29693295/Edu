using Edu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Service
{
   public class EuipmentService
    {
        public static UnitOfWork unitOfWork = new UnitOfWork();
        public static void AddEquipMBMeal(Equipment Equip)
        {
            try
            {
                EquipMB equipMB = new EquipMB();

                equipMB.BeaMB = 10;
                equipMB.BeaMP = 10;
                equipMB.BeaDY = 10;
                equipMB.BeaYD = 10;
                equipMB.BeaBL = 10;
                equipMB.BeaSL = 10;
                equipMB.BeaMC = 10;
                equipMB.BeaZDQB = 1;
                equipMB.EqCode = Equip.EqCode;

                unitOfWork.DEquipMB.Insert(equipMB);

                EquipMeal equipMeal_F = new EquipMeal();
                equipMeal_F.EqCode = Equip.EqCode;
                equipMeal_F.EqID = Equip.ID;
                equipMeal_F.MealName = "套餐一 19.9元";
                equipMeal_F.MealPrice = 19.9;
                equipMeal_F.Status = 1;
                equipMeal_F.CreatDate = DateTime.Now;

                unitOfWork.DEquipMeal.Insert(equipMeal_F);


                EquipMeal equipMeal_S = new EquipMeal();
                equipMeal_S.EqCode = Equip.EqCode;
                equipMeal_S.EqID = Equip.ID;
                equipMeal_S.MealName = "套餐二 39.9元";
                equipMeal_S.MealPrice = 39.9;
                equipMeal_S.Status = 1;
                equipMeal_S.CreatDate = DateTime.Now;

                unitOfWork.DEquipMeal.Insert(equipMeal_S);

                unitOfWork.Save();

            }
            catch (Exception ex)
            {
                Edu.Tools.LogHelper.Info("添加美白套餐信息报错："+ex.ToString());
            }
           



        }
    }
}
