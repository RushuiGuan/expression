Create or update XML documentation comments for Albatross.Expression and Albatross.Expression.Utility projects.  Your task is to add or improve **XML documentation comments** for all symbols with public or protected accessibility.  Exclude class constructors with no parameters.

Requirements:
- Generate **triple-slash `///` XML documentation**.
- Each summary should be concise but descriptive of the purpose.
- Use <summary>, <param>, <returns>, and <remarks> tags appropriately.
- For classes/interfaces, describe their purpose and typical usage.
- For methods, describe both the behavior and edge cases.
- Be concise but informative. Avoid boilerplate like "Gets or sets the property". Instead, explain its actual intent if known.
- If the code purpose isn’t obvious, infer a reasonable description.
- Preserve the original code formatting. Only insert or update the documentation comments.