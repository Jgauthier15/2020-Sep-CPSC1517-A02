using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    // a class represents the defined characteristics of an item
    // an item can be a physical thing (cellphone), concept (student),
    // a collection of data
    // Visual Studio creates your Class without a specific access type
    // the default type for a Class is private
    // code outside of a private class cannot use the contents of the private class???
    // for the class to be used by an outside user (code) it must be public
    public class Window
    {
        //Private Data Members
        //These are variables that are known only within the Class
        //Will be used for Fully Implemented Properties
        //Will be used for Local Class Only Data
        private string _Manufacturer;
        private decimal _Height;

        //Public Data Memebers
        //These are variables that are known within the class and outside of the class
        //Public Data Members can be altered by code within and outside the class
        //It is preffered to use Properties instead of Public Data Members

        //Properties
        //Optional
        //Properties can be implemented in two ways;
        // a) Fully Implemented Property
        //Used because there is an additional code/logic used in processing the data.
        // b) Auto Implemented Property
        //Used when there is no need for addition code/logic
        //When the data is simply saved/stored

        //Fully Implemented Property
        public string Manufacturer
        {
            //Assume the Manufacturer is a nullable string
            //3 possibilities
            //  a) there are characters
            //  b) string has no data (null)
            //  c) there is a physical string BUT NO characters
            //There will be additional code/logic to ensure ONLY a and b
            //  exists for the Data.
            //This requires a private data member to hold the data
            //  and a property to manage the data content
            get
            {
                //returns data via the property to the outside user
                //of the property
                //a "get" operated on the right side of an equal sign (assignment statement)
                return _Manufacturer;
            }
            set
            {
                //The "set" takes incoming data and places that data
                //  into a private data member
                //Internal to the property, incoming data will be placed 
                //  in a common/local variable called "value"
                //A property is associated with a single data memeber
                //A property has NO parameter list
                //A "set" operates on the left side of an equal sign (assignment statement)
                if (string.IsNullOrEmpty(value))
                {
                    //ensure a null is stored in the private data member
                    //  eliminate the c) possibility
                    _Manufacturer = null;   //case b)
                }
                else
                {
                    //ensure the value is stored in the private data member
                    _Manufacturer = value;  //case a)
                }


                //alternative coding
                //syntax    receiving field = condistion(s) ? true value : false;
                // _Manufacturer = string.IsNullOrEmpty(value) ? null : value;

            }
        }

        public decimal Height
        {
            //Height must be greater than 0
            get { return _Height; }
            set
            {
                //the m indicated the value is a decimal
                if (value <= 0.0m)
                {
                    throw new Exception("Height cannot be 0 or less than 0.");
                }
                else
                {
                    _Height = value;
                }
            }
        }


        //Auto Implemented Property
        //  auto implemented properties can be used when there is no need
        //      for additional processing against the incoming data.
        //  NO internal private data memeber is required for this property
        //  The system WILL internally generate a data area for the data
        // access the stored data (get,set) CAN ONLY be done 
        //      via the property
        public decimal Width {get; set;}

        ////One can still code auto implemented properties as fully implemented properties
        //private decimal _Width;
        //public decimal Width
        //{
        //    get { return Width; }
        //    set { Width = value; }
        //}

        //What about nullable numerics?
        //Do we need to test for a null value to be used for missing incoming data?
        //NO, you do not have to code a fully implemented property for a Nullable Numeric
        //Numerics have a default of zero.
        //Numerics CAN ONLY store a numeric (unless nullable)
        //Numerics CAN BE NULL if declared as nullable.
        //IF the numeric has addtiional criteria THEN you can
        //  code the property as a fully implemented property.
        public int? NumberOfPanes { get; set; }

        //Constructors
        //a constructor is "a method" that guarantees that the newly
        //  created instance of this class will ALWAYS be created in 
        //  "a known state"

        //syntax?
        //public constructorname([list of parameters])
        //{
        //      your code
        //}
        //NOTE: there is NO RETURN DATATYPE

        //constructors are OPTIONAL
        //IF a class DOES NOT have a constructor, then the system
        //  will generate the class instance using the datatype defaults
        //  for you private data members and auto implemented properties.
        //This situation of no constructor(s) is often referred to as
        //  using a "system" constructor.

        //IF you code a constructor, you MUST code any and all constructor(s)
        //  needed by your class.

        //There are two common types of contructors:
        //  Default constructor
        //  Greedy constructor

        //Default
        //this version of the constructor takes NO parameters
        //this version of the constructor usually similates the "system" constructor
        //you CAN if you wish, assign values to your class data members /properties
        //  that are NOT the system default for the datatype
        //this constructor is called on your behalf when an instance of the class
        //  is requested by the outside user.
        //You CAN NOT call a constructor directly like a method.

        public Window()
        {
            //technically numerics are set to zero when they are declared
            //logically in this class the numeric fields should NOT be zero
            //therefor, we will set the numeric fields to a litteral not equal to zero

            //one could assign values directly to private data members within the class
            //a preferred method is to use the properties instead of the private data members
            //  why? is that the properties may have validation to ensure acceptable 
            //      values exist for the data.
            //      also, auto implemented properties have no direct private data members

            Height = 0.9m;  //the assumed window height is .9 meters
            Width = 1.2m;
            NumberOfPanes = 1;
        }

        //Greedy Constructor
        //takes in a value for each data member/property in the class
        //each data member/property is assigned the appropriate incoming parameter value

        public Window(decimal width, decimal height, int? numberofpanes, string manufacturer)
        {
            Width = width;
            Height = height;
            NumberOfPanes = numberofpanes;
            Manufacturer = manufacturer;
        }

        //Behaviours
        //are also known as methods
        //optional

        //Area of a Window
        public decimal WindowArea()
        {
            return Height * Width;
        }

        //Perimeter of a Window
        public decimal WindowPerimeter()
        {
            return 2 * (Height + Width);
        }

    }
}
