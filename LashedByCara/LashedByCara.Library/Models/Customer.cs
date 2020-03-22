using System;


namespace LashedByCara.Library.Models
{
    public class Customer
    {
        // backing field for the "Name" property.
        // necessary to define this to be able to add validation to the setter.
        private string _name;

        /// <summary>
        /// The customer's Id. Zero indicates a missing value.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The customer's name. Must not be empty.
        /// </summary>
        public string Name
        {
            // expression-body syntax for accessing the backing field.
            // equivalent to "get { return _name; }"
            get => _name;
            set
            {
                // "value" is the value passed to the setter.
                if (value.Length == 0)
                {
                    // good practice to provide useful messages when throwing exceptions,
                    // as well as the name of the relevant parameter if applicable.
                    throw new ArgumentException("Name cannot be left empty", nameof(value));
                }
                _name = value;
            }

        
    }
}