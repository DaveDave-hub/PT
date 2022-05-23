using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using DataLayer.API;


namespace Tests
{
   public interface IGenerator
   {
        void GenerateData(DataLayerAPI data);
   }
} 