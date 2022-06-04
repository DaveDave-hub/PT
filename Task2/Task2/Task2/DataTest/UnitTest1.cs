
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dataa;


using System;
using System.Linq;




namespace DataTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddClothestoDatabase()
        {
            using (DataClasses1DataContext database = new DataClasses1DataContext("Data Source = DESKTOP-188BQGV; Initial Catalog = SHOP; Integrated Security = True"))
            {



               Clothes pants = new Clothes();
                pants.id = 2;
                pants.price = 2;
                pants.type = "pants";



                database.Clothes.InsertOnSubmit(pants);
                database.SubmitChanges();





                Clothes mypants = database.Clothes.FirstOrDefault(doonut => doonut.id.Equals(2));

                Assert.AreEqual(mypants.id, 2);
                Assert.AreEqual(mypants.type, "pants");
                Assert.AreEqual(mypants.price, 2);



                database.Clothes.DeleteOnSubmit(pants);
                database.SubmitChanges();
            }
        }
    }
}