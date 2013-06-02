
using System;
using System.Collections.Generic;
using System.Data;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;

namespace GtdApp.Domain
{
	public class Todo
	{
		[AutoIncrement]
		public int TodoId { get; set; }
		public string Title { get; set; }
		public DateTime Created { get; set; }
		public DateTime? Due { get; set; }
		public DateTime? Completed { get; set; }
	};

	public class TodoRepository
	{
		private readonly IDbConnection _db;

		public TodoRepository(IDbConnection db)
		{
			_db = db;
		}

		public List<Todo> GetAll()
		{
			return _db.Select<Todo>();
		}
	};
}
