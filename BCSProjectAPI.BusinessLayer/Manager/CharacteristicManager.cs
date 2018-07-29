using BCSProjectAPI.DataLayer;
using BCSProjectAPI.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace BCSProjectAPI.BusinessLayer.Manager
{
    //rename later to be more easy to understand
    public class CharacteristicManager
    {
        public List<Characteristic> GetCharacteristics()
        {
            using (var db = new DataContext())
            {
                return db.Characteristics.ToList();
            }
        }

        public List<EmployeeCharacteristic> GetCharacteristics(int employeeId)
        {
            using(var db = new DataContext())
            {
                return db.EmployeeCharacteristics.Where(x => x.EmployeeId == employeeId).ToList();
            }
        }

        public List<EmployeeCharacteristic> GetEmployeeCharacteristics(int employeeId)
        {
            try
            {
                using (var db = new DataContext())
                {
                    return db.EmployeeCharacteristics
                                .Include(x => x.Characteristic)
                                .Where(x => x.EmployeeId == employeeId).ToList();
                    //var chars = db.Characteristics;


                    //var empChar = db.EmployeeCharacteristics.Where(x => x.EmployeeId == employeeId);
                    //var tempChar = new List<EmployeeCharacteristic>();

                    //foreach (var ch in chars)
                    //{
                    //    var isPublic = empChar.First(x => x.CharacteristicId == ch.Id)?.IsPublic;

                    //    tempChar.Add(
                    //            new EmployeeCharacteristic
                    //            {
                    //                CharacteristicId = ch.Id,
                    //                EmployeeId = employeeId,
                    //                IsPublic = isPublic.HasValue && isPublic.Value ? true : false,
                    //            }
                    //        );
                    //}
                    //return tempChar;
                }
            }
            catch(Exception err)
            {
                Debug.WriteLine(err);
            }
            return null;
        }

        //update or add employee field privacy
        public bool UpdateEmployeeCharateristics(EmployeeCharacteristic employeeCharacteristic)
        {
            try
            {
                using(var db = new DataContext())
                {

                    //var 
                }
            }
            catch(Exception err)
            {
                Debug.WriteLine(err);
            }
            return false;
        }
    }
}
