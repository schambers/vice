using System.Collections.Generic;
using NUnit.Framework;
using Vice.Tests.Domain;

namespace Vice.Tests
{
	[TestFixture]
	public class EmployeeTests
	{
		private ViceAppender _viceAppender;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			_viceAppender = new ViceAppender(new log4net.Layout.SimpleLayout());
			log4net.Config.BasicConfigurator.Configure(_viceAppender);
		}

		[Test]
		public void employee_is_paid_expected_amount()
		{
			_viceAppender.AddVerification("deduction total=" + 70m);
			_viceAppender.AddVerification("salary=" + 330m);

			IList<decimal> _deductions = new List<decimal>();
			_deductions.Add(50m);
			_deductions.Add(20m);

			var employee = new Employee(400m, _deductions);
			employee.Pay();

			_viceAppender.PrintExpectations();
			Assert.IsTrue(_viceAppender.Verify(), "Expectations not met");
		}
	}
}
