using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Solvek.Offliner.Lib.WidgetDescription;

namespace Solvek.Gears.Tests
{
	[TestClass]
	public class SourceTest
	{
		public SourceTest()
		{
		}

		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		[TestMethod]
		public void TestFilter()
		{
			const string FilterType = "Solvek.Offliner.Lib.Filters.EmptizeFilter";
			
			Source src = new Source();
			src.FilterType = FilterType;

			IFilter filter = src.Filter;

			Assert.AreEqual(FilterType, filter.GetType().FullName);
		}
	}
}
