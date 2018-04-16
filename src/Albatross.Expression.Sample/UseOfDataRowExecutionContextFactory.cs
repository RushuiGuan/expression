using NUnit.Framework;
using System;
using System.Data;
using System.Diagnostics;

namespace Albatross.Expression.Sample {
	[TestFixture]
	public class UseOfDataRowExecutionContextFactory {
		DataTable SetupTable() {
			DataTable table = new DataTable();
			table.Columns.Add(new DataColumn("FirstName") { DataType = typeof(string), });
			table.Columns.Add(new DataColumn("LastName") { DataType = typeof(string), });
			table.Columns.Add(new DataColumn("DOB") { DataType = typeof(DateTime), });
			table.Columns.Add(new DataColumn("Age") { DataType = typeof(int), });
			return table;
		}


		void GenerateData(DataTable table) {
			table.Rows.Add("John", "Doe", new DateTime(1976, 1, 1));
			table.Rows.Add("Jane", "Doe", new DateTime(2000, 5, 8));
		}


		[Test]
		public void Run() {
			DataRowExecutionContextFactory factory = new DataRowExecutionContextFactory(Factory.Instance.Create());
			IExecutionContext<DataRow> context = factory.Create();
			context.SetExpression("age", "Year(Today()) - Year(DOB)");


			DataTable table = SetupTable();
			GenerateData(table);
			foreach (DataRow row in table.Rows) {
				row["age"] = context.GetValue("age", row);
				Debug.WriteLine("Calcuated: {0}", row["age"]);
			}
		}
	}
}
