
using System.Collections.Generic;
using Funq;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface.Auth;

namespace GtdApp.Domain
{
	public class GtdDb
	{
		public static void Init(Container container)
		{
			container.Register<IDbConnectionFactory>(
				new OrmLiteConnectionFactory(":memory:", false, SqliteDialect.Provider)
			);

			using (var db = container.Resolve<IDbConnectionFactory>().OpenDbConnection())
			{
				db.CreateTableIfNotExists<Todo>();
				db.CreateTableIfNotExists<Tag>();
				db.InsertAll(GetTodoSeedData());
			}

			container.Register<IUserAuthRepository>(c =>
			   new OrmLiteAuthRepository(c.Resolve<IDbConnectionFactory>())
			);

			var authRepo = (OrmLiteAuthRepository)container.Resolve<IUserAuthRepository>();
			authRepo.CreateMissingTables();
		}

		public static IEnumerable<Todo> GetTodoSeedData()
		{
			return new[] {
				new Todo { Title = "Todo1" },
				new Todo { Title = "Todo2" },
			};
		}
	};
}
