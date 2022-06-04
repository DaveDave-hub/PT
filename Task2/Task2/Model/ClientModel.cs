using System;
using System.Collections.Generic;

namespace Presentation.Model
{
    public class ClientModel
    {
        public ClientModel()
        {
        }

        public int customer_Id { get; set; }
        public string customer_Name { get; set; }  

        public void Converter(Dictionary<String, String> customerInfo)
        {
            customer_Id = Int32.Parse(customerInfo["id"]);
            customer_Name = customerInfo["name"];
        }
    }
}
