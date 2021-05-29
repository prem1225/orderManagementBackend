using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Models
{
    public class Shipper
    {
		public int ShipperID { get; set; }
		public string CompanyName { get; set; }
		public string Phone { get; set; }

		/*public Shipper(int ShipperID, string CompanyName, string Phone)
		{
			this.ShipperID = ShipperID;
			this.CompanyName = CompanyName;
			this.Phone = Phone;
		}*/
	}
}
