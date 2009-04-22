using System.Collections.Generic;
using System.Linq;
using log4net;

namespace Vice.Tests.Domain
{
	public class Employee
	{
		private ILog _log = LogManager.GetLogger(typeof(Employee));
		private IEnumerable<decimal> _deductions;
		private decimal _salaryPerWeek;

		public Employee(decimal salaryPerWeek, IEnumerable<decimal> deductions)
		{
			_deductions = deductions;
			_salaryPerWeek = salaryPerWeek;
		}

		public void Pay()
		{
			// bunch of code outside the scope of this test

			foreach (var deduction in _deductions)
				_salaryPerWeek -= deduction;
				
			_log.Info("deduction total=" + _deductions.Sum());
			_log.Info("salary=" + _salaryPerWeek);
			_log.Info("completed");

			// more code we don't want to test right now
		}
	}
}
