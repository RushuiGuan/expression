using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression {
	public interface IExecutionContextFactory {
		IExecutionContext Create(bool caseSensitive);
	}
}
