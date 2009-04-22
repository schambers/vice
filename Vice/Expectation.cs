namespace Vice
{
	public class Expectation
	{
		protected string Message { get; set; }
		public bool WasCalled { get; set; }

		public Expectation(string message, bool wasCalled)
		{
			Message = message;
			WasCalled = wasCalled;
		}
	}
}