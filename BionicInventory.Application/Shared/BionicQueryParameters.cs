/*
 * @CreateTime: Oct 13, 2018 6:47 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 13, 2018 8:27 PM
 * @Description: Modify Here, Please 
 */
using System;

namespace BionicInventory.Application.Shared {
    public class BionicQueryParameters {
        const int maxPageSize = 20;
        private int _pageSize = 10;
        public int pageNumber {get; set;} = 1;

        public int pageSize {
            get {
                return _pageSize;
            } 
            set {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public string searchQuery {get; set; }
    }
}