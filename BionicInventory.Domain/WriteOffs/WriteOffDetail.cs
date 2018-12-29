/*
 * @CreateTime: Dec 23, 2018 9:50 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 9:51 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using BionicProduction.Domain.StockBatchs;

namespace BionicProduction.Domain.WriteOffs {
    public partial class WriteOffDetail {
        public uint Id { get; set; }
        public uint BatchStorageId { get; set; }
        public uint WriteOffId { get; set; }
        public float Quantity { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

        public StockBatchStorage BatchStorage { get; set; }
        public WriteOff WriteOff { get; set; }
    }
}