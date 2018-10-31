/*
 * @CreateTime: Sep 15, 2018 11:44 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 15, 2018 11:44 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.Employees.Models {
    public class EmployeeViewModel {

        private string _fullName;
        public uint id {set; get;}
        public string firstName {set; get;}
        public string lastName{set; get;}

        public string fullName{set {
            _fullName = $"{firstName} {lastName}";
        } get {
            return _fullName;
        }
        }
        public DateTime? dateAdded{set; get;}
        public DateTime? dateUpdated{set; get;}
    }
}