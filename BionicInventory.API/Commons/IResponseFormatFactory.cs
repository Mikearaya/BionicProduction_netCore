/*
 * @CreateTime: Sep 3, 2018 8:31 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 3, 2018 9:00 PM
 * @Description: Modify Here, Please 
 */
using System.Collections;
using System.Collections.Generic;

namespace BionicInventory.API.Commons {
    public interface IResponseFormatFactory {
        ResponseDataFormat DataForPresentation (IList data);
    }
}