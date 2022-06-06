using System;
using System.Collections.Generic;

namespace Presentation.Model
{
    public class ClientModel
    {
        public ClientModel()
        {
        }

        public int id { get; set; }
        public string name { get; set; }

        public void Converter(Dictionary<String, String> customerInfo)
        {
            id = Int32.Parse(customerInfo["id"]);
            name = customerInfo["name"];
        }

    }
}
