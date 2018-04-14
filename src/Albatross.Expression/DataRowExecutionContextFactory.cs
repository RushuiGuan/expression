using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Albatross.Expression {
	public class DataRowExecutionContextFactory : IExecutionContextFactory<DataRow> {
		IParser parser;

		public bool CaseSensitive { get; set; }
		public bool CacheExternalValue { get; set; }
		public bool FailWhenMissingVariable { get; set; }


		public DataRowExecutionContextFactory(IParser parser) {
			this.parser = parser;
			CaseSensitive = false;
			CacheExternalValue = false;
			FailWhenMissingVariable = true;
		}

		public IExecutionContext<DataRow> Create() {
			return new ExecutionContext<DataRow>(parser, CaseSensitive, CacheExternalValue, FailWhenMissingVariable, TryGetExternalValue);
		}

		public bool TryGetExternalValue(string name, DataRow row, out object value) {
			if (row != null) {
				int index = row.Table.Columns.IndexOf(name);
				if (index != -1) {
					value = row[index];
					if (value == DBNull.Value) { value = null; }
					return true;
				}
			}
			value = null;
			return false;
		}
	}
}
