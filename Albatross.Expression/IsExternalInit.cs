using System.ComponentModel;

namespace System.Runtime.CompilerServices {
	/// <summary>
	/// Internal marker class used by the compiler to enable init-only property setters in older target frameworks.
	/// This class allows the use of C# 9.0 init-only properties when targeting frameworks that don't natively support them.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal static class IsExternalInit {
	}

	/// <summary>
	/// Internal attribute used by the compiler to mark required members in C# 11.0 and later.
	/// This attribute ensures that certain properties or fields must be initialized during object construction.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	internal sealed class RequiredMemberAttribute : Attribute {
	}

	/// <summary>
	/// Internal attribute used by the compiler to indicate that a feature requires specific compiler support.
	/// This is used for advanced language features that may not be available in all environments.
	/// </summary>
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
	internal sealed class CompilerFeatureRequiredAttribute : Attribute {
		/// <summary>
		/// Initializes a new instance of the CompilerFeatureRequiredAttribute class.
		/// </summary>
		/// <param name="featureName">The name of the required compiler feature.</param>
		public CompilerFeatureRequiredAttribute(string featureName) {
			FeatureName = featureName;
		}

		/// <summary>
		/// Gets the name of the required compiler feature.
		/// </summary>
		public string FeatureName { get; }
		
		/// <summary>
		/// Gets or sets a value indicating whether the compiler feature is optional.
		/// </summary>
		public bool IsOptional { get; init; }

		/// <summary>
		/// Constant representing the ref structs compiler feature.
		/// </summary>
		public const string RefStructs = nameof(RefStructs);
		
		/// <summary>
		/// Constant representing the required members compiler feature.
		/// </summary>
		public const string RequiredMembers = nameof(RequiredMembers);
	}
}

namespace System.Diagnostics.CodeAnalysis {
	/// <summary>
	/// Internal attribute used by the compiler to indicate that a constructor sets all required members.
	/// This attribute is used in conjunction with required members to ensure proper initialization.
	/// </summary>
	[AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
	internal sealed class SetsRequiredMembersAttribute : Attribute {
	}
}