using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Data;


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
                pants.id = 41;
                pants.price = 70;
                pants.type = "cap";

                database.Clothes.InsertOnSubmit(pants);
                database.SubmitChanges();

                Clothes mypants = database.Clothes.FirstOrDefault(panst => panst.id.Equals(41));

                Assert.AreEqual(mypants.id, 41);
                Assert.AreEqual(mypants.type, "cap");
                Assert.AreEqual(mypants.price, 70);

                database.Clothes.DeleteOnSubmit(pants);
                database.SubmitChanges();
            }
        }


        [TestMethod]
        [ExpectedException(typeof(System.Data.SqlClient.SqlException))]
        public void ConnectingToNonExsistingDB()
        {
            using (DataClasses1DataContext fake = new DataClasses1DataContext("Data Source = DESKTOP-H5C7HVQ; Initial Catalog = Fakeee; Integrated Security = True"))
            {

                Clothes clothes = new Clothes();
                clothes.id = 12345;
                clothes.price = 1000;
                clothes.type = "top";

                fake.Clothes.InsertOnSubmit(clothes);
                fake.SubmitChanges();
            }

        }
    }
}