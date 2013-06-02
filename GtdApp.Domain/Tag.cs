
using ServiceStack.DataAnnotations;

namespace GtdApp.Domain
{
	public class Tag
	{
		[AutoIncrement]
		public int TagId { get; set; }
		public string Name { get; set; }
	};
}
