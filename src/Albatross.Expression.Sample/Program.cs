using System;
using System.Data;

namespace Albatross.Expression.Sample {
	public class Program {
		static void Main(string[] args) {
			DataTable table = SetupTable();
			Generate(table);
			DataRowExecutionContextFactory factory = new DataRowExecutionContextFactory(Factory.Instance.Create());
			IExecutionContext<DataRow> context = factory.Create();
			context.SetExpression("age", "Year(Today()) - Year(DOB)");

			foreach (DataRow row in table.Rows) {
				row["age"] = context.GetValue("age", row);
				Console.WriteLine(row["age"]);
			}
		}

		static DataTable SetupTable() {
			DataTable table = new DataTable();
			table.Columns.Add(new DataColumn("FirstName") { DataType = typeof(string), });
			table.Columns.Add(new DataColumn("LastName") { DataType = typeof(string), });
			table.Columns.Add(new DataColumn("DOB") { DataType = typeof(DateTime), });
			table.Columns.Add(new DataColumn("Age") { DataType = typeof(int), });
			return table;
		}


		static void Generate(DataTable table) {
			table.Rows.Add("John", "Doe", new DateTime(1976, 1, 1));
			table.Rows.Add("Jane", "Doe", new DateTime(2000, 5, 8));
		}
	}
}
