Create or update XML documentation comments for Albatross.Expression and Albatross.Expression.Utility projects.

Requirements:
- Add or improve **XML documentation comments** for all symbols with public or protected accessibility.
- Generate **triple-slash `///` XML documentation**.
- Each summary should be concise but descriptive of the purpose.
- For classes/interfaces, describe their purpose and typical usage.
- For methods, describe both the behavior and edge cases.
- Be concise but informative. Avoid boilerplate like "Gets or sets the property". Instead, explain its actual intent if known.
- If the code purpose isn’t obvious, infer a reasonable description.
- Do not put documentation for interface members if the name of the interface is self explaining.
- Do not put documentation for constructors used by dependency injection or default constructors.