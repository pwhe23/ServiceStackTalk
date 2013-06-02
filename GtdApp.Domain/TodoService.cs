
using System.Collections.Generic;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.Text;

namespace GtdApp.Domain
{
	[Route("/todos")]
	[Route("/todos/{Id}")]
	public class Todos
	{
		public int? Id { get; set; }
		public bool? Completed { get; set; }
	}

	[Csv(CsvBehavior.FirstEnumerable)]
	public class TodosResponse
	{
		public List<Todo> Results { get; set; }
	};

	[ClientCanSwapTemplates]
	[DefaultView("Todos")]
	public class TodoService : Service
	{
		private readonly TodoRepository _repo;

		public TodoService()
		{
			_repo = new TodoRepository(Db);
		}

		public object Get(Todos request)
		{
			return new TodosResponse
				{
					Results = _repo.GetAll(),
				};
		}
	}
}
