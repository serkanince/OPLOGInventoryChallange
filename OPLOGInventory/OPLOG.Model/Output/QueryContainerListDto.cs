using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Model.Output
{
    public class QueryContainerListDto
    {
        /// <summary>
        /// Container Label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Total Inventory Item
        /// </summary>
        public uint Total { get; set; }

        public ContainerShortListDto Inventory { get; set; }
        //public List<ContainerShortListDto> Inventory { get; set; }


    }
}
