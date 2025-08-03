# 3.0.0
1. Lose the reference to `System.Security.Principal.Windows` since it would restrict the library to Windows.

	The caller can instead create its own `CurrentUser` expression based on their current environment.   
