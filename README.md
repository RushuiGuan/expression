* v3.0.13
	* New operation GetJsonArrayItem
		* Provided a json array and an index, the operation will return the array item at the index.
		* example 1: GetJsonArrayItem('[1, 2, 3]', 1)
			* return value 2
		* example 2: GetJsonArrayItem('[1, 2, 3]', 3)
			* throw an ArgumentException since array index is out of bound
* v3.0.12
	* New operation RegexCapture
		* RegexCapture can be used to extract part of a text string using regex pattern and capature groups.
		* Operands
			1. text to be parsed
			2. regex pattern
			3. group capture index (optional with the default of 0)
		* example 1: RegexCapture('abc123', '[a-z]+(\\d+)', 1)
			* returns 123
		* example 2: RegexCapture('abc123', '[a-z]+(\\d+)')
			* return abc123 because capture index is not specified and 0 is used by default
		* example 3: RegexCapture('abc123', '[a-z]+(\\d+)', 3)
			* throw an ArgumentException since capture index is out of bound
* 3.0.11
	* New operation 
		* Floor - The Floor operation calls C# Math.Floor.  It returns the largest integral value from the input double number.
		* Round - The Round operation calls C# Math.Round and use AwayFromZero rounding
			* Operands
				1. double value to be rounded
				2. number of fractional digits in the return value
		* UnixTimestamp2DateTime - Converts a Unix time expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z to a DateTime value in UTC
			* Operands
				1. integer: number of seconds that have elapsed since 1970-01-01T00:00:00Z
		


