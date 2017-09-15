using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Shouldly;

namespace Test
{
    [TestClass]
    public class ValidationTest
    {
        [TestMethod]
        public void Validation_WhenEntityHasComputedColumn_ShouldValidate()
        {
            var entity = new MyEntity { MyColumn = "something" };
            var context = new MyDbContext();
            context.MyEntities.Add(entity);
            context.GetValidationErrors()
                .SelectMany(p => p.ValidationErrors).Select(p => $"{p.PropertyName} - ${p.ErrorMessage})")
                .ShouldBeEmpty();
        }

        [TestMethod]
        public void Saving_WhenEntityHasComputedColumn_ShouldValidate()
        {
            var entity = new MyEntity { MyColumn = "something" };
            var context = new MyDbContext();
            context.MyEntities.Add(entity);
            Should.NotThrow(() => context.SaveChanges());
        }
    }
}
